using Views.MenuView;
using UnityEngine;
using Models;

namespace Views.StartScreenView
{
    public class  DishesMenuPresenter : Presenter<IDishesMenuView>
    {
        [SerializeField]
        private SandwichModel _sandwichModel;
        
        protected override void Awake()
        {
            base.Awake();
            View.CancelNewDishClicked += OnCancelNewDishClicked;
            View.SandwichClicked += OnSandwichClicked;
            View.DrinkClicked += OnDrinkClicked;
            View.OtherFoodClicked += OnOtherFoodClicked;
        }

        private void OnSandwichClicked()
        {
            _sandwichModel.ClearSandwich();
            _viewManager.OpenView(ViewName.SandwichConstructor);
        }
        
        private void OnDrinkClicked()
        {
            _viewManager.OpenView(ViewName.DrinksMenu);
        }

        private void OnOtherFoodClicked()
        {
            _viewManager.OpenView(ViewName.SideDishesMenu);
        }

        private void OnCancelNewDishClicked()
        {
            _viewManager.OpenView(ViewName.Menu);
        }

        private void OnDestroy()
        {
            View.CancelNewDishClicked -= OnCancelNewDishClicked;
            View.SandwichClicked -= OnSandwichClicked;
            View.DrinkClicked -= OnDrinkClicked;
            View.OtherFoodClicked -= OnOtherFoodClicked;
        }
    }
}
