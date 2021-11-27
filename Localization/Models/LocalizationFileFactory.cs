﻿namespace DiscordRPforVS.Localization.Models
{
    public class LocalizationFileFactory
    {
        private System.Type GetAcceptableLocalizationFile(string filepath)
        {
            if (filepath == null)
            {
                throw new System.ArgumentNullException(nameof(filepath));
            }

            if (filepath.EndsWith(".json", System.StringComparison.InvariantCulture))
            {
                return typeof(JsonLocalizationFile);
            }

            throw new System.Exception($"No acceptable type for {filepath}");
        }

        public ILocalizationFile CreateLocalizationFile(string filename)
        {
            System.Type acceptableType = GetAcceptableLocalizationFile(filename);

            var acceptableFile = (ILocalizationFile)acceptableType.GetConstructor(
                new System.Type[] { typeof(string) }).Invoke(new object[] { filename });

            return acceptableFile;
        }
    }
}
