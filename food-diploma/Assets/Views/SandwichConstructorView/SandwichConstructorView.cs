using Views.SandwichConstructorView;
using System.Collections.Generic;
using Localisation.Models;
using Data.Ingredients;
using UnityEngine.UI;
using Localisation;
using UnityEngine;
using System.Linq;
using System;

namespace Views.MenuView
{
    public class SandwichConstructorView : BaseView, ISandwichConstructorView
    {
        public event Action RemoveLastIngredientClicked;
        public event Action AddNewIngredientClicked;
        public event Action CancelSandwichClicked;
        public event Action AddSandwichClicked;
        
        public override ViewName ViewName => ViewName.SandwichConstructor;
        
        [SerializeField]
        private Button _cancelSandwichButton;
        
        [SerializeField]
        private Button _addSandwichButton;
        
        [SerializeField]
        private Button _addIngredientButton;
        
        [SerializeField]
        private Button _removeIngredientButton;

        [SerializeField]
        private Text _descriptionText;

        [SerializeField]
        private Transform _sandwichRoot;

        private float _currentHeight = 0;
        private float _totalWeight = 0;
        private float _calories = 0;
        private int _totalPrice = 0;

        private readonly List<KeyValuePair<float, GameObject>> _ingredientAssets = new List<KeyValuePair<float, GameObject>>();

        private void Awake()
        {
            _addSandwichButton.onClick.AddListener(OnAddSandwichClicked);
            _cancelSandwichButton.onClick.AddListener(OnCancelSandwichClicked);
            _addIngredientButton.onClick.AddListener(OnAddIngredientButtonClicked);
            _removeIngredientButton.onClick.AddListener(OnRemoveIngredientButtonClicked);
            LocalisationModel.LanguageSelected += OnLanguageChanged;
            _addSandwichButton.interactable = false;
        }
        
        public override void ReceiveFocus()
        {
            base.ReceiveFocus();
            OnLanguageChanged(LocalisationModel.CurrentLanguage);
        }
        
        public void AddIngredient(int index, SandwichIngredient ingredient)
        {
            _currentHeight += ingredient.Height;
            var newIngredient = Instantiate(ingredient.IngredientAsset, _sandwichRoot);
            newIngredient.transform.position = _sandwichRoot.transform.position + (Vector3.up * _currentHeight);
            _ingredientAssets.Add(new KeyValuePair<float, GameObject>(ingredient.Height, newIngredient));
        }

        public void RemoveLastIngredient()
        {
            if (!_ingredientAssets.Any())
            {
                return;
            }
            
            var lastIngredient = _ingredientAssets.Last();
            _ingredientAssets.Remove(lastIngredient);
            _currentHeight -= lastIngredient.Key;
            Destroy(lastIngredient.Value);
        }

        public void ClearSandwich()
        {
            foreach (var ingredientAsset in _ingredientAssets)
            {
                Destroy(ingredientAsset.Value);
            }

            _currentHeight = 0;
            _ingredientAssets.Clear();
        }

        public void SetDescriptionValues(float calories, float weight, int price)
        {
            _totalWeight = weight;
            _calories = calories;
            _totalPrice = price;
            
            OnLanguageChanged(LocalisationModel.CurrentLanguage);
        }

        public void SetAddSandwichButtonVisible(bool isVisible)
        {
            _addSandwichButton.interactable = isVisible;
        }

        private void OnLanguageChanged(Language language)
        {
            if (_totalWeight == 0 || _calories == 0 || _totalPrice == 0)
            {
                _descriptionText.text = string.Empty;
                return;
            }
            
            switch (LocalisationModel.CurrentLanguage)
            {
                case Language.Ukrainian :
                    _descriptionText.text = $"Ціна: {_totalPrice} грн \nЕнергія: {_calories} кКал \nВага: {_totalWeight} г";
                    break;
                case Language.English :
                    _descriptionText.text = $"Price: {_totalPrice} uah \nCalories: {_calories} kCal \nWeight: {_totalWeight} g";
                    break;
            }
        }

        private void OnAddSandwichClicked() => AddSandwichClicked?.Invoke();
        private void OnCancelSandwichClicked() => CancelSandwichClicked?.Invoke();
        private void OnAddIngredientButtonClicked() => AddNewIngredientClicked?.Invoke();
        private void OnRemoveIngredientButtonClicked() => RemoveLastIngredientClicked?.Invoke();

        private void OnDestroy()
        {
            _addSandwichButton.onClick.RemoveListener(OnAddSandwichClicked);
            _cancelSandwichButton.onClick.RemoveListener(OnCancelSandwichClicked);
            _addIngredientButton.onClick.RemoveListener(OnAddIngredientButtonClicked);
            _removeIngredientButton.onClick.RemoveListener(OnRemoveIngredientButtonClicked);
            LocalisationModel.LanguageSelected -= OnLanguageChanged;
        }
    }
}
