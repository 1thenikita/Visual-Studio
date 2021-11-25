namespace DiscordRPforVS
{
    using DiscordRPforVS.Localization.Models;
    using System.Collections.Generic;
    using System.IO;

    public class LocalizationManager<T> : ILocalizationManager<T> where T : ILocalizationFile
    {
        public IList<T> Localizations { get; private set; }
        public T CurrentLocalization { get; private set; }

        public LocalizationManager(string localizationFolder)
        {
            Localizations = new List<T>();

            string[] localizationFiles = Directory.GetFiles(localizationFolder);
            
            if (localizationFiles.Length == 0)
            {
                throw new System.Exception($"Localization folder ({localizationFolder}) is empty");
            }

            foreach (string filename in localizationFiles)
            {
                System.Type acceptableType = GetAcceptableLocalizationFile(filename);
                var acceptableFile = (T)acceptableType.GetConstructor(
                    new System.Type[] { typeof(string) }).Invoke(new object[] { filename });

                Localizations.Add(acceptableFile);
            }

            CurrentLocalization = Localizations[0];
        }

        public T GetLanguage(string language)
        {
            foreach (T localizationFile in Localizations)
            {
                if (localizationFile.LanguageName == language)
                {
                    return localizationFile;
                }
            }

            throw new System.Exception($"Localization file for the {language} language not found");
        }

        public void SelectLanguage(string language)
        {
            CurrentLocalization = GetLanguage(language);
        }

        public System.Type GetAcceptableLocalizationFile(string filepath)
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
    }
}
