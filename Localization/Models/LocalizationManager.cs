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

            var localizationFileFactory = new LocalizationFileFactory();

            foreach (string filename in localizationFiles)
            {
                var acceptableFile = (T) localizationFileFactory.CreateLocalizationFile(filename);
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
    }
}
