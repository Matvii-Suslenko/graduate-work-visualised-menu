using System;
using Data;

namespace Views.MenuView
{
    public interface IMenuView : IView
    {
        /// <summary>
        /// Fires when Cancel Order Button is Clicked
        /// </summary>
        event Action CancelOrderClicked;
        
        /// <summary>
        /// Fires when Finish Order Button is Clicked
        /// </summary>
        event Action FinishOrderClicked;
        
        /// <summary>
        /// Fires when Add New Dish Button is Clicked
        /// </summary>
        event Action AddNewDishClicked;
        
        /// <summary>
        /// Fires when Cancel Dish Button is Clicked
        /// </summary>
        event Action<int> CancelDishClicked;

        /// <summary>
        /// Added New Dish
        /// </summary>
        /// <param name="id">Dish Id From Order Model</param>
        /// <param name="dish">Dish Object</param>
        void AddDish(int id, DishBehaviour dish);

        /// <summary>
        /// Sets New Order Price
        /// </summary>
        /// <param name="price">Price</param>
        void SetOrderPrice(int price);

        /// <summary>
        /// Removes All Dishes
        /// </summary>
        void RemoveAllDishes();

        /// <summary>
        /// Sets Finish Order Button Visible
        /// </summary>
        /// <param name="isVisible">True if Is Visible</param>
        void SetFinishOrderButtonVisible(bool isVisible);
    }
}
