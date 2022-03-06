namespace CafeMenuRepo;
public class MenuRepository
{
    protected readonly List<Menu> _orders = new List<Menu>();
    public void AddOrder(Menu order) // Adds Item
    {
        _orders.Add(order);
    }

    public Menu FindOrderByID(int orderId)
    {
        foreach (Menu menuObject in _orders)
        {
            if (menuObject.MealNumber == orderId)
            {
                return menuObject;
            }
        }
        return null;
    }
    public bool RemoveOrder(Menu order)
    {
        int initialCount = _orders.Count;

        _orders.Remove(order);
        if (initialCount > _orders.Count)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public List<Menu> ListOrders()
    {
        return _orders;
    }

}