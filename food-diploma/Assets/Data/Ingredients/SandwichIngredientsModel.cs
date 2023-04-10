using System.Collections.Generic;
using UnityEngine;

namespace Data.Ingredients
{
    [CreateAssetMenu(fileName = "DishInfo", menuName = "ScriptableObjects/SandwichIngredientsModel", order = 2)]
    public class SandwichIngredientsModel : ScriptableObject
    {
        public IReadOnlyList<SandwichIngredient> SandwichIngredients => _sandwichIngredients;
        
        [SerializeField] private List<SandwichIngredient> _sandwichIngredients = new List<SandwichIngredient>();
    }
}
