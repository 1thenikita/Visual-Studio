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
            /// Translation handler for the Title variable
            /// </summary>
            /// <param name="translate">Language</param>
            /// <returns>Title in the desired language</returns>
            public static string Title(string translate)
            {
                if (translate == "en-US") { return "Discord Rich Presence Settings"; }
                else if (translate == "ru-RU") { return "Discord Rich Presence настройки"; }
                else if (translate == "hu-HU") { return "Discord Rich Presence beállítások"; }
                else if (translate == "pl-PL") { return "Ustawienia Discord Rich Presence"; }
                else { return "Discord Rich Presence Settings"; }
            }

            /// <summary>
            /// Translation handler for the IsPresenceEnabled variable
            /// </summary>
            /// <param name="translate">Language</param>
            /// <returns>IsPresenceEnabled in the desired language</returns>
            public static string IsPresenceEnabled(string translate)
            {
                if (translate == "en-US") { return "Enable Discord Rich Presence"; }
                else if (translate == "ru-RU") { return "Включить"; }
                else if (translate == "hu-HU") { return "Discord Rich Presence engedélyezése"; }
                else if (translate == "pl-PL") { return "Włącz Discord Rich Presence"; }
                else { return "Enable Discord Rich Presence"; }
            }

            /// <summary>
            /// Translation handler for the IsFileNameShown variable
            /// </summary>
            /// <param name="translate">Language</param>
            /// <returns>IsFileNameShown in the desired language</returns>
            public static string IsFileNameShown(string translate)
            {
                if (translate == "en-US") { return "Show file name"; }
                else if (translate == "ru-RU") { return "Показывать имя файла"; }
                else if (translate == "hu-HU") { return "Fájlnév megjelenítése"; }
                else if (translate == "pl-PL") { return "Pokazuj nazwę pliku"; }
                else { return "Show file name"; }
            }

            /// <summary>
            /// Translation handler for the IsSolutionNameShown variable
            /// </summary>
            /// <param name="translate">Language</param>
            /// <returns>IsSolutionNameShown in the desired language</returns>
            public static string IsSolutionNameShown(string translate)
            {
                if (translate == "en-US") { return "Show solution name"; }
                else if (translate == "ru-RU") { return "Показывать имя проекта"; }
                else if (translate == "hu-HU") { return "Projekt nevének megjelenítése"; }
                else if (translate == "pl-PL") { return "Pokazuj nazwę rozwiązania"; }
                else { return "Show solution name"; }
            }

            /// <summary>
            /// Translation handler for the IsTimestampShown variable
            /// </summary>
            /// <param name="translate">Language</param>
            /// <returns>IsTimestampShown in the desired language</returns>
            public static string IsTimestampShown(string translate)
            {
                if (translate == "en-US") { return "Show timestamp"; }
                else if (translate == "ru-RU") { return "Показывать время работы"; }
                else if (translate == "hu-HU") { return "Időbélyeg megjelenítése"; }
                else if (translate == "pl-PL") { return "Pokazuj czas pracy"; }
                else { return "Show timestamp"; }
            }

            /// <summary>
            /// Translation handler for the IsTimestampResetEnabled variable
            /// </summary>
            /// <param name="translate">Language</param>
            /// <returns>IsTimestampResetEnabled in the desired language</returns>
            public static string IsTimestampResetEnabled(string translate)
            {
                if (translate == "en-US") { return "Reset timestamp on file change"; }
                else if (translate == "ru-RU") { return "Перезапускать таймер при изменении файла"; }
                else if (translate == "hu-HU") { return "Időbélyeg visszaállítása fájl módosításkor"; }
                else if (translate == "pl-PL") { return "Resetuj czas pracy co zmianę pliku"; }
                else { return "Reset timestamp on file change"; }
            }

            /// <summary>
            /// Translation handler for the IsLanguageImageLarge variable
            /// </summary>
            /// <param name="translate">Language</param>
            /// <returns>IsLanguageImageLarge in the desired language</returns>
            public static string IsLanguageImageLarge(string translate)
            {
                if (translate == "en-US") { return "Large language image"; }
                else if (translate == "ru-RU") { return "Большая картинка языка программирования"; }
                else if (translate == "hu-HU") { return "Nagy nyelv kép"; }
                else if (translate == "pl-PL") { return "Duży obraz języka programowania"; }
                else { return "Large language image"; }
            }

            /// <summary>
            /// Translation handler for the SecretMode variable
            /// </summary>
            /// <param name="translate">Language</param>
            /// <returns>SecretMode in the desired language</returns>
            public static string SecretMode(string translate)
            {
                if (translate == "en-US") { return "Secret mode"; }
                else if (translate == "ru-RU") { return "Секретный режим"; }
                else if (translate == "hu-HU") { return "Titkos mód"; }
                else if (translate == "pl-PL") { return "Tryb tajny"; }
                else { return "Secret mode"; }
            }

            /// <summary>
            /// Translation handler for the LoadOnStartup variable
            /// </summary>
            /// <param name="translate">Language</param>
            /// <returns>LoadOnStartup in the desired language</returns>
            public static string LoadOnStartup(string translate)
            {
                if (translate == "en-US") { return "Load on startup"; }
                else if (translate == "ru-RU") { return "Автоматический запуск"; }
                else if (translate == "hu-HU") { return "Automatikus indítás"; }
                else if (translate == "pl-PL") { return "Automatyczny start"; }
                else { return "Load on startup"; }
            }

            /// <summary>
            /// Translation handler for the UseEnglish variable
            /// </summary>
            /// <param name="translate">Language</param>
            /// <returns>UseEnglish in the desired language</returns>
            public static string UseEnglish(string translate)
            {
                if (translate == "en-US") { return "Use English language"; }
                else if (translate == "ru-RU") { return "Использовать Английский язык"; }
                else if (translate == "hu-HU") { return "Angol nyelv használata"; }
                else if (translate == "pl-PL") { return "Używanie języka angielskiego"; }
                else { return "Use English language"; }
            }
        }

        /// <summary>
        /// Translation handler for the Settings variable
        /// </summary>
        /// <param name="translate">Language</param>
        /// <returns>Settings in the desired language</returns>
        public static string Settings(string translate)
        {
            if (translate == "en-US") { return "Settings"; }
            else if (translate == "ru-RU") { return "Настройки"; }
            else if (translate == "hu-HU") { return "Beállítások"; }
            else if (translate == "pl-PL") { return "Ustawienia"; }
            else { return "Settings"; }
        }

        /// <summary>
        /// Translation handler for the TextDocument variable
        /// </summary>
        /// <param name="translate">Language</param>
        /// <returns>TextDocument in the desired language</returns>
        public static string TextDocument(string translate)
        {
            if(translate == "en-US") { return "Text"; }
            else if(translate == "ru-RU") { return "Текстовый"; }
            else if(translate == "hu-HU") { return "Szövegfájl"; }
            else if (translate == "pl-PL") { return "Tekstowy"; }
            else { return "Text"; }
        }

        /// <summary>
        /// Translation handler for the LogDocument variable
        /// </summary>
        /// <param name="translate">Language</param>
        /// <returns>LogDocument in the desired language</returns>
        public static string LogDocument(string translate)
        {
            if (translate == "en-US") { return "Log"; }
            else if (translate == "ru-RU") { return "Log"; }
            else if (translate == "hu-HU") { return "Log fájl"; }
            else if (translate == "pl-PL") { return "Dziennik"; }
            else { return "Log"; }
        }

        /// <summary>
        /// Translation handler for the VSCTDocument variable
        /// </summary>
        /// <param name="translate">Language</param>
        /// <returns>VSCTDocument in the desired language</returns>
        public static string VSCTDocument(string translate)
        {
            if (translate == "en-US") { return "VS Command Table Configuration"; }
            else if (translate == "ru-RU") { return "VS Настройка командной таблицы"; }
            else if (translate == "hu-HU") { return "VS parancs tábla beállítása"; }
            else if (translate == "pl-PL") { return "Konfiguracja Tablicy Komend VS"; }
            else { return "Log"; }
        }

        /// <summary>
        /// Translation handler for the Text variable
        /// </summary>
        /// <param name="translate">Language</param>
        /// <returns>Text in the desired language</returns>
        public static string Text(string translate)
        {
            if (translate == "en-US") { return "text"; }
            else if (translate == "ru-RU") { return "текст"; }
            else if (translate == "hu-HU") { return "szöveg"; }
            else if (translate == "pl-PL") { return "tekst"; }
            else { return "text"; }
        }

        /// <summary>
        /// Translation handler for the File variable
        /// </summary>
        /// <param name="translate">Language</param>
        /// <returns>File in the desired language</returns>
        public static string File(string translate)
        {
            if (translate == "en-US") { return "file"; }
            else if (translate == "ru-RU") { return "файл"; }
            else if (translate == "hu-HU") { return "fájl"; }
            else if (translate == "pl-PL") { return "plik"; }
            else { return "file"; }
        }

        /// <summary>
        /// Translation handler for the LogError variable
        /// </summary>
        /// <param name="translate">Language</param>
        /// <returns>LogError in the desired language</returns>
        public static string LogError(string translate)
        {
            if (translate == "en-US") { return "Could not start RP"; }
            else if (translate == "ru-RU") { return "Не удалось запустить RP"; }
            else if (translate == "hu-HU") { return "Nem sikerült elindítani az RP-t"; }
            else if (translate == "pl-PL") { return "Nie udało się uruchomić RP"; }
            else { return "Could not start RP"; }
        }

        /// <summary>
        /// Translation handler for the Presence_Details variable
        /// </summary>
        /// <param name="translate">Language</param>
        /// <returns>Presence_Details in the desired language</returns>
        public static string PresenceDetails(string translate)
        {
            if (translate == "en-US") { return "I'm working on something you're"; }
            else if (translate == "ru-RU") { return "Я работаю над тем, о чем"; }
            else if (translate == "hu-HU") { return "Egy olyan projekten dolgozom,"; }
            else if (translate == "pl-PL") { return "Pracuję nad czymś, o czym"; }
            else { return "I'm working on something you're"; }
        }

        /// <summary>
        /// Translation handler for the Presence_State variable
        /// </summary>
        /// <param name="translate">Language</param>
        /// <returns>Presence_State in the desired language</returns>
        public static string PresenceState(string translate)
        {
            if (translate == "en-US") { return "not allowed to know about, sorry."; }
            else if (translate == "ru-RU") { return "тебе не положено знать, извини."; }
            else if (translate == "hu-HU") { return "amit nem láthatsz, sajnálom."; }
            else if (translate == "pl-PL") { return "nie możesz wiedzieć, sorry."; }
            else { return "not allowed to know about, sorry."; }
        }

        /// <summary>
        /// Translation handler for the SuppressMessage variable
        /// </summary>
        /// <param name="translate">Language</param>
        /// <returns>SuppressMessage in the desired language</returns>
        public static string SuppressMessage(string translate)
        {
            if (translate == "en-US") { return "Async void return type required"; }
            if (translate == "ru-RU") { return "Требуется тип возвращаемого значения Async void"; }
            if (translate == "hu-HU") { return "Async void visszatérési érték szükséges"; }
            if (translate == "pl-PL") { return "Zwracana wartość musi być typu Async void"; }
            else { return "Async void return type required"; }
        }

        /// <summary>
        /// Translation handler for the UnrecognizedExtension variable
        /// </summary>
        /// <param name="translate">Language</param>
        /// <returns>UnrecognizedExtension in the desired language</returns>
        public static string UnrecognizedExtension(string translate)
        {
            if (translate == "en-US") { return "Unrecognized extension"; }
            if (translate == "ru-RU") { return "Незарегистрированное расширение"; }
            if (translate == "hu-HU") { return "Ismeretlen bővítmény"; }
            if (translate == "pl-PL") { return "Nierozpoznane rozszerzenie"; }
            else { return "Unrecognized extension"; }
        }

        /// <summary>
        /// Translation handler for the NoFile variable
        /// </summary>
        /// <param name="translate">Language</param>
        /// <returns>NoFile in the desired language</returns>
        public static string NoFile(string translate)
        {
            if (translate == "en-US") { return "No File."; }
            if (translate == "ru-RU") { return "Файл не выбран."; }
            if (translate == "hu-HU") { return "Nincs fájl."; }
            if (translate == "pl-PL") { return "Nie wybrano pliku."; }
            else { return "No File."; }
        }

        /// <summary>
        /// Translation handler for the Idling variable
        /// </summary>
        /// <param name="translate">Language</param>
        /// <returns>Idling in the desired language</returns>
        public static string Idling(string translate)
        {
            if (translate == "en-US") { return "Idling"; }
            if (translate == "ru-RU") { return "Выбирает проект"; }
            if (translate == "hu-HU") { return "Üresjárat"; }
            if (translate == "pl-PL") { return "Bezczynność"; }
            else { return "Idling"; }
        }

        /// <summary>
        /// Translation handler for the Developing variable
        /// </summary>
        /// <param name="translate">Language</param>
        /// <returns>Developing in the desired language</returns>
        public static string Developing(string translate)
        {
            if (translate == "en-US") { return "Developing"; }
            if (translate == "ru-RU") { return "Работает в проекте"; }
            if (translate == "hu-HU") { return "Fejleszti a következő fájlt: "; }
            if (translate == "pl-PL") { return "Pracuję nad"; }
            else { return "Developing"; }
        }

        /// <summary>
        /// Translation handler for the AvoidSync variable
        /// </summary>
        /// <param name="translate">Language</param>
        /// <returns>AvoidSync in the desired language</returns>
        public static string AvoidSync(string translate)
        {
            if (translate == "en-US") { return "Async void return type required"; }
            if (translate == "ru-RU") { return "Требуется тип возвращаемого значения Async void"; }
            if (translate == "hu-HU") { return "Async visszatérési érték szükséges"; }
            if (translate == "pl-PL") { return "Zwracana wartość musi być typu Async void"; }
            else { return "Async void return type required"; }
        }
    }
}
