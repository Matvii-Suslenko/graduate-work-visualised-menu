namespace Data
{
    public interface IDishInfo
    {
        string[] Ingredients { get; }
        TranslatableName Description { get; }
        TranslatableName Name { get; }
        float Calories { get; }
        int Price { get; }
    }
}
