using System.Collections.Generic;
using Data.Ingredients;
using UnityEngine;

namespace Models
{
    public class IngredientsModel : Model
    {
        [SerializeField] private SandwichIngredientsModel _sandwichIngredients;

        public IReadOnlyList<SandwichIngredient> GetAllSandwichIngredients()
        {
            return _sandwichIngredients.SandwichIngredients;
        }
    }
}
