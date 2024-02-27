using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class Slot : MonoBehaviour
{
    public List<Item> items = new List<Item>();

    public Image icon;
    public TextMeshProUGUI number_of_items;
    public GameObject description;

    public TextMeshProUGUI item_name;
    public TextMeshProUGUI item_value;

    public void AddItem(Item item)
    {
        if (items.Count == 0)
        {            
            icon.sprite = item.icon;
            icon.gameObject.SetActive(true);
        }

        items.Add(item);
        number_of_items.text = items.Count.ToString();
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);
        number_of_items.text = items.Count.ToString();
        if (items.Count == 0)
            icon.gameObject.SetActive(false);
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

}
