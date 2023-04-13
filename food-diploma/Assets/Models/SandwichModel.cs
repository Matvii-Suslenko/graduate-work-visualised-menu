using System.Collections.Generic;
using Data.Ingredients;
using UnityEngine;
using System.Linq;
using System;

namespace Models
{
    public class SandwichModel : Model
    {
        public event Action<int, SandwichIngredient> IngredientAdded;
        public event Action LastIngredientRemoved;
        public event Action SandwichCleared;

        public Transform SandwichObjectRoot => _sandwichObjectRoot;
        [SerializeField] private Transform _sandwichObjectRoot;

            private readonly List<KeyValuePair<int, SandwichIngredient>> _ingredients = new List<KeyValuePair<int, SandwichIngredient>>();

        public float GetTotalCalories()
        {
            return _ingredients.Select(i => i.Value).Sum(ingredient => ingredient.Calories);
        }
        
        public float GetTotalWeight()
        {
            return _ingredients.Select(i => i.Value).Sum(ingredient => ingredient.Weight);
        }
        
        public int GetTotalPrice()
        {
            return _ingredients.Select(i => i.Value).Sum(ingredient => ingredient.Price);
        }
        
        public void AddIngredient(int index, SandwichIngredient sandwichIngredient)
        {
            _ingredients.Add(new KeyValuePair<int, SandwichIngredient>(index, sandwichIngredient));
            IngredientAdded?.Invoke(index, sandwichIngredient);
        }

        public void RemoveLastIngredient()
        {
            if (!_ingredients.Any())
            {
                return;
            }
            
            var lastAdded = _ingredients.Last();
            _ingredients.Remove(lastAdded);
            
            if (!_ingredients.Any())
            {
                SandwichCleared?.Invoke();
            }
            else
            {
                LastIngredientRemoved?.Invoke();
            }
        }

        public void ClearSandwich()
        {
            _ingredients.Clear();
            SandwichCleared?.Invoke();
        }
    }
}