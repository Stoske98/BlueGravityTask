using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int max_number_of_slots = 9;
    List<Slot> list_of_slots;

    public GameObject slot;

    private void Start()
    {
        list_of_slots = new List<Slot>();
        for (int i = 0; i < max_number_of_slots; i++)
            list_of_slots.Add(Instantiate(slot, transform).GetComponent<Slot>());
        
    }
    public void AddItem(Item item)
    {
        int pos = -1;
        for (int i = 0; i < list_of_slots.Count; i++)
        {
            if (list_of_slots[i].items.Count == 0 && pos == -1)
                pos = i;

            if(list_of_slots[i].items.Count > 0 && list_of_slots[i].items[0].name == item.name)
            {
                list_of_slots[i].AddItem(item);
                return;
            }
        }
        if(pos != -1)
            list_of_slots[pos].AddItem(item);
    }
    public void RemoveItem(Item item)
    {
        for (int i = 0; i < list_of_slots.Count; i++)
        {
            if (list_of_slots[i].items.Count > 0 && list_of_slots[i].items[0].name == item.name)
            {
                list_of_slots[i].RemoveItem(item);
                return;
            }
        }
    }
}