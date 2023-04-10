using Data.Ingredients;
using System;

namespace Views.SandwichIngredientsView
{
    public interface ISandwichIngredientsView : IView
    {
        /// <summary>
        /// Fires when Cancel New Dish Button is Clicked
        /// </summary>
        event Action CancelNewIngredientClicked;
        
        /// <summary>
        /// Fires when Ingredient is Selected
        /// </summary>
        event Action<int> IngredientSelected;

        /// <summary>
        /// Ads new Ingredient
        /// </summary>
        /// <param name="index">Index</param>
        /// <param name="ingredient">Ingredient</param>
        void AddIngredient(int index, SandwichIngredient ingredient);
    }
}
