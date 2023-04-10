using UnityEngine;
using Models;
using Data;

namespace Views.SimpleDishMenus
{
    public class SimpleDishesMenuPresenter : Presenter<ISimpleDishMenuView>
    {
        [SerializeField]
        private OrderModel _orderModel;
        
        protected override void Awake()
        {
            base.Awake();
            View.CancelDishClicked += OnCancelDishClicked;
            View.DishSelected += OnDishSelected;
        }

        private void OnDishSelected(DishBehaviour drink)
        {
            _orderModel.AddDish(drink);
            _viewManager.OpenView(ViewName.Menu);
        }

        private void OnCancelDishClicked()
        {
            _viewManager.OpenView(ViewName.Menu);
        }

        private void OnDestroy()
        {
            View.CancelDishClicked -= OnCancelDishClicked;
            View.DishSelected -= OnDishSelected;
        }
    }
}
