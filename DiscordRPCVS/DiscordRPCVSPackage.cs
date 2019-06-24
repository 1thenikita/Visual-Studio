using DiscordRPC;
using DiscordRPCVS.Properties;
using EnvDTE;
using Microsoft;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using Task = System.Threading.Tasks.Task;

namespace DiscordRPCVS
{
    /// <summary>
    /// This is the class that implements the package exposed by this assembly.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The minimum requirement for a class to be considered a valid package for Visual Studio
    /// is to implement the IVsPackage interface and register itself with the shell.
    /// This package uses the helper classes defined inside the Managed Package Framework (MPF)
    /// to do it: it derives from the Package class that provides the implementation of the
    /// IVsPackage interface and uses the registration attributes defined in the framework to
    /// register itself and its components with the shell. These attributes tell the pkgdef creation
    /// utility what data to put into .pkgdef file.
    /// </para>
    /// <para>
    /// To get loaded into VS, the package must be referred by &lt;Asset Type="Microsoft.VisualStudio.VsPackage" ...&gt; in .vsixmanifest file.
    /// </para>
    /// </remarks>
    [PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
    [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)]
    [ProvideAutoLoad(UIContextGuids80.NoSolution, PackageAutoLoadFlags.BackgroundLoad)]
    [ProvideAutoLoad(UIContextGuids80.SolutionExists, PackageAutoLoadFlags.BackgroundLoad)]
    [Guid(PackageGuidString)]
    [ProvideMenuResource("Menus.ctmenu", 1)]
    public sealed class DiscordRPCVSPackage : AsyncPackage
    {
        public const string PackageGuidString = "ab4abbbf-2c58-4fb3-8d6f-651811a796aa";
        internal static DiscordRpcClient discordClient = new DiscordRpcClient("551675228691103796");
        internal static Assets Assets;
        static readonly Dictionary<string[], string[]> Languages = new Dictionary<string[], string[]>
        {
            { new string[] { ".h", ".cc", ".hh", ".cpp", ".ipp", ".inl", ".c++", ".h++", ".hpp" }, new string[] { "cpp", "C++" } },
            { new string[] { ".go" }, new string[] { "go", "GO" } },
            { new string[] { ".php" }, new string[] { "php", "PHP" } },
            { new string[] { ".c" }, new string[] { "c", "C" } },
            { new string[] { ".rb", ".rbw" }, new string[] { "ruby", "Ruby" } },
            { new string[] { ".cs" }, new string[] { "csharp", "C#" } },
            { new string[] { ".ts" }, new string[] { "typescript", "Typescript" } },
            { new string[] { ".class", ".java" }, new string[] { "java", "Java" } },
            { new string[] { ".txt" }, new string[] { "text", "Text document" } },
            { new string[] { ".json" }, new string[] { "json", "JSON" } },
            { new string[] { ".py", ".pyw", ".pyi", ".pyx" }, new string[] { "python", "Python" } },
            { new string[] { ".css" }, new string[] { "css", "CSS" } },
            { new string[] { ".html" }, new string[] { "html", "Html" } },
            { new string[] { ".js" }, new string[] { "javascript", "Javascript" } },
            { new string[] { "CMakeLists.txt", "CMakeCache.txt" }, new string[] { "cmake", "CMake" } },
            { new string[] { ".md", ".markdown" }, new string[] { "markdown", "Markdown" } },
            { new string[] { ".xml" }, new string[] { "xml", "XML" } },
            { new string[] { ".xaml" }, new string[] { "xaml", "XAML" } },
            { new string[]{ ".cshtml", ".razor" }, new string[] { "cshtml", "CSHtml" } },
            { new string[]{ ".rs" }, new string[] { "rust", "Rust" } },
            { new string[]{ ".toml" }, new string[] { "toml", "TOML" } },
            { new string[]{ ".lua" }, new string[] { "lua", "Lua" } }
        };
        internal static DTE ide;
        internal static bool InitializedTimestamp;
        internal static Timestamps CurrentTimestamps;
        internal static Timestamps InitialTimestamps;
        internal static Version version;
        internal static Settings Settings => Settings.Default;
        internal static RichPresence Presence;
        internal string[] ideVersionProperties;

        #region Package Members

