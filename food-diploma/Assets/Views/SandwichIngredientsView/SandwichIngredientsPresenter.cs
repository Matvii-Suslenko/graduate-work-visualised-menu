using System.Collections.Generic;
using Data.Ingredients;
using UnityEngine;
using Models;

namespace Views.SandwichIngredientsView
{
    public class  SandwichIngredientsPresenter : Presenter<ISandwichIngredientsView>
    {
        [SerializeField]
        private IngredientsModel _ingredientsModel;
        
        [SerializeField]
        private SandwichModel _sandwichModel;

        private Dictionary<int, SandwichIngredient> _ingredients;

        protected override void Awake()
        {
            base.Awake();
            View.CancelNewIngredientClicked += OnCancelNewIngredientClicked;

            var ingredients = _ingredientsModel.GetAllSandwichIngredients();

            _ingredients = new Dictionary<int, SandwichIngredient>();
            for (var i = 0; i < ingredients.Count; i++)
            {
                _ingredients.Add(i, ingredients[i]);
                View.AddIngredient(i, _ingredients[i]);
            }
            
            View.IngredientSelected += OnIngredientSelected;
        }

        private void OnIngredientSelected(int index)
        {
            Debug.Log($"Ingredient is Selected: {_ingredients[index].Name._englishName}");
            _sandwichModel.AddIngredient(index, _ingredients[index]);
            _viewManager.OpenView(ViewName.SandwichConstructor);
        }

        private void OnCancelNewIngredientClicked()
        {
            _viewManager.OpenView(ViewName.SandwichConstructor);
        }

        private void OnDestroy()
        {
            View.CancelNewIngredientClicked -= OnCancelNewIngredientClicked;
            View.IngredientSelected -= OnIngredientSelected;
        }
    }
}
