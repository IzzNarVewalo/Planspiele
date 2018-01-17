using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Translation {

    string[] languages = new string[] { "en" };
    
    static LanguageFile _languageFile;

    static string _notFoundPlaceholder = "[Translation missing]";

	static Translation()
    {

    }

    public static void Test()
    {
        LanguageFile l = LanguageFile.Create("en", "English");
        l.Save();
    }

    public static bool LoadLanguage(string language)
    {
        LanguageFile loaded = LanguageFile.Load(language);
        if (loaded != null)
        {
            _languageFile = loaded;
            return true;
        }
        else
        {
            Debug.LogError("Language could not be loaded: " + language);
            return false;
        }   
    }

    public static string Get(string key)
    {
        string translation;
        if (_languageFile == null || !_languageFile.translations.TryGetValue(key, out translation))
            return _notFoundPlaceholder;

        return translation;
    }

}
