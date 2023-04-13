using System;

namespace Data
{
    [Serializable]
    public class CustomDishInfo : IDishInfo
    {
        public CustomDishInfo(TranslatableName description, TranslatableName name, float calories, int price)
        {
            Description = description;
            Calories = calories;
            Price = price;
            Name = name;
        }
        
        public TranslatableName Description { get; }
        public TranslatableName Name { get; }
        public float Calories { get; }
        public int Price { get; }
    }
}
