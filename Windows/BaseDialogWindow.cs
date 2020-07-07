namespace DiscordRPforVS
{
    using Microsoft.VisualStudio.PlatformUI;

    public class BaseDialogWindow : DialogWindow
    {
        public BaseDialogWindow()
        {
            this.HasMaximizeButton = true;
            this.HasMinimizeButton = true;
            this.HasHelpButton = true;
        }
    }
}
