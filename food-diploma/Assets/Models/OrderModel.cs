using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using UnityEngine;
using System.Text;
using System.Linq;
using System;
using Data;

namespace Models
{
    public class OrderModel : Model
    {
        public event Action<int> NewOrderReceived;
        
        private readonly HttpClient _httpClient = new HttpClient();
        private const string Address = "http://localhost:8000/";
        private const string Endpoint = "order";
        
        public event Action OrderCleared;
        public event Action<int, DishBehaviour> DishAdded;
        public event Action<int> PriceChanged;
        public int LastOrderId => _lastOrderId;
        public int CurrentPrice => _price;

        private Dictionary<int, IDishInfo> _dishes = new Dictionary<int, IDishInfo>();
        
        private int _lastOrderId = 0;
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

        public async Task SendOrder()
        {
            var body = string.Empty;
            foreach (var dish in _dishes)
            {
                body += $" - {dish.Value.Name._englishName}\n";

                foreach (var ingredient in dish.Value.Ingredients)
                {
                    body += $"    > {ingredient}\n";
                }
            }
            
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(Address + Endpoint),
                Content = new StringContent(body, Encoding.UTF8, "application/json"),
            };
            
            try
            {
                var response = await _httpClient.SendAsync(request).ConfigureAwait(true);
                var responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(true);
                NewOrderReceived?.Invoke(int.Parse(responseBody));
            }
            catch (Exception e)
            {
                Debug.LogWarning(e.Message);
            }
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
