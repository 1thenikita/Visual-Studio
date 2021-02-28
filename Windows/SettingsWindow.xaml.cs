namespace DiscordRPforVS
{
    using Microsoft.VisualStudio.Shell;
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Controls.Primitives;
    using Properties;

    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow
    {
        public SettingsWindow() => this.InitializeComponent();

        private void DiscordRPforVSSettingsWindow_Loaded(Object sender, RoutedEventArgs e)
        {
            this.Title = Translates.SettingsWindow.Title(Settings.Default.translates);
            this.IsPresenceEnabled.Content = Translates.SettingsWindow.IsPresenceEnabled(Settings.Default.translates);
            this.IsFileNameShown.Content = Translates.SettingsWindow.IsFileNameShown(Settings.Default.translates);
            this.IsSolutionNameShown.Content = Translates.SettingsWindow.IsSolutionNameShown(Settings.Default.translates);
            this.IsTimestampShown.Content = Translates.SettingsWindow.IsTimestampShown(Settings.Default.translates);
            this.IsTimestampResetEnabled.Content = Translates.SettingsWindow.IsTimestampResetEnabled(Settings.Default.translates);
            this.IsLanguageImageLarge.Content = Translates.SettingsWindow.IsLanguageImageLarge(Settings.Default.translates);
            this.SecretMode.Content = Translates.SettingsWindow.SecretMode(Settings.Default.translates);
            this.LoadOnStartup.Content = Translates.SettingsWindow.LoadOnStartup(Settings.Default.translates);

            this.IsPresenceEnabled.IsChecked = DiscordRPforVSPackage.Settings.enabled;
            this.IsFileNameShown.IsChecked = DiscordRPforVSPackage.Settings.showFileName;
            this.IsSolutionNameShown.IsChecked = DiscordRPforVSPackage.Settings.showSolutionName;
            this.IsTimestampShown.IsChecked = DiscordRPforVSPackage.Settings.showTimestamp;
            this.IsTimestampResetEnabled.IsChecked = DiscordRPforVSPackage.Settings.resetTimestamp;
            this.IsLanguageImageLarge.IsChecked = DiscordRPforVSPackage.Settings.largeLanguage;
            this.SecretMode.IsChecked = DiscordRPforVSPackage.Settings.secretMode;
            this.LoadOnStartup.IsChecked = DiscordRPforVSPackage.Settings.loadOnStartup;

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
    }
}
