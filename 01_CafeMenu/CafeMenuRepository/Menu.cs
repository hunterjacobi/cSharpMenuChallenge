namespace CafeMenuRepo;
public class Menu
{
    public int MealNumber { get; set; }
    public string MealName { get; set; }
    public string MealDescription { get; set; }
    public string MealIngredients { get; set; }
    public double MealPrice { get; set; }

    public Menu() { }
    public Menu(int number, string name, string description, string ingredients, double price)
    {
        MealNumber = number;
        MealName = name;
        MealDescription = description;
        MealIngredients = ingredients;
        MealPrice = price;
    }
}



