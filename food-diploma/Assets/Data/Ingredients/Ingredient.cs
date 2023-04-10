using UnityEngine;
using System;

namespace Data.Ingredients
{
    [Serializable]
    public class Ingredient
    {
        public GameObject IngredientAsset => _ingredientAsset;
        public Sprite IngredientSprite => _ingredientSprite;
        public TranslatableName Name => _name;
        public float Calories => _calories;
        public float Weight => _weight;
        public int Price => _price;
        
        [SerializeField] private GameObject _ingredientAsset;
        [SerializeField] private Sprite _ingredientSprite;
        [SerializeField] private TranslatableName _name;
        [SerializeField] private float _calories = 5;
        [SerializeField] private float _weight = 20;
        [SerializeField] private int _price = 10;
    }
}
