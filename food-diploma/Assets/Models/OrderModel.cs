using System.Collections.Generic;
using System;
using System.Linq;
using Data;
using UnityEngine;

namespace Models
{
    public class OrderModel : Model
    {
        public event Action OrderCleared;
        public event Action<int, DishBehaviour> DishAdded;
        public event Action<int> PriceChanged;
        public int CurrentPrice => _price;

        private Dictionary<int, DishInfo> _dishes = new Dictionary<int, DishInfo>();
        
        private int _lastIndex = 0;
        private int _price = 0;
        
        public void AddDish(DishBehaviour dish)
        {
            _lastIndex++;
            _dishes.Add(_lastIndex, dish.DishInfo);
            DishAdded?.Invoke(_lastIndex, dish);

            _price += dish.DishInfo.Price;
            PriceChanged?.Invoke(_price);
        }

        public void CancelDish(int dishId)
        {
            if (!_dishes.ContainsKey(dishId))
            {
                Debug.LogError($"No Dish to Cancel with id: {dishId}");
                return;
            }

            _price -= _dishes[dishId].Price;
            PriceChanged?.Invoke(_price);
            _dishes.Remove(dishId);

            if (!_dishes.Any())
            {
                OrderCleared?.Invoke();
            }
        }

        public void ClearOrder()
        {
            _dishes.Clear();
            OrderCleared?.Invoke();
            
            _price = 0;
            PriceChanged?.Invoke(_price);
        }
    }
}
