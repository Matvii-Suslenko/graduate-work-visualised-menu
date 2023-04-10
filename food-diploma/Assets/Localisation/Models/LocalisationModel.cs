using static UnityEngine.PlayerPrefs;
using System;

namespace Localisation.Models
{
    public static class LocalisationModel
    {
        public static event Action<Language> LanguageSelected;
        
        public static Language CurrentLanguage => HasKey(LanguageKey) ? (Language) GetInt(LanguageKey) : DefaultLanguage;
        
        public static string CurrencyKeyword
        {
            get
            {
                return CurrentLanguage switch
                {
                    Language.Ukrainian => "грн",
                    _ => "uah"
                };
            }
        }

        private const Language DefaultLanguage = Language.Ukrainian;
        private const string LanguageKey = "selected-language";
        
        public static void SelectLanguage(Language language)
        {
            SetInt(LanguageKey, (int)language);
            LanguageSelected?.Invoke(language);
        }
    }
}
