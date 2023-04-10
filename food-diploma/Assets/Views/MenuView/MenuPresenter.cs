using Localisation.Models;
using Localisation;
using Views.MenuView;
using UnityEngine;
using Models;
using Data;

namespace Views.StartScreenView
{
    public class  MenuPresenter : Presenter<IMenuView>
    {
        [SerializeField]
        private OrderModel _orderModel;
        
        protected override void Awake()
        {
            base.Awake();
            LocalisationModel.LanguageSelected += OnLanguageSelected;
            OnLanguageSelected(LocalisationModel.CurrentLanguage);
            View.FinishOrderClicked += OnFinishOrderClicked;
            View.CancelOrderClicked += OnCancelOrderClicked;
            View.AddNewDishClicked += OnAddNewDishClicked;
            View.CancelDishClicked += OnCancelDishClicked;
            _orderModel.OrderCleared += OnOrderCleared;
            _orderModel.PriceChanged += OnPriceChanged;
            _orderModel.DishAdded += OnDishAdded;
        }

        private void OnFinishOrderClicked()
        {
            _viewManager.OpenView(ViewName.FinishScreen);
        }

        private void OnLanguageSelected(Language language)
        {
            OnPriceChanged(_orderModel.CurrentPrice);
        }

        private void OnOrderCleared()
        {
            View.RemoveAllDishes();
            View.SetFinishOrderButtonVisible(false);
        }

        private void OnCancelDishClicked(int dishId)
        {
            _orderModel.CancelDish(dishId);
        }

        private void OnPriceChanged(int newPrice)
        {
            View.SetOrderPrice(newPrice);
        }

        private void OnDishAdded(int id, DishBehaviour dishObject)
        {
            View.AddDish(id, dishObject);
            View.SetFinishOrderButtonVisible(true);
        }

        private void OnAddNewDishClicked()
        {
            _viewManager.OpenView(ViewName.DishesMenu);
        }

        private void OnCancelOrderClicked()
        {
            _viewManager.OpenView(ViewName.StartScreen);
            _orderModel.ClearOrder();
        }

        private void OnDestroy()
        {
            LocalisationModel.LanguageSelected -= OnLanguageSelected;
            View.FinishOrderClicked -= OnFinishOrderClicked;
            View.CancelOrderClicked -= OnCancelOrderClicked;
            View.AddNewDishClicked -= OnAddNewDishClicked;
            View.CancelDishClicked -= OnCancelDishClicked;
            _orderModel.OrderCleared -= OnOrderCleared;
            _orderModel.PriceChanged -= OnPriceChanged;
            _orderModel.DishAdded -= OnDishAdded;
        }
    }
}
