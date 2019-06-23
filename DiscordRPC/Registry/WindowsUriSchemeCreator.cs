﻿using DiscordRPC.Logging;

namespace DiscordRPC.Registry
{
    internal class WindowsUriSchemeCreator : IUriSchemeCreator
    {
        private ILogger logger;
        public WindowsUriSchemeCreator(ILogger logger)
        {
            this.logger = logger;
        }

#if EXCLUDE_WIN32
        public bool RegisterUriScheme(UriSchemeRegister register)
        {
            throw new PlatformNotSupportedException("Library has been built exluding Win32. This has removed the ability for Windows to register the UriScheme");
        }
#else
        public bool RegisterUriScheme(UriSchemeRegister register)
        {
            //Prepare our location
            string location = register.ExecutablePath;
            if (location == null)
            {
                logger.Error("Failed to register application because the location was null.");
                return false;
            }

            //Prepare the Scheme, Friendly name, default icon and default command
            string scheme = "discord-" + register.ApplicationID;
            string friendlyName = "Run game " + register.ApplicationID + " protocol";
            string defaultIcon = location;
            string command = location;

            //We have a steam ID, so attempt to replce the command with a steam command
            if (register.UsingSteamApp)
            {
                //Try to get the steam location. If found, set the command to a run steam instead.
                string steam = GetSteamLocation();
                if (steam != null)
                    command = string.Format("\"{0}\" steam://rungameid/{1}", steam, register.SteamAppID);

            }

            //Okay, now actually register it
            CreateUriScheme(scheme, friendlyName, defaultIcon, command);
            return true;
        }

        /// <summary>
        /// Creates the actual scheme
        /// </summary>
        /// <param name="scheme"></param>
        /// <param name="friendlyName"></param>
        /// <param name="defaultIcon"></param>
        /// <param name="command"></param>
        private void CreateUriScheme(string scheme, string friendlyName, string defaultIcon, string command)
        {
            using (Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\" + scheme))
            {
                key.SetValue("", "URL:" + friendlyName);
                key.SetValue("URL Protocol", "");

                using (Microsoft.Win32.RegistryKey iconKey = key.CreateSubKey("DefaultIcon"))
                    iconKey.SetValue("", defaultIcon);

                using (Microsoft.Win32.RegistryKey commandKey = key.CreateSubKey("shell\\open\\command"))
                    commandKey.SetValue("", command);
            }
        }

        /// <summary>
        /// Gets the current location of the steam client
        /// </summary>
        /// <returns></returns>
        public string GetSteamLocation()
        {
            using (Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\\Valve\\Steam"))
            {
                if (key == null) return null;
                return key.GetValue("SteamExe") as string;
            }
        }
#endif


    }
}
