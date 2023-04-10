using UnityEngine;
using System;

namespace Data.Ingredients
{
    [Serializable]
    public class SandwichIngredient : Ingredient
    {
        public float Height => _height;
        
        [SerializeField] private float _height = 0.01f;
    }
}
