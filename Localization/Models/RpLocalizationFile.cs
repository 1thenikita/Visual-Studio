namespace DiscordRPforVS.Localization.Models
{
    using System.Collections.Generic;

    public abstract class RpLocalizationFile : ILocalizationFile
    {
        public IReadOnlyDictionary<System.String, System.String> LocalizedValues { get; protected set; }

        public System.String LanguageName { get; protected set; }

        #region Rich Presence localization fields
        public string Title => LocalizedValues["title"];
        public string IsPresenceEnabled => LocalizedValues["is_presence_enabled"];
        public string IsFileNameShown => LocalizedValues["is_filename_shown"];
        public string IsSolutionNameShown => LocalizedValues["is_solution_name_shown"];
        public string IsTimestampShown => LocalizedValues["is_timestamp_shown"];
        public string IsTimestampResetEnabled => LocalizedValues["is_timestamp_reset_enabled"];
        public string IsLanguageImageLarge => LocalizedValues["is_language_image_large"];
        public string SecretMode => LocalizedValues["secret_mode"];
        public string LoadOnStartup => LocalizedValues["load_on_startup"];
        public string UseEnglish => LocalizedValues["use_english"];
        public string Settings => LocalizedValues["settings"];
        public string TextDocument => LocalizedValues["text_document"];
        public string LogDocument => LocalizedValues["log_document"];
        public string VSCTDocument => LocalizedValues["vsct_document"];
        public string Text => LocalizedValues["text"];
        public string File => LocalizedValues["file"];
        public string LogError => LocalizedValues["log_error"];
        public string PresenceDetails => LocalizedValues["presence_details"];
        public string PresenceState => LocalizedValues["presence_state"];
        public string SuppressMessage => LocalizedValues["suppress_message"];
        public string UnrecognizedExtension => LocalizedValues["unrecognized_extension"];
        public string NoFile => LocalizedValues["no_file"];
        public string Idling => LocalizedValues["idling"];
        public string Developing => LocalizedValues["developing"];
        public string AvoidSync => LocalizedValues["avoid_sync"];
        #endregion
    }
}
