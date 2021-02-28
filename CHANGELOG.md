# Changelog

## [v5.45 (28-2-2020)
###### New design and improved translat

>_Welcome to the year 2021!_

**CHANGES**
- The new design is just a cannon!
- Added VB files.

**SQUASHED BUGS**
- Fixed an error identifying a file with the .C extension

<details>
<summary>Design</summary>
<p>
before
<p> 
  <img src="https://nothing-to-see-he.re/4wfoqY.png" />
</p>

after
<p> 
  <img src="https://i.imgur.com/ZGnPIBj.png" />
</p>
</p>
</details>

## [v5.4] (20-10-2020)
###### Added translation system + Russian language!

>_Русские теперь с вами!_

**CHANGES**
- Added translation system.
- Added Russian language.

## [v5.3] (25-6-2019)
###### The optimization update.

>_FAST AS FUCK!_

**CHANGES**
- Huge optimizations.
- Added license, and changelog to installer and more info url.
- Made changelog more excited. 

>_WEW!_

**SQUASHED BUGS**
- Fixed wrong icon when idling.
- Fixed icon staying on secret mode.
- Timestamp resetting when enabled if changed to a window with no document.
- Fixed CMake shown as text document.

<details>
<summary>Code change</summary>
<p>
before

```csharp
string[] key = null;
foreach (string[] langkey in Languages.Keys)
    if (Array.IndexOf(langkey, document != null ? Path.GetExtension(document.FullName).ToLower() : string.Empty) > -1 || Array.IndexOf(langkey, Path.GetFileName(document != null ? document.FullName : string.Empty)) > -1)
        key = langkey;

bool supported = key != null && Languages.ContainsKey(key);
Assets = new Assets()
{
    LargeImageKey = Settings.largeLanguage ? supported ? Languages[key][0] : "text" : ideVersionProperties[1],
    LargeImageText = Settings.largeLanguage ? supported ? Languages[key][1] : "Unknown document type" : $"Visual Studio {ideVersionProperties[1]}",
    SmallImageKey = Settings.largeLanguage ? ideVersionProperties[0] : supported ? Languages[key][0] : "text",
    SmallImageText = Settings.largeLanguage ? $"Visual Studio {ideVersionProperties[1]}" : supported ? Languages[key][1] : "Unknown document type"
};
```
after

```csharp
string[] language = new string[] { };
if (document != null)
{
    string filename = Path.GetFileName(document.FullName).ToLower();
    string ext = Path.GetExtension(filename);
    List<KeyValuePair<string[], string[]>> list = Languages.Where(lang => Array.IndexOf(lang.Key, filename) > -1 || Array.IndexOf(lang.Key, ext) > -1).ToList();
    language = list.Count > 0 ? list[0].Value : new string[] { };
}

bool supported = language.Length > 0;
Assets = new Assets()
{
    LargeImageKey = Settings.largeLanguage ? supported ? language[0] : "text" : $"vs{ideVersion}",
    LargeImageText = Settings.largeLanguage ? supported ? language[1] : "Unrecognized extension" : $"Visual Studio {ideVersion}",
    SmallImageKey = Settings.largeLanguage ? $"vs{ideVersion}" : supported ? language[0] : "text",
    SmallImageText = Settings.largeLanguage ? $"Visual Studio {ideVersion}" : supported ? language[1] : "Unrecognized extension"
};
```
</p>
</details>

## [v5.2] (24-6-2019)
###### The secret update.

>_STOP HIDING YOUR SECRETS!_

**CHANGES**
- Better perfomance.
- Added secret mode.
- Added load on startup toggle.

## [v5.1.2] (24-6-2019)
###### Bug fixes.

>_WHOOPS!_

**SQUASHED BUGS**
- Fixed reverse order of state and details.
- Fixed full path of solution to state.

## [v5.1.1] (23-6-2019)
###### Bug fixes.

>_WHOOPS! HOW DID THAT HAPPEN?_

**SQUASHED BUGS**
- Fixed file name not shown.

## [v5.1] (23-6-2019)
###### The proper update.

>_SQUACKY CLEAN!_

**CHANGES**
- Code cleanup.
- Proper activity log logging.
- Added Rust, TOML and Lua.
- Fixed icons being cut off.

>_UH OH!_

**SQUASHED BUGS**
- Fixed extension crashing on Visual Studio 2017.

## [v5] (6-6-2019)
###### The formatting update.

>_FANTASTIC!_

**CHANGES**
- Added language formatting, proper name will be shown as text.
- Code cleanup.
- Text document icon will now display instead of Visual Studio icon when editing a file that is not supported.

>_HOW DID THAT HAPPEN?_

**SQUASHED BUGS**
- Visual Studio crashes on disable.

## [v4.14] (1-6-2019)
###### The sharp update.

>_RAZOR SHARP!_

**CHANGES**
- Added cshtml and razor file types.

## [v4] (18-5-2019)
###### The rewrite: end game.

>_GOOD BYE DEPRECATED SHIT!_

**CHANGES**
- Now using lachee's [Discord Rich Presence library](https://github.com/lachee/discord-rpc-csharp)!
- New improved icons.
- More file types.
- Optimized code.

## [v3.1] (15-5-2019)
###### The fixes update.

>_MHM_

**SQUASHED BUGS**
- Rich Presence timestamp will reset on settings change.

## [v3] (14-5-2019)
###### The rewrite.

>_REWRITEN BETTER!_

**CHANGES**
- New settings window, for faster settings change.
- Project now initializes the rich presence for the current document on startup.
- Removed unnessesary assigning of null presence on startup.
- Added icon.
- Better presence icons.

>_YEET_

**SQUASHED BUGS**
- Rich Presence will stop working after switching to a non-editor window.