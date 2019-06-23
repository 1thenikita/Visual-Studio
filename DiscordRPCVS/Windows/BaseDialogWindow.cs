using Microsoft.VisualStudio.PlatformUI;

namespace DiscordRPCVS
{
    public class BaseDialogWindow : DialogWindow
    {
        public BaseDialogWindow()
        {
            HasMaximizeButton = true;
            HasMinimizeButton = true;
            HasHelpButton = true;
        }
    }
}
