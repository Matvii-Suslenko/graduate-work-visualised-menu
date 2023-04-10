using Data.Ingredients;
using UnityEngine;
using Models;

namespace Views.SandwichConstructorView
{
    public class  SandwichConstructorPresenter : Presenter<ISandwichConstructorView>
    {
        [SerializeField]
        private SandwichModel _sandwichModel;
        
        protected override void Awake()
        {
            base.Awake();
            View.AddSandwichClicked += OnAddSandwichClicked;
            View.CancelSandwichClicked += OnCancelSandwichClicked;
            View.AddNewIngredientClicked += OnAddNewIngredientClicked;
            View.RemoveLastIngredientClicked += OnRemoveLastIngredientClicked;
            
            _sandwichModel.IngredientAdded += OnIngredientAdded;
            _sandwichModel.SandwichCleared += OnSandwichCleared;
            _sandwichModel.LastIngredientRemoved += OnIngredientRemoved;
        }

        private void OnIngredientRemoved()
        {
            View.RemoveLastIngredient();
            SetUpDescription();
        }

        private void OnSandwichCleared()
        {
            View.ClearSandwich();
            View.SetAddSandwichButtonVisible(false);
            SetUpDescription();
        }

        private void OnIngredientAdded(int index, SandwichIngredient sandwich)
        {
            View.AddIngredient(index, sandwich);
            View.SetAddSandwichButtonVisible(true);
            SetUpDescription();
        }

        private void SetUpDescription()
        {
            View.SetDescriptionValues(_sandwichModel.GetTotalCalories(), _sandwichModel.GetTotalWeight(), _sandwichModel.GetTotalPrice());
        }

        private void OnRemoveLastIngredientClicked()
        {
           _sandwichModel.RemoveLastIngredient();
        }

        private void OnAddNewIngredientClicked()
        {
            _viewManager.OpenView(ViewName.SandwichIngredientsView);
        }

        private void OnAddSandwichClicked()
        {
            _viewManager.OpenView(ViewName.Menu);
            throw new System.NotImplementedException();
        }

        private void OnCancelSandwichClicked()
        {
            _viewManager.OpenView(ViewName.DishesMenu);
            _sandwichModel.ClearSandwich();
        }

        private void OnDestroy()
        {
            View.AddSandwichClicked -= OnAddSandwichClicked;
            View.CancelSandwichClicked -= OnCancelSandwichClicked;
            View.AddNewIngredientClicked -= OnAddNewIngredientClicked;
            View.RemoveLastIngredientClicked -= OnRemoveLastIngredientClicked;
            
            _sandwichModel.IngredientAdded -= OnIngredientAdded;
            _sandwichModel.SandwichCleared -= OnSandwichCleared;
            _sandwichModel.LastIngredientRemoved -= OnIngredientRemoved;
        }
    }
}
