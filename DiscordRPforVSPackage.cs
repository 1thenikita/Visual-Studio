using System.Globalization;

namespace DiscordRPforVS
{
    using DiscordRPC;
    using DiscordRPforVS.Properties;
    using EnvDTE;
    using Microsoft.VisualStudio.Shell;
    using Microsoft.VisualStudio.Shell.Interop;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Threading;

    [PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
    [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400, LanguageIndependentName = "Discord Rich Presence")]
    [ProvideAutoLoad(UIContextGuids80.NoSolution, PackageAutoLoadFlags.BackgroundLoad)]
    [ProvideAutoLoad(UIContextGuids80.SolutionExists, PackageAutoLoadFlags.BackgroundLoad)]
    [Guid(PackageGuidString)]
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [ProvideBindingPath]
    public sealed class DiscordRPforVSPackage : AsyncPackage, IDisposable
    {
        public const String PackageGuidString = "ab4abbbf-2c58-4fb3-8d6f-651811a796aa";
        internal static DTE ide;
        private Boolean InitializedTimestamp;
        private Timestamps CurrentTimestamps;
        private Timestamps InitialTimestamps;
        private readonly DiscordRpcClient Discord = new DiscordRpcClient("551675228691103796", logger: new DiscordLogger());
        private readonly RichPresence Presence = new RichPresence();
        private readonly Assets Assets = new Assets();
        private String versionString;
        private String versionImageKey;
        public static Settings Settings { get; set; } = Settings.Default;

        protected override async System.Threading.Tasks.Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
        {
            try
            {
                await this.JoinableTaskFactory.SwitchToMainThreadAsync(cancellationToken);
                ide = GetGlobalService(typeof(SDTE)) as DTE;
                ide.Events.WindowEvents.WindowActivated += this.WindowActivated;
                ide.Events.SolutionEvents.BeforeClosing += this.SolutionBeforeClosing;

                String ideVersion = ide.Version.Split(new Char[1] { '.' })[0];
                this.versionString = $"Visual Studio {Constants.IdeVersions[Int32.Parse(ideVersion, CultureInfo.InvariantCulture)]}";
                this.versionImageKey = $"dev{ideVersion}";

                await SettingsCommand.InitializeAsync(this).ConfigureAwait(true);

                if (!this.Discord.IsInitialized && !this.Discord.IsDisposed)
                    if (!this.Discord.Initialize())
                        ActivityLog.LogError("DiscordRPforVS", "Could not start RP");

                if (Settings.loadOnStartup)
                    await this.UpdatePresenceAsync(ide.ActiveDocument).ConfigureAwait(true);

                await base.InitializeAsync(cancellationToken, progress).ConfigureAwait(true);
            }
            catch (OperationCanceledException exc)
            {
                ActivityLog.LogError(exc.Source, exc.Message);
            }
        }

