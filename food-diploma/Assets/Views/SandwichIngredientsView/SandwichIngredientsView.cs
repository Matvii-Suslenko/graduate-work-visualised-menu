using System.Collections.Generic;
using Data.Ingredients;
using UnityEngine.UI;
using UnityEngine;
using System;

namespace Views.SandwichIngredientsView
{
    public class SandwichIngredientsView : BaseView, ISandwichIngredientsView
    {
        public event Action CancelNewIngredientClicked;
        public event Action<int> IngredientSelected;
        
        public override ViewName ViewName => ViewName.SandwichIngredientsView;

        [SerializeField]
        private int _optionHeight = 390;
        
        [SerializeField]
        private Button _cancelNewIngredientButton;
        
        [SerializeField]
        private GameObject _sampleIngredient;
        
        [SerializeField]
        private RectTransform _ingredientsRoot;
        
        [SerializeField]
        private ScrollRect _scrollRect;
        
        private List<SandwichIngredientBehaviour> _ingredientBehaviours = new List<SandwichIngredientBehaviour>();
        
        private void Awake()
        {
            _cancelNewIngredientButton.onClick.AddListener(OnCancelNewIngredientClicked);
        }
        
        public override void ReceiveFocus()
        {
            base.ReceiveFocus();
            _scrollRect.horizontalNormalizedPosition = 0;
        }
        
        public void AddIngredient(int index, SandwichIngredient ingredient)
        {
            var newIngredientObject = Instantiate(_sampleIngredient, _ingredientsRoot);
            newIngredientObject.SetActive(true);
            
            var ingredientBehaviour = newIngredientObject.GetComponent<SandwichIngredientBehaviour>();
            _ingredientBehaviours.Add(ingredientBehaviour);
            ingredientBehaviour.SetSandwichIngredient(index, ingredient);
            ingredientBehaviour.IngredientSelected += OnIngredientSelected;

            _ingredientsRoot.sizeDelta = new Vector2(_ingredientsRoot.sizeDelta.x, _ingredientBehaviours.Count * _optionHeight);
            _scrollRect.verticalNormalizedPosition = 1;
        }

        private void OnIngredientSelected(int index)
        {
            IngredientSelected?.Invoke(index);
        }

        private void OnCancelNewIngredientClicked() => CancelNewIngredientClicked?.Invoke();

        private void OnDestroy()
        {
            _cancelNewIngredientButton.onClick.RemoveListener(OnCancelNewIngredientClicked);
        }
    }
}
