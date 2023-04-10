using Localisation.Models;
using UnityEngine.UI;
using UnityEngine;

namespace Localisation
{
    [RequireComponent(typeof(Button))]
    public class LanguageSelector : MonoBehaviour
    {
        [SerializeField] private Language _language;
        private Button _button;
            
        private void Start()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnButtonClicked);
        }

        private void OnButtonClicked()
        {
            LocalisationModel.SelectLanguage(_language);
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveListener(OnButtonClicked);
        }
    }
}
