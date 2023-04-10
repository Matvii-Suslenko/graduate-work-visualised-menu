using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "DishInfo", menuName = "ScriptableObjects/DishInfo", order = 1)]
    public class DishInfo : ScriptableObject
    {
        public TranslatableName Name => _name;
        public int Price => _price;
        
        [SerializeField] private TranslatableName _name;
        [SerializeField] private TranslatableName _description;

        [SerializeField] private int _price;
        [SerializeField] private float _calories;
    }
}
