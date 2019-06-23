﻿using DiscordRPC.Logging;
using System;
using System.Diagnostics;

namespace DiscordRPC.Registry
{
    internal class UriSchemeRegister
    {
        /// <summary>
        /// The ID of the Discord App to register
        /// </summary>
        public string ApplicationID { get; set; }

        /// <summary>
        /// Optional Steam App ID to register. If given a value, then the game will launch through steam instead of Discord.
        /// </summary>
        public string SteamAppID { get; set; }

        /// <summary>
        /// Is this register using steam?
        /// </summary>
        public bool UsingSteamApp { get { return !string.IsNullOrEmpty(SteamAppID) && SteamAppID != ""; } }

        /// <summary>
        /// The full executable path of the application.
        /// </summary>
        public string ExecutablePath { get; set; }

        private ILogger _logger;
        public UriSchemeRegister(ILogger logger, string applicationID, string steamAppID = null, string executable = null)
        {
            _logger = logger;
            ApplicationID = applicationID.Trim();
            SteamAppID = steamAppID != null ? steamAppID.Trim() : null;
            ExecutablePath = executable ?? GetApplicationLocation();
        }

        /// <summary>
        /// Registers the URI scheme, using the correct creator for the correct platform
        /// </summary>
        public bool RegisterUriScheme()
        {
            //Get the creator
            IUriSchemeCreator creator = null;
            switch (Environment.OSVersion.Platform)
            {
                case PlatformID.Win32Windows:
                case PlatformID.Win32S:
                case PlatformID.Win32NT:
                case PlatformID.WinCE:
                    _logger.Trace("Creating Windows Scheme Creator");
                    creator = new WindowsUriSchemeCreator(_logger);
                    break;

                case PlatformID.Unix:
                    _logger.Trace("Creating Unix Scheme Creator");
                    creator = new UnixUriSchemeCreator(_logger);
                    break;

                case PlatformID.MacOSX:
                    _logger.Trace("Creating MacOSX Scheme Creator");
                    creator = new MacUriSchemeCreator(_logger);
                    break;

                default:
                    _logger.Error("Unkown Platform: " + Environment.OSVersion.Platform);
                    throw new PlatformNotSupportedException("Platform does not support registration.");
            }

            //Regiser the app
            return creator.RegisterUriScheme(this);
        }

        /// <summary>
        /// Gets the FileName for the currently executing application
        /// </summary>
        /// <returns></returns>
        public static string GetApplicationLocation()
        {
            return Process.GetCurrentProcess().MainModule.FileName;
        }
    }
}
