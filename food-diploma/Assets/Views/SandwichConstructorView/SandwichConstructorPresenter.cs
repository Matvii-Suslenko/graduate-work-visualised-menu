using Data.Ingredients;
using UnityEngine;
using Models;
using Data;

namespace Views.SandwichConstructorView
{
    public class SandwichConstructorPresenter : Presenter<ISandwichConstructorView>
    {
        [SerializeField]
        private OrderModel _orderModel;
        
        [SerializeField]
        private SandwichModel _sandwichModel;
        
        [SerializeField]
        private GameObject _customDishObject;

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
            var newSandwichObject = Instantiate(_customDishObject);
            
            var newDishBehaviour = newSandwichObject.GetComponent<DishBehaviour>();
            newDishBehaviour.SetCustomDishInfo(new CustomDishInfo(
                    new TranslatableName("Зібрана вами", "Made by you"),
                    new TranslatableName("Канапка", "Sandwich"),
                    _sandwichModel.GetTotalCalories(),_sandwichModel.GetTotalPrice(),
                    _sandwichModel.GetAllIngredientNames()));

            var newSandwichAxis = newSandwichObject.transform.Find("Asset Axis");
            Instantiate(_sandwichModel.SandwichObjectRoot, newSandwichAxis);
            
            var childrenCount = newSandwichAxis.GetChild(0).childCount;
            for (var i = 0; i < childrenCount; ++i)
            {
                newSandwichAxis.GetChild(0).GetChild(i).gameObject.layer = 0;
            }
            
            _orderModel.AddDish(newDishBehaviour);
            Destroy(newSandwichObject);
            
            _viewManager.OpenView(ViewName.Menu);
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
