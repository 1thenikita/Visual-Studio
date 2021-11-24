namespace DiscordRPforVS.Localization.Models
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.IO;

    public class JsonLocalizationFile : RpLocalizationFile
    {
        public JsonLocalizationFile(string filename)
        {
            var file = new StreamReader(filename);
            string json = file.ReadToEnd();
            file.Close();

            LocalizedValues = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            LanguageName = Path.GetFileNameWithoutExtension(filename);
        }
    }
}
