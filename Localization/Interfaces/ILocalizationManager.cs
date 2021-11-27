namespace DiscordRPforVS
{
    using System.Collections.Generic;

    public interface ILocalizationManager<T> where T : ILocalizationFile
    {
        IList<T> Localizations { get; }
        T CurrentLocalization { get; }

        T GetLanguage(string language);
        void SelectLanguage(string language);
    }
}
