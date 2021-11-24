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
            this.Title = Settings.Default.LocalizationManager.CurrentLocalization.Title;
            this.IsPresenceEnabled.Content = Settings.Default.LocalizationManager.CurrentLocalization.IsPresenceEnabled;
            this.IsFileNameShown.Content = Settings.Default.LocalizationManager.CurrentLocalization.IsFileNameShown;
            this.IsSolutionNameShown.Content = Settings.Default.LocalizationManager.CurrentLocalization.IsSolutionNameShown;
            this.IsTimestampShown.Content = Settings.Default.LocalizationManager.CurrentLocalization.IsTimestampShown;
            this.IsTimestampResetEnabled.Content = Settings.Default.LocalizationManager.CurrentLocalization.IsTimestampResetEnabled;
            this.IsLanguageImageLarge.Content = Settings.Default.LocalizationManager.CurrentLocalization.IsLanguageImageLarge;
            this.SecretMode.Content = Settings.Default.LocalizationManager.CurrentLocalization.SecretMode;
            this.LoadOnStartup.Content = Settings.Default.LocalizationManager.CurrentLocalization.LoadOnStartup;
            this.UseEnglishLanguage.Content = Settings.Default.LocalizationManager.CurrentLocalization.UseEnglish;
        }
    }
}
