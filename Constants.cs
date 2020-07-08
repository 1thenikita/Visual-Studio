namespace DiscordRPforVS
{
    using System;
    using System.Collections.Generic;

    public static class Constants
    {
        public static readonly Dictionary<String[], String[]> Languages = new Dictionary<String[], String[]>
        {
            { new String[] { ".H", ".CC", ".HH", ".CPP", ".IPP", ".INL", ".C++", ".H++", ".HPP" }, new String[] { "cpp", "C++" } },
            { new String[] { ".GO" }, new String[] { "go", "GO" } },
            { new String[] { ".PHP" }, new String[] { "php", "PHP" } },
            { new String[] { ".C" }, new String[] { "c", "C" } },
            { new String[] { ".RB", ".rbw" }, new String[] { "ruby", "Ruby" } },
            { new String[] { ".CS" }, new String[] { "csharp", "C#" } },
            { new String[] { ".FS", ".FSI", ".FSX", ".FSSCRIPT" }, new String[] { "fsharp", "F#" } },
            { new String[] { ".TS" }, new String[] { "typescript", "Typescript" } },
            { new String[] { ".CLASS", ".JAVA" }, new String[] { "java", "Java" } },
            { new String[] { ".TXT" }, new String[] { "text", "Text document" } },
            { new String[] { ".JSON" }, new String[] { "json", "JSON" } },
            { new String[] { ".PY", ".PYW", ".PYI", ".PYX" }, new String[] { "python", "Python" } },
            { new String[] { ".CSS" }, new String[] { "css", "CSS" } },
            { new String[] { ".SCSS", ".SASS" }, new String[] { "sass", "SASS" } },
            { new String[] { ".LESS" }, new String[] { "less", "LESS" } },
            { new String[] { ".HTML" }, new String[] { "html", "Html" } },
            { new String[] { ".JS" }, new String[] { "javascript", "Javascript" } },
            { new String[] { "CMAKELISTS.TXT", "CMAKECACHE.TXT" }, new String[] { "cmake", "CMake" } },
            { new String[] { ".MD", ".MARKDOWN" }, new String[] { "markdown", "Markdown" } },
            { new String[] { ".XML" }, new String[] { "xml", "XML" } },
            { new String[] { ".XAML" }, new String[] { "xaml", "XAML" } },
            { new String[]{ ".CSHTML", ".RAZOR" }, new String[] { "cshtml", "CSHtml" } },
            { new String[]{ ".RS" }, new String[] { "rust", "Rust" } },
            { new String[]{ ".TOML" }, new String[] { "toml", "TOML" } },
            { new String[]{ ".LUA" }, new String[] { "lua", "Lua" } }
        };
        public static readonly Dictionary<Int32, String> IdeVersions = new Dictionary<Int32, String>
        {
            { 15, "2017" },
            { 16, "2019" }
        };
    }
}
