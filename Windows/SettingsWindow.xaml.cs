namespace DiscordRPforVS
{
    using Microsoft.VisualStudio.Shell;
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Controls.Primitives;
    using Properties;
    using System.Globalization;

    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow
    {
        public SettingsWindow() => this.InitializeComponent();

        private void DiscordRPforVSSettingsWindow_Loaded(Object sender, RoutedEventArgs e)
        {
            SetLanguage(DiscordRPforVSPackage.Settings.translates);

            this.IsPresenceEnabled.IsChecked = DiscordRPforVSPackage.Settings.enabled;
            this.IsFileNameShown.IsChecked = DiscordRPforVSPackage.Settings.showFileName;
            this.IsSolutionNameShown.IsChecked = DiscordRPforVSPackage.Settings.showSolutionName;
            this.IsTimestampShown.IsChecked = DiscordRPforVSPackage.Settings.showTimestamp;
            this.IsTimestampResetEnabled.IsChecked = DiscordRPforVSPackage.Settings.resetTimestamp;
            this.IsLanguageImageLarge.IsChecked = DiscordRPforVSPackage.Settings.largeLanguage;
            this.SecretMode.IsChecked = DiscordRPforVSPackage.Settings.secretMode;
            this.LoadOnStartup.IsChecked = DiscordRPforVSPackage.Settings.loadOnStartup;
            this.UseEnglishLanguage.IsChecked = DiscordRPforVSPackage.Settings.useEnglishLanguage;

            this.IsTimestampShown_ValueChanged(sender, e);
        }

        private void IsTimestampShown_ValueChanged(Object sender, RoutedEventArgs e)
        {
            this.IsTimestampResetEnabled.IsEnabled = (Boolean)this.IsTimestampShown.IsChecked;
            this.IsLanguageImageLarge.SetValue(Grid.RowProperty, (Boolean)this.IsTimestampShown.IsChecked ? 4 : 5);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "VSTHRD100:Avoid async void methods", Justification = "Async void return type required")]
        private async void SaveSettings(Object sender, RoutedEventArgs e)
        {
            DiscordRPforVSPackage.Settings.enabled = (Boolean)this.IsPresenceEnabled.IsChecked;
            DiscordRPforVSPackage.Settings.showFileName = (Boolean)this.IsFileNameShown.IsChecked;
            DiscordRPforVSPackage.Settings.showSolutionName = (Boolean)this.IsSolutionNameShown.IsChecked;
            DiscordRPforVSPackage.Settings.showTimestamp = (Boolean)this.IsTimestampShown.IsChecked;
            DiscordRPforVSPackage.Settings.resetTimestamp = (Boolean)this.IsTimestampResetEnabled.IsChecked;
            DiscordRPforVSPackage.Settings.largeLanguage = (Boolean)this.IsLanguageImageLarge.IsChecked;
            DiscordRPforVSPackage.Settings.secretMode = (Boolean)this.SecretMode.IsChecked;
            DiscordRPforVSPackage.Settings.loadOnStartup = (Boolean)this.LoadOnStartup.IsChecked;
            DiscordRPforVSPackage.Settings.useEnglishLanguage = (Boolean)this.UseEnglishLanguage.IsChecked;

            DiscordRPforVSPackage.Settings.translates = DiscordRPforVSPackage.Settings.useEnglishLanguage ? "en-US" : CultureInfo.CurrentCulture.ToString();
            DiscordRPforVSPackage.Settings.Save();
            SetLanguage(DiscordRPforVSPackage.Settings.translates);

            try
            {
                await SettingsCommand.Instance.package.JoinableTaskFactory.SwitchToMainThreadAsync();
            }
            catch (OperationCanceledException exc)
            {
                ActivityLog.LogError(exc.Source, exc.Message);
            }
            await ((DiscordRPforVSPackage)SettingsCommand.Instance.package).UpdatePresenceAsync(DiscordRPforVSPackage.ide.ActiveDocument, true).ConfigureAwait(true);
        }

        /// <summary>
        /// Set Language in settings
        /// </summary>
        /// <param name="translate">Translate</param>
        private void SetLanguage(string translate)
        {
            this.Title = Translates.SettingsWindow.Title(translate);
            this.IsPresenceEnabled.Content = Translates.SettingsWindow.IsPresenceEnabled(translate);
            this.IsFileNameShown.Content = Translates.SettingsWindow.IsFileNameShown(translate);
            this.IsSolutionNameShown.Content = Translates.SettingsWindow.IsSolutionNameShown(translate);
            this.IsTimestampShown.Content = Translates.SettingsWindow.IsTimestampShown(translate);
            this.IsTimestampResetEnabled.Content = Translates.SettingsWindow.IsTimestampResetEnabled(translate);
            this.IsLanguageImageLarge.Content = Translates.SettingsWindow.IsLanguageImageLarge(translate);
            this.SecretMode.Content = Translates.SettingsWindow.SecretMode(translate);
            this.LoadOnStartup.Content = Translates.SettingsWindow.LoadOnStartup(translate);
            this.UseEnglishLanguage.Content = Translates.SettingsWindow.UseEnglish(translate);
        }
    }
}
