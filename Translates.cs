using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRPforVS
{
    /// <summary>
    /// Class work with the translation
    /// </summary>
    public static class Translates
    {
        /// <summary>
        /// Class work with the translation in SettingsWindow
        /// </summary>
        public static class SettingsWindow
        {
            /// <summary>
            /// Translation handler for the IsPresenceEnabled variable
            /// </summary>
            /// <param name="translate">Language</param>
            /// <returns>IsPresenceEnabled in the desired language</returns>
            public static string IsPresenceEnabled(string translate)
            {
                if (translate == "enUS") { return "Enable Discord Rich Presence"; }
                else if (translate == "ruRU") { return "Включить"; }
                else { return "Enable Discord Rich Presence"; }
            }

            /// <summary>
            /// Translation handler for the IsFileNameShown variable
            /// </summary>
            /// <param name="translate">Language</param>
            /// <returns>IsFileNameShown in the desired language</returns>
            public static string IsFileNameShown(string translate)
            {
                if (translate == "enUS") { return "Show file name"; }
                else if (translate == "ruRU") { return "Показывать имя файла"; }
                else { return "Show file name"; }
            }

            /// <summary>
            /// Translation handler for the IsSolutionNameShown variable
            /// </summary>
            /// <param name="translate">Language</param>
            /// <returns>IsSolutionNameShown in the desired language</returns>
            public static string IsSolutionNameShown(string translate)
            {
                if (translate == "enUS") { return "Show solution name"; }
                else if (translate == "ruRU") { return "Показывать расширение файла"; }
                else { return "Show solution name"; }
            }

            /// <summary>
            /// Translation handler for the IsTimestampShown variable
            /// </summary>
            /// <param name="translate">Language</param>
            /// <returns>IsTimestampShown in the desired language</returns>
            public static string IsTimestampShown(string translate)
            {
                if (translate == "enUS") { return "Show timestamp"; }
                else if (translate == "ruRU") { return "Показывать время работы"; }
                else { return "Show timestamp"; }
            }

            /// <summary>
            /// Translation handler for the IsTimestampResetEnabled variable
            /// </summary>
            /// <param name="translate">Language</param>
            /// <returns>IsTimestampResetEnabled in the desired language</returns>
            public static string IsTimestampResetEnabled(string translate)
            {
                if (translate == "enUS") { return "Reset timestamp on file change"; }
                else if (translate == "ruRU") { return "Обнулить время работы и название файла"; }
                else { return "Reset timestamp on file change"; }
            }

            /// <summary>
            /// Translation handler for the IsLanguageImageLarge variable
            /// </summary>
            /// <param name="translate">Language</param>
            /// <returns>IsLanguageImageLarge in the desired language</returns>
            public static string IsLanguageImageLarge(string translate)
            {
                if (translate == "enUS") { return "Large language image"; }
                else if (translate == "ruRU") { return "Уменьшенная картинка языка программирования"; }
                else { return "Large language image"; }
            }

            /// <summary>
            /// Translation handler for the SecretMode variable
            /// </summary>
            /// <param name="translate">Language</param>
            /// <returns>SecretMode in the desired language</returns>
            public static string SecretMode(string translate)
            {
                if (translate == "enUS") { return "Secret mode"; }
                else if (translate == "ruRU") { return "Секретный режим"; }
                else { return "Secret mode"; }
            }

            /// <summary>
            /// Translation handler for the LoadOnStartup variable
            /// </summary>
            /// <param name="translate">Language</param>
            /// <returns>LoadOnStartup in the desired language</returns>
            public static string LoadOnStartup(string translate)
            {
                if (translate == "enUS") { return "Load on startup"; }
                else if (translate == "ruRU") { return "Автоматический запуск"; }
                else { return "Load on startup"; }
            }

            /// <summary>
            /// Translation handler for the SaveButton variable
            /// </summary>
            /// <param name="translate">Language</param>
            /// <returns>SaveButton in the desired language</returns>
            public static string SaveButton(string translate)
            {
                if (translate == "enUS") { return "Save and Close"; }
                else if (translate == "ruRU") { return "Сохранить и закрыть"; }
                else { return "Save and Close"; }
            }
        }

        /// <summary>
        /// Translation handler for the Settings variable
        /// </summary>
        /// <param name="translate">Language</param>
        /// <returns>Settings in the desired language</returns>
        public static string Settings(string translate)
        {
            if (translate == "enUS") { return "Settings"; }
            else if (translate == "ruRU") { return "Настройки"; }
            else { return "Settings"; }
        }

        /// <summary>
        /// Translation handler for the TextDocument variable
        /// </summary>
        /// <param name="translate">Language</param>
        /// <returns>TextDocument in the desired language</returns>
        public static string TextDocument(string translate)
        {
            if(translate == "enUS") { return "Text document"; }
            else if(translate == "ruRU") { return "Текстовый документ"; }
            else { return "Text document"; }
        }

        /// <summary>
        /// Translation handler for the Text variable
        /// </summary>
        /// <param name="translate">Language</param>
        /// <returns>Text in the desired language</returns>
        public static string Text(string translate)
        {
            if (translate == "enUS") { return "text"; }
            else if (translate == "ruRU") { return "текст"; }
            else { return "text"; }
        }

        /// <summary>
        /// Translation handler for the File variable
        /// </summary>
        /// <param name="translate">Language</param>
        /// <returns>File in the desired language</returns>
        public static string File(string translate)
        {
            if (translate == "enUS") { return "file"; }
            else if (translate == "ruRU") { return "файл"; }
            else { return "file"; }
        }

        /// <summary>
        /// Translation handler for the LogError variable
        /// </summary>
        /// <param name="translate">Language</param>
        /// <returns>LogError in the desired language</returns>
        public static string LogError(string translate)
        {
            if (translate == "enUS") { return "Could not start RP"; }
            else if (translate == "ruRU") { return "Не удалось запустить RP"; }
            else { return "Could not start RP"; }
        }

        /// <summary>
        /// Translation handler for the Presence_Details variable
        /// </summary>
        /// <param name="translate">Language</param>
        /// <returns>Presence_Details in the desired language</returns>
        public static string Presence_Details(string translate)
        {
            if (translate == "enUS") { return "I'm working on something you're"; }
            else if (translate == "ruRU") { return "Я работаю над тем, о чем"; }
            else { return "I'm working on something you're"; }
        }

        /// <summary>
        /// Translation handler for the Presence_State variable
        /// </summary>
        /// <param name="translate">Language</param>
        /// <returns>Presence_State in the desired language</returns>
        public static string Presence_State(string translate)
        {
            if (translate == "enUS") { return "not allowed to know about, sorry."; }
            else if (translate == "ruRU") { return "тебе не положено знать, извини."; }
            else { return "not allowed to know about, sorry."; }
        }

        /// <summary>
        /// Translation handler for the SuppressMessage variable
        /// </summary>
        /// <param name="translate">Language</param>
        /// <returns>SuppressMessage in the desired language</returns>
        public static string SuppressMessage(string translate)
        {
            if (translate == "enUS") { return "Async void return type required"; }
            if (translate == "ruRU") { return "Требуется тип возвращаемого значения Async void"; }
            else { return "Async void return type required"; }
        }

        /// <summary>
        /// Translation handler for the UnrecognizedExtension variable
        /// </summary>
        /// <param name="translate">Language</param>
        /// <returns>UnrecognizedExtension in the desired language</returns>
        public static string UnrecognizedExtension(string translate)
        {
            if (translate == "enUS") { return "Unrecognized extension"; }
            if (translate == "ruRU") { return "Незарегистрированное расширение"; }
            else { return "Unrecognized extension"; }
        }

        /// <summary>
        /// Translation handler for the NoFile variable
        /// </summary>
        /// <param name="translate">Language</param>
        /// <returns>NoFile in the desired language</returns>
        public static string NoFile(string translate)
        {
            if (translate == "enUS") { return "No File."; }
            if (translate == "ruRU") { return "Файл не выбран."; }
            else { return "No File."; }
        }

        /// <summary>
        /// Translation handler for the Idling variable
        /// </summary>
        /// <param name="translate">Language</param>
        /// <returns>Idling in the desired language</returns>
        public static string Idling(string translate)
        {
            if (translate == "enUS") { return "Idling"; }
            if (translate == "ruRU") { return "Выбирает проект"; }
            else { return "Idling"; }
        }

        /// <summary>
        /// Translation handler for the Developing variable
        /// </summary>
        /// <param name="translate">Language</param>
        /// <returns>Developing in the desired language</returns>
        public static string Developing(string translate)
        {
            if (translate == "enUS") { return "Developing"; }
            if (translate == "ruRU") { return "Работает в проекте"; }
            else { return "Idling"; }
        }

        /// <summary>
        /// Translation handler for the AvoidSync variable
        /// </summary>
        /// <param name="translate">Language</param>
        /// <returns>AvoidSync in the desired language</returns>
        public static string AvoidSync(string translate)
        {
            if (translate == "enUS") { return "Async void return type required"; }
            if (translate == "ruRU") { return "Требуется тип возвращаемого значения Async void"; }
            else { return "Async void return type required"; }
        }
    }
}
