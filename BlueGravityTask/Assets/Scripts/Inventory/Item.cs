using UnityEngine;

public class Item
{
    public string name;
    public int price;
    public Sprite icon;

    public Item(string _name, int _price, Sprite _icon)
    {
        name = _name;
        price = _price;
        icon = _icon;
    }
}
