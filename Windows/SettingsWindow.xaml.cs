namespace DiscordRPforVS
{
    using Microsoft.VisualStudio.Shell;
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using DiscordRPforVS.Localization.Models;

    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow
    {
        public SettingsWindow() => this.InitializeComponent();

        private void DiscordRPforVSSettingsWindow_Loaded(Object sender, RoutedEventArgs e)
        {
            UpdateSettings();

            this.IsPresenceEnabled.IsChecked = DiscordRPforVSPackage.Settings.enabled;
            this.IsFileNameShown.IsChecked = DiscordRPforVSPackage.Settings.showFileName;
            this.IsSolutionNameShown.IsChecked = DiscordRPforVSPackage.Settings.showSolutionName;
            this.IsTimestampShown.IsChecked = DiscordRPforVSPackage.Settings.showTimestamp;
            this.IsTimestampResetEnabled.IsChecked = DiscordRPforVSPackage.Settings.resetTimestamp;
            this.IsLanguageImageLarge.IsChecked = DiscordRPforVSPackage.Settings.largeLanguage;
            this.SecretMode.IsChecked = DiscordRPforVSPackage.Settings.secretMode;
            this.LoadOnStartup.IsChecked = DiscordRPforVSPackage.Settings.loadOnStartup;

            this.LanguageComboBox.DataContext = DiscordRPforVSPackage.LocalizationManager;
            this.LanguageComboBox.SelectedItem = DiscordRPforVSPackage.LocalizationManager.CurrentLocalization;

            this.LanguageLabel.DataContext = DiscordRPforVSPackage.LocalizationManager.CurrentLocalization;

            this.IsTimestampShown_ValueChanged(sender, e);
        }

        private void IsTimestampShown_ValueChanged(Object sender, RoutedEventArgs e)
        {
            this.IsTimestampResetEnabled.IsEnabled = (Boolean)this.IsTimestampShown.IsChecked;
            this.IsLanguageImageLarge.SetValue(Grid.RowProperty, (Boolean)this.IsTimestampShown.IsChecked ? 4 : 5);
        }

        private void OnSaveSettings(Object sender, RoutedEventArgs e)
        {
            SaveSettings();
        }

        private async void SaveSettings()
        {
            DiscordRPforVSPackage.Settings.enabled = (Boolean)this.IsPresenceEnabled.IsChecked;
            DiscordRPforVSPackage.Settings.showFileName = (Boolean)this.IsFileNameShown.IsChecked;
            DiscordRPforVSPackage.Settings.showSolutionName = (Boolean)this.IsSolutionNameShown.IsChecked;
            DiscordRPforVSPackage.Settings.showTimestamp = (Boolean)this.IsTimestampShown.IsChecked;
            DiscordRPforVSPackage.Settings.resetTimestamp = (Boolean)this.IsTimestampResetEnabled.IsChecked;
            DiscordRPforVSPackage.Settings.largeLanguage = (Boolean)this.IsLanguageImageLarge.IsChecked;
            DiscordRPforVSPackage.Settings.secretMode = (Boolean)this.SecretMode.IsChecked;
            DiscordRPforVSPackage.Settings.loadOnStartup = (Boolean)this.LoadOnStartup.IsChecked;
            DiscordRPforVSPackage.Settings.translates = DiscordRPforVSPackage.LocalizationManager.CurrentLocalization.LanguageName;

            DiscordRPforVSPackage.Settings.Save();

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
        /// Updates settings view
        /// </summary>
        private void UpdateSettings()
        {
            this.Title = DiscordRPforVSPackage.LocalizationManager.CurrentLocalization.Title;
            this.IsPresenceEnabled.Content = DiscordRPforVSPackage.LocalizationManager.CurrentLocalization.IsPresenceEnabled;
            this.IsFileNameShown.Content = DiscordRPforVSPackage.LocalizationManager.CurrentLocalization.IsFileNameShown;
            this.IsSolutionNameShown.Content = DiscordRPforVSPackage.LocalizationManager.CurrentLocalization.IsSolutionNameShown;
            this.IsTimestampShown.Content = DiscordRPforVSPackage.LocalizationManager.CurrentLocalization.IsTimestampShown;
            this.IsTimestampResetEnabled.Content = DiscordRPforVSPackage.LocalizationManager.CurrentLocalization.IsTimestampResetEnabled;
            this.IsLanguageImageLarge.Content = DiscordRPforVSPackage.LocalizationManager.CurrentLocalization.IsLanguageImageLarge;
            this.SecretMode.Content = DiscordRPforVSPackage.LocalizationManager.CurrentLocalization.SecretMode;
            this.LoadOnStartup.Content = DiscordRPforVSPackage.LocalizationManager.CurrentLocalization.LoadOnStartup;
            this.LanguageLabel.Text = DiscordRPforVSPackage.LocalizationManager.CurrentLocalization.Language;
            this.VersionLabel.Text = $"{DiscordRPforVSPackage.LocalizationManager.CurrentLocalization.Version}: {typeof(DiscordRPforVSPackage).Assembly.GetName().Version}";
        }

        private void OnLanguageComboBoxChanged(Object sender, SelectionChangedEventArgs e)
        {
            var senderComboBox = (ComboBox)sender;
            var selectedLanguage = (RpLocalizationFile)senderComboBox.SelectedItem;

            DiscordRPforVSPackage.LocalizationManager.SelectLanguage(selectedLanguage.LanguageName);

            UpdateSettings();
            SaveSettings();
        }
    }
}
