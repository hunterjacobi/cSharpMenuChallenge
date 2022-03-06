using CafeMenuRepo;

public class CafeUI
{
    private MenuRepository _orderRepo = new MenuRepository();
    public void Run()
    {
        RunMenu();
        SeedContent();
    }

    public void RunMenu()
    {
        bool continueToRun = true;
        while (continueToRun)
        {
            Console.Clear();
            Console.WriteLine("Welcome to Komodo Cafe!\n" +
            "1. List all orders\n" +
            "2. Add an order\n" +
            "3. Remove an order\n" +
            "4. Exit.");

            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    ListAllOrders();
                    break;
                case "2":
                    CreateOrder();
                    break;
                case "3":
                    RemoveOrderFromList();
                    break;
                case "4":
                    continueToRun = false;
                    break;
                default:
                    Console.WriteLine("Please Enter a Valid Number between 1 and 5.\n");
                    Console.ReadKey();
                    break;
            }
        }
    }

    public void ListAllOrders()
    {
        List<Menu> ItemList = _orderRepo.ListOrders();

        foreach (Menu content in ItemList)
        {
            Console.WriteLine($"#{content.MealNumber} {content.MealName} {content.MealPrice}\n" +
            $"Description: {content.MealDescription}\n" +
            $"Ingredients: {content.MealIngredients}\n");
        }

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    public void CreateOrder()
    {
        Menu content = new Menu();

        Console.Clear();
        Console.WriteLine("(ID) (Name) (Description) (Ingredients) (Price)\n");

        Console.WriteLine("Enter the new item's item number: ");
        content.MealNumber = int.Parse(Console.ReadLine());

        Console.Clear();
        Console.WriteLine($"({content.MealNumber}) (Name) (Description) (Ingredients) (Price)\n");

        Console.WriteLine("Enter the item's name: ");
        content.MealName = Console.ReadLine();

        Console.Clear();
        Console.WriteLine($"({content.MealNumber}) ({content.MealName}) (Description) (Ingredients) (Price)\n");

        Console.WriteLine($"Enter a description for {content.MealName}: ");
        content.MealDescription = Console.ReadLine();

        Console.Clear();
        Console.WriteLine($"({content.MealNumber}) ({content.MealName}) ({content.MealDescription}) (Ingredients) (Price)\n");

        Console.WriteLine($"Enter the ingredients for {content.MealName}: ");
        content.MealIngredients = Console.ReadLine();

        Console.Clear();
        Console.WriteLine($"({content.MealNumber}) ({content.MealName}) ({content.MealDescription}) ({content.MealIngredients}) (Price)\n");

        Console.WriteLine($"Enter the price for {content.MealName}: ");
        content.MealPrice = double.Parse(Console.ReadLine());

        Console.Clear();
        Console.WriteLine("Order Summary:\n");

        Console.WriteLine($"Item Number: {content.MealNumber}\n" +
            $"Name: {content.MealName}\n" +
            $"Description: {content.MealDescription}\n" +
            $"Ingredients: {content.MealIngredients}\n" +
            $"Price: {content.MealPrice}");

        Console.WriteLine("Press any key to confirm order");
        Console.ReadKey();

        Console.Clear();
        Console.WriteLine("Order successfully added!\n" +
            "Press any key to continue...");
        Console.ReadKey();

        _orderRepo.AddOrder(content);
    }

    public void RemoveOrderFromList()
    {
        Console.WriteLine("What order would you like to remove?\n" +
        "(Please select by meal number)");

        List<Menu> ItemList = _orderRepo.ListOrders();

        foreach (Menu order in ItemList)
        {
            Console.WriteLine($"#{order.MealNumber} - {order.MealName}\n");
        }

        int numRemove = int.Parse(Console.ReadLine());

        Menu menuObject = _orderRepo.FindOrderByID(numRemove);

        _orderRepo.RemoveOrder(menuObject);

        Console.WriteLine("Order successfully removed!\n" +
    "Press any key to continue...");
        Console.ReadKey();
    }

    public void SeedContent()
    {
        Menu cheeseBurger = new Menu(1, "Cheese Burger", "Just a plain old burger.", "2 buns, 1 patty", 6.99);
        Menu chickenSandwich = new Menu(2, "Chicken Sandwich", "Crispy seasoned chicken breast in between two toasted buns.", "2 buns, 1 chicken breast", 4.99);
        Menu grilledCheese = new Menu(3, "Grilled Cheese", "Warmly toasted grilled cheese sandwich.", "2 bread, 2 slices of cheese", 5.59);

        _orderRepo.AddOrder(cheeseBurger);
        _orderRepo.AddOrder(chickenSandwich);
        _orderRepo.AddOrder(grilledCheese);
    }
}


