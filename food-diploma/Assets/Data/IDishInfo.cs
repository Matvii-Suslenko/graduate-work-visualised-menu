namespace Data
{
    public interface IDishInfo
    {
        TranslatableName Description { get; }
        TranslatableName Name { get; }
        float Calories { get; }
        int Price { get; }
    }
}
