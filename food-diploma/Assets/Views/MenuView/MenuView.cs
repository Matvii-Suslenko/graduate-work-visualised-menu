using System.Collections.Generic;
using Localisation.Models;
using UnityEngine.UI;
using UnityEngine;
using System;
using Data;

namespace Views.MenuView
{
    public class MenuView : BaseView, IMenuView
    {
        public event Action CancelOrderClicked;
        public event Action FinishOrderClicked;
        public event Action AddNewDishClicked;
        public event Action<int> CancelDishClicked;

        public override ViewName ViewName => ViewName.Menu;
        
        [SerializeField]
        private int _optionWidth = 240;
        
        [SerializeField]
        private Button _cancelOrderButton;
        
        [SerializeField]
        private Button _finishOrderButton;

        [SerializeField]
        private Button _addNewDishButton;

        [SerializeField]
        private RectTransform _carousalTransform;

        [SerializeField]
        private Text _orderPrice;
        
        [SerializeField]
        private ScrollRect _scrollRect;

        private readonly List<DishBehaviour> _dishes = new List<DishBehaviour>();
        
        private void Awake()
        {
            _finishOrderButton.onClick.AddListener(OnFinishOrderClicked);
            _cancelOrderButton.onClick.AddListener(OnCancelOrderClicked);
            _addNewDishButton.onClick.AddListener(OnAddNewDishClicked);
            _finishOrderButton.interactable = false;
            SetUpScroll();
        }
        
        public void AddDish(int dishId, DishBehaviour dish)
        {
            var newDish = Instantiate(dish, _carousalTransform);

            if (dish.DishInfo is CustomDishInfo customDishInfo)
            {
                newDish.SetCustomDishInfo(customDishInfo);
            }
            
            newDish.SetCancelVisible(true);
            newDish.DishCanceled += (d) => OnCancelDishClicked(d, dishId);
            _dishes.Add(newDish);
            SetUpScroll();
        }

        private void OnCancelDishClicked(DishBehaviour dish, int dishId)
        {
            _dishes.Remove(dish);
            CancelDishClicked?.Invoke(dishId);
            Destroy(dish.gameObject);
            SetUpScroll();
        }

        public void SetOrderPrice(int price)
        {
            _orderPrice.text = $"{price} {LocalisationModel.CurrencyKeyword}";
        }

        public void RemoveAllDishes()
        {
            foreach (var dish in _dishes)
            {
                Destroy(dish.gameObject);
            }
            _dishes.Clear();
            SetUpScroll();
        }

        private void SetUpScroll()
        {
            _carousalTransform.sizeDelta = new Vector2((_dishes.Count + 1) * _optionWidth, _carousalTransform.sizeDelta.x);
            _scrollRect.horizontalNormalizedPosition = 0;
        }

        public void SetFinishOrderButtonVisible(bool isVisible)
        {
            _finishOrderButton.interactable = isVisible;
        }

        private void OnAddNewDishClicked() => AddNewDishClicked?.Invoke();
        private void OnFinishOrderClicked() => FinishOrderClicked?.Invoke();
        private void OnCancelOrderClicked() => CancelOrderClicked?.Invoke();

        private void OnDestroy()
        {
            _finishOrderButton.onClick.RemoveListener(OnFinishOrderClicked);
            _cancelOrderButton.onClick.RemoveListener(OnCancelOrderClicked);
            _addNewDishButton.onClick.AddListener(OnAddNewDishClicked);
        }
    }
}