        /// <summary>
        /// Initialization of the package; this method is called right after the package is sited, so this is the place
        /// where you can put all the initialization code that rely on services provided by VisualStudio.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token to monitor for initialization cancellation, which can occur when VS is shutting down.</param>
        /// <param name="progress">A provider for progress updates.</param>
        /// <returns>A task representing the async work of package initialization, or an already completed task if there is none. Do not return null from this method.</returns>
        protected override async Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
        {
            await JoinableTaskFactory.SwitchToMainThreadAsync(cancellationToken);
            try
            {
                ide = GetGlobalService(typeof(SDTE)) as DTE;
                Assumes.Present(ide);

                ide.Events.WindowEvents.WindowActivated += OnWindowSwitch;
                version = new Version(ide.Version);

                bool vs2019 = version.Major == 16;
                ideVersionProperties = new string[] { vs2019 ? "vs2019" : "vs2017", vs2019 ? "2019" : "2017" };
                
                if (Settings.loadOnStartup)
                    await UpdatePresenceAsync(ide.ActiveDocument);

                await base.InitializeAsync(cancellationToken, progress);
                await SettingsCommand.InitializeAsync(this);
            }
            catch (Exception e)
            {
                ActivityLog.LogError(e.Source, e.Message);
            }
        }

#pragma warning disable VSTHRD100 // Avoid async void methods
        /// <summary>
        /// Handles switching between windows.
        /// </summary>
        /// <param name="windowActivated">The window switched to.</param>
        /// <param name="lastWindow">The windows switched from</param>
        private async void OnWindowSwitch(Window windowActivated, Window lastWindow)
        {
            await JoinableTaskFactory.SwitchToMainThreadAsync();
            if (windowActivated.Document != null)
                await UpdatePresenceAsync(windowActivated.Document);
        }
#pragma warning restore VSTHRD100 // Avoid async void methods

        /// <summary>
        /// Updates the presence with the document
        /// </summary>
        /// <param name="document"></param>
        /// <param name="overrideTimestampReset"></param>
        /// <returns></returns>
        internal async Task UpdatePresenceAsync(Document document, bool overrideTimestampReset = false)
        {
            try
            {
                await JoinableTaskFactory.SwitchToMainThreadAsync();
                Presence = new RichPresence();
                if (Settings.enabled)
                {
                    if (Settings.secretMode)
                    {
                        Presence.Details = "I'm working on something you're";
                        Presence.State = "not allowed to know about, sorry.";
                    }
                    else
                    {
                        string[] key = null;
                        foreach (string[] langkey in Languages.Keys)
                            if (Array.IndexOf(langkey, document != null ? Path.GetExtension(document.FullName).ToLower() : string.Empty) > -1 || Array.IndexOf(langkey, Path.GetFileName(document != null ? document.FullName : string.Empty)) > -1)
                                key = langkey;

                        bool supported = key != null && Languages.ContainsKey(key);
                        Assets = new Assets()
                        {
                            LargeImageKey = Settings.largeLanguage ? supported ? Languages[key][0] : "text" : ideVersionProperties[1],
                            LargeImageText = Settings.largeLanguage ? supported ? Languages[key][1] : "Unknown document type" : $"Visual Studio {ideVersionProperties[1]}",
                            SmallImageKey = Settings.largeLanguage ? ideVersionProperties[0] : supported ? Languages[key][0] : "text",
                            SmallImageText = Settings.largeLanguage ? $"Visual Studio {ideVersionProperties[1]}" : supported ? Languages[key][1] : "Unknown document type"
                        };
                        key = null;

                        if (Settings.showFileName)
                            Presence.Details = document != null ? Path.GetFileName(document.FullName) : "No file.";

                        if (Settings.showSolutionName)
                        {
                            bool idling = ide.Solution == null || ide.Solution.FullName == string.Empty || ide.Solution.FullName == null;
                            Presence.State = idling ? "Idling" : $"Developing {Path.GetFileNameWithoutExtension(ide.Solution.FullName)}";
                            Assets = idling ? new Assets()
                            {
                                LargeImageKey = ideVersionProperties[0],
                                LargeImageText = $"Visual Studio {ideVersionProperties[1]}"
                            } : Presence.Assets;
                        }

                        if (Settings.showTimestamp && !InitializedTimestamp)
                        {
                            Presence.Timestamps = new Timestamps() { Start = DateTime.UtcNow };
                            InitialTimestamps = Presence.Timestamps;
                            InitializedTimestamp = true;
                        }

                        if (Settings.resetTimestamp && Settings.showTimestamp && !overrideTimestampReset)
                            Presence.Timestamps = new Timestamps() { Start = DateTime.UtcNow };
                        else if (Settings.showTimestamp && (!Settings.resetTimestamp || overrideTimestampReset))
                            Presence.Timestamps = InitialTimestamps;
                        CurrentTimestamps = Presence.Timestamps;
                    }

                    if (!discordClient.IsInitialized)
                        discordClient.Initialize();

                    Presence.Assets = Assets;
                    discordClient.SetPresence(Presence);
                    Presence = null;
                    Assets = null;
                }
                else if (!Settings.enabled && discordClient.IsInitialized)
                    discordClient.Deinitialize();
            }
            catch (Exception e)
            {
                ActivityLog.LogError(e.Source, e.Message);
            }
        }

        protected override int QueryClose(out bool canClose)
        {
            try
            {
                discordClient.Dispose();
            }
            catch (Exception e)
            {
                ActivityLog.LogError(e.Source, e.Message);
            }
            return base.QueryClose(out canClose);
        }
        #endregion
    }
}
