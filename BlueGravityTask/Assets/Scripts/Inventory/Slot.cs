using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public List<Item> items = new List<Item>();

    public Image icon;
    public TextMeshProUGUI number_of_items;
    public GameObject description;

    public TextMeshProUGUI item_name;
    public TextMeshProUGUI item_value;
    public GameObject equip_object;

    public void AddItem(Item item)
    {
        if (items.Count == 0)
        {            
            icon.sprite = item.icon;
            icon.gameObject.SetActive(true);
        }

        items.Add(item);
        if(item is IEquippable)
            equip_object.SetActive(true);
        else
            equip_object.SetActive(false);

        number_of_items.text = items.Count.ToString();
    }

    public void RemoveItem(string _name)
    {
        Item itemToRemove = items.Find(item => item.name == _name);
        if (itemToRemove != null) 
        {
            items.Remove(itemToRemove);
            number_of_items.text = items.Count.ToString();
            if (items.Count == 0)
                icon.gameObject.SetActive(false);
        }
    }

    public void ShowDescription()
    {
        if (items.Count == 0)
            return;
        item_name.text = items[0].name;
        item_value.text = "Value: " + items[0].price.ToString() + " $\nIn Total: " + (items[0].price * items.Count).ToString() + " $";
        description.SetActive(true);
    }

    public void HideDescription()
    {
        if (items.Count == 0)
            return;
        description.SetActive(false);

    }

    public void Equip()
    {
        if(items.Count > 0 && items[0] is IEquippable equippable)
            equippable.Equip();
    }

}
