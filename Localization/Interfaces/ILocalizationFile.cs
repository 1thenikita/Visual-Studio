namespace DiscordRPforVS
{
    using System.Collections.Generic;

    public interface ILocalizationFile
    {
        string LanguageName { get; }
        IReadOnlyDictionary<string, string> LocalizedValues { get; }
    }
}
