using System.Collections.Generic;

public class Inventory
{
    public List<Item> items = new List<Item>();

    public void AddItem(Item item)
    {
        items.Add(item);
    }
    public void RemoveItem(Item item)
    {
        items.Remove(item);
    }
}