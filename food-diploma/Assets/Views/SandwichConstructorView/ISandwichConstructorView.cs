using Data.Ingredients;
using System;

namespace Views.SandwichConstructorView
{
    public interface ISandwichConstructorView : IView
    {
        /// <summary>
        /// Fires when Cancel Sandwich Button is Clicked
        /// </summary>
        event Action CancelSandwichClicked;
        
        /// <summary>
        /// Fires when Add Sandwich Button is Clicked
        /// </summary>
        event Action AddSandwichClicked;
        
        /// <summary>
        /// Fires when Add New Ingredient Button is Clicked
        /// </summary>
        event Action AddNewIngredientClicked;
        
        /// <summary>
        /// Fires when Remove Last Ingredient Button is Clicked
        /// </summary>
        event Action RemoveLastIngredientClicked;

        /// <summary>
        /// Ads new Ingredient to the Sandwich
        /// </summary>
        void AddIngredient(int index, SandwichIngredient sandwich);
        
        /// <summary>
        /// Removes Last Ingredient of the Sandwich
        /// </summary>
        void RemoveLastIngredient();

        /// <summary>
        /// Ads new Ingredient to the Sandwich
        /// </summary>
        void ClearSandwich();

        /// <summary>
        /// Sets Sandwich Description Values
        /// </summary>
        /// <param name="calories">Calories</param>
        /// <param name="weight">Weight</param>
        /// <param name="price">Price</param>
        void SetDescriptionValues(float calories, float weight, int price);

        /// <summary>
        /// Sets Add Sandwich Button Visible
        /// </summary>
        /// <param name="isVisible">True if Is Visible</param>
        void SetAddSandwichButtonVisible(bool isVisible);
    }
}
