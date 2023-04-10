using System;
using Data;

namespace Views.MenuView
{
    public interface IDishesMenuView : IView
    {
        /// <summary>
        /// Fires when Cancel New Dish Button is Clicked
        /// </summary>
        event Action CancelNewDishClicked;
        
        /// <summary>
        /// Fires when Sandwich Button is Clicked
        /// </summary>
        event Action SandwichClicked;
        
        /// <summary>
        /// Fires when Drink Button is Clicked
        /// </summary>
        event Action DrinkClicked;
        
        /// <summary>
        /// Fires when Other Food Button is Clicked
        /// </summary>
        event Action OtherFoodClicked;
    }
}
