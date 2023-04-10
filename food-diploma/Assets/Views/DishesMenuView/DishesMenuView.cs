using UnityEngine.UI;
using UnityEngine;
using System;

namespace Views.MenuView
{
    public class DishesMenuView : BaseView, IDishesMenuView
    {
        public event Action CancelNewDishClicked;
        public event Action SandwichClicked;
        public event Action DrinkClicked;
        public event Action OtherFoodClicked;

        public override ViewName ViewName => ViewName.DishesMenu;
        
        [SerializeField]
        private Button _cancelNewDishButton;
        
        [SerializeField]
        private Button _sandwichButton;
        
        [SerializeField]
        private Button _drinkButton;
        
        [SerializeField]
        private Button _otherFoodButton;

        private void Awake()
        {
            _cancelNewDishButton.onClick.AddListener(OnCancelNewDishClicked);
            _sandwichButton.onClick.AddListener(OnSandwichClicked);
            _drinkButton.onClick.AddListener(OnDrinkClicked);
            _otherFoodButton.onClick.AddListener(OnOtherFoodClicked);
        }

        private void OnSandwichClicked() => SandwichClicked?.Invoke();
        private void OnDrinkClicked() => DrinkClicked?.Invoke();
        private void OnOtherFoodClicked() => OtherFoodClicked?.Invoke();
        private void OnCancelNewDishClicked() => CancelNewDishClicked?.Invoke();

        private void OnDestroy()
        {
            _cancelNewDishButton.onClick.RemoveListener(OnCancelNewDishClicked);
            _sandwichButton.onClick.RemoveListener(OnSandwichClicked);
            _drinkButton.onClick.RemoveListener(OnDrinkClicked);
            _otherFoodButton.onClick.RemoveListener(OnOtherFoodClicked);
        }
    }
}
