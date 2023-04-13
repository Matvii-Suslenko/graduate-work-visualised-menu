using Localisation.Models;
using UnityEngine.UI;
using Localisation;
using UnityEngine;
using System;

namespace Data
{
    public class DishBehaviour : MonoBehaviour
    {
        public event Action<DishBehaviour> DishSelected;
        public event Action<DishBehaviour> DishCanceled;
        public IDishInfo DishInfo => _customDishInfo != null ? (IDishInfo)_customDishInfo :_dishInfo;

        [SerializeField]
        private Button _chooseDishButton;
        
        [SerializeField]
        private Button _cancelDishButton;
        
        [SerializeField]
        private Text _descriptionText;
        
        [SerializeField]
        private DishInfo _dishInfo;
        
        private CustomDishInfo _customDishInfo;
        
        private void Awake()
        {
            _chooseDishButton.onClick.AddListener(OnChooseButtonClicked);
            _cancelDishButton.onClick.AddListener(OnCancelButtonClicked);
            
            OnLanguageSelected(LocalisationModel.CurrentLanguage);
            LocalisationModel.LanguageSelected += OnLanguageSelected;
        }

        public void SetCustomDishInfo(CustomDishInfo customDishInfo)
        {
            _customDishInfo = customDishInfo;
            OnLanguageSelected(LocalisationModel.CurrentLanguage);
        }

        private void OnLanguageSelected(Language language)
        {
            var description = language switch
            {
                Language.Ukrainian => DishInfo.Name != null ? DishInfo.Name._ukrainianName : string.Empty,
                Language.English => DishInfo.Name != null ? DishInfo.Name._englishName : string.Empty,
                _ => string.Empty
            };

            description += $"\n {DishInfo.Price} {LocalisationModel.CurrencyKeyword}";
            _descriptionText.text = description;
        }

        public void SetCancelVisible(bool isVisible)
        {
            _cancelDishButton.gameObject.SetActive(isVisible);
        }

        private void OnChooseButtonClicked() => DishSelected?.Invoke(this);
        private void OnCancelButtonClicked() => DishCanceled?.Invoke(this);

        private void OnDestroy()
        {
            _chooseDishButton.onClick.RemoveListener(OnChooseButtonClicked);
            _cancelDishButton.onClick.RemoveListener(OnCancelButtonClicked);
            LocalisationModel.LanguageSelected -= OnLanguageSelected;
        }
    }
}
