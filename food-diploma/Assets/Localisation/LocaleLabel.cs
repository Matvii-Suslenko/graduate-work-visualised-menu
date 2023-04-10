using Localisation.Models;
using UnityEngine.UI;
using UnityEngine;

namespace Localisation
{
    [RequireComponent(typeof(Text))]
    public class LocaleLabel : MonoBehaviour
    {
        [SerializeField] private string _ukrainianVariant;
        [SerializeField] private string _englishVariant;
        private Text _textComponent;
        
        private void Start()
        {
            _textComponent = GetComponent<Text>();
            OnLanguageSelected(LocalisationModel.CurrentLanguage);
            LocalisationModel.LanguageSelected += OnLanguageSelected;
        }

        private void OnLanguageSelected(Language language)
        {
            switch (language)
            {
                case Language.Ukrainian :
                    _textComponent.text = _ukrainianVariant;
                    break;
               case Language.English :
                   _textComponent.text = _englishVariant;
                   break;
            }
        }

        private void OnDestroy()
        {
            LocalisationModel.LanguageSelected -= OnLanguageSelected;
        }
    }
}
