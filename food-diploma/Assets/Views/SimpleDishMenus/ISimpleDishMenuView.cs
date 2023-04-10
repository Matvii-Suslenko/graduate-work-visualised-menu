using System;
using Data;

namespace Views.SimpleDishMenus
{
    public interface ISimpleDishMenuView : IView
    {
        /// <summary>
        /// Fires when Drink/Dish is Selected
        /// </summary>
        event Action<DishBehaviour> DishSelected;
        
        /// <summary>
        /// Fires when Cancel Dish/Drink Button is Clicked
        /// </summary>
        event Action CancelDishClicked;
    }
}
