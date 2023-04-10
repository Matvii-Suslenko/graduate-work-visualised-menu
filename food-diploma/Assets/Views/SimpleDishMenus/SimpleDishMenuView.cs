using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;
using Data;

namespace Views.SimpleDishMenus
{
    public class SimpleDishMenuView : BaseView, ISimpleDishMenuView
    {
        public event Action<DishBehaviour> DishSelected;
        public event Action CancelDishClicked;

        [SerializeField]
        private List<DishBehaviour> _dishes = new List<DishBehaviour>();
        
        [SerializeField]
        private Button _cancelDishButton;

        [SerializeField]
        private ScrollRect _scrollRect;
        
        private void Awake()
        {
            _cancelDishButton.onClick.AddListener(OnCancelDrinkClicked);

            foreach (var drink in _dishes)
            {
                drink.DishSelected += OnDrinkSelected;
            }
        }
        
        public override void ReceiveFocus()
        {
            base.ReceiveFocus();
            _scrollRect.horizontalNormalizedPosition = 0;
        }

        private void OnDrinkSelected(DishBehaviour drink)
        {
            DishSelected?.Invoke(drink);
        }

        private void OnCancelDrinkClicked() => CancelDishClicked?.Invoke();

        private void OnDestroy()
        {
            _cancelDishButton.onClick.RemoveListener(OnCancelDrinkClicked);
            
            foreach (var drink in _dishes)
            {
                drink.DishSelected -= OnDrinkSelected;
            }
        }
    }
}