        /// <summary>
        /// Handles closing a solution
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "VSTHRD100:Avoid async void methods")]
        private async void SolutionBeforeClosing() => await this.UpdatePresenceAsync(null).ConfigureAwait(true);


        /// <summary>
        /// Handles switching between windows
        /// </summary>
        /// <param name="windowActivated">The window switched to</param>
        /// <param name="lastWindow">The windows switched from</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "VSTHRD100:Avoid async void methods")]
        private async void WindowActivated(Window windowActivated, Window lastWindow)
        {
            await this.JoinableTaskFactory.SwitchToMainThreadAsync();

            if (!this.Discord.IsInitialized && !this.Discord.IsDisposed)
                if (!this.Discord.Initialize())
                    ActivityLog.LogError("DiscordRPforVS", "Could not start RP");

            if (windowActivated.Document != null)
                await this.UpdatePresenceAsync(windowActivated.Document).ConfigureAwait(true);
        }

        /// <summary>
        /// Updates the Presence with the document
        /// </summary>
        /// <param name="document"></param>
        /// <param name="overrideTimestampReset"></param>
        /// <returns></returns>
        public async System.Threading.Tasks.Task UpdatePresenceAsync(Document document, Boolean overrideTimestampReset = false)
        {
            try
            {
                await this.JoinableTaskFactory.SwitchToMainThreadAsync();

                if (!Settings.enabled)
                {
                    if (!this.Discord.IsInitialized && !this.Discord.IsDisposed)
                        if (!this.Discord.Initialize())
                            ActivityLog.LogError("DiscordRPforVS", "Could not start RP");

                    this.Discord.ClearPresence();
                    return;
                }

                this.Presence.Details = this.Presence.State = this.Assets.LargeImageKey = this.Assets.LargeImageText = this.Assets.SmallImageKey = this.Assets.SmallImageText = String.Empty;

                if (Settings.secretMode)
                {
                    this.Presence.Details = "I'm working on something you're";
                    this.Presence.State = "not allowed to know about, sorry.";
                    goto finish;
                }

                this.Presence.Details = this.Presence.State = "";
                String[] language = Array.Empty<String>();

                if (document != null)
                {
                    String filename = Path.GetFileName(path: document.FullName).ToUpperInvariant(), ext = Path.GetExtension(filename);
                    List<KeyValuePair<String[], String[]>> list = Constants.Languages.Where(lang => Array.IndexOf(lang.Key, filename) > -1 || Array.IndexOf(lang.Key, ext) > -1).ToList();
                    language = list.Count > 0 ? list[0].Value : Array.Empty<String>();
                }

                Boolean supported = language.Length > 0;
                this.Assets.LargeImageKey = Settings.largeLanguage ? supported ? language[0] : "text" : this.versionImageKey;
                this.Assets.LargeImageText = Settings.largeLanguage ? supported ? language[1] : "Unrecognized extension" : this.versionString;
                this.Assets.SmallImageKey = Settings.largeLanguage ? this.versionImageKey : supported ? language[0] : "text";
                this.Assets.SmallImageText = Settings.largeLanguage ? this.versionString : supported ? language[1] : "Unrecognized extension";

                if (Settings.showFileName)
                    this.Presence.Details = !(document is null) ? Path.GetFileName(document.FullName) : "No file.";

                if (Settings.showSolutionName)
                {
                    Boolean idling = ide.Solution is null || String.IsNullOrEmpty(ide.Solution.FullName);
                    this.Presence.State = idling ? "Idling" : $"Developing {Path.GetFileNameWithoutExtension(ide.Solution.FileName)}";

                    if (idling)
                    {
                        this.Assets.LargeImageKey = this.versionImageKey;
                        this.Assets.LargeImageText = this.versionString;
                        this.Assets.SmallImageKey = this.Assets.SmallImageText = "";
                    }
                }

                if (Settings.showTimestamp && document != null)
                {
                    if (!this.InitializedTimestamp)
                    {
                        this.InitialTimestamps = this.Presence.Timestamps = new Timestamps() { Start = DateTime.UtcNow };
                        this.InitializedTimestamp = true;
                    }

                    if (Settings.resetTimestamp && !overrideTimestampReset)
                        this.Presence.Timestamps = new Timestamps() { Start = DateTime.UtcNow };
                    else if (Settings.resetTimestamp && overrideTimestampReset)
                        this.Presence.Timestamps = this.CurrentTimestamps;
                    else if (!Settings.resetTimestamp && !overrideTimestampReset)
                        this.Presence.Timestamps = this.InitialTimestamps;

                    this.CurrentTimestamps = this.Presence.Timestamps;
                }

            finish:;
                this.Presence.Assets = this.Assets;

                if (!this.Discord.IsInitialized && !this.Discord.IsDisposed)
                    if (!this.Discord.Initialize())
                        ActivityLog.LogError("DiscordRPforVS", "Could not start RP");

                this.Discord.SetPresence(this.Presence);
            }
            catch (ArgumentException e)
            {
                ActivityLog.LogError(e.Source, e.Message);
            }
        }

        protected override Int32 QueryClose(out Boolean canClose)
        {
            this.Dispose();
            return base.QueryClose(out canClose);
        }

        public void Dispose() => this.Discord.Dispose();
    }
}
