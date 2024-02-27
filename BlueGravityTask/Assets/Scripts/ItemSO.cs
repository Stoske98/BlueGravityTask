using UnityEngine;
[CreateAssetMenu(fileName = "Item", menuName = "Item")]
public class ItemSO : ScriptableObject
{
    public string Name;
    public int Price;
    public Sprite Icon;

    public Item CreateItem()
    {
        return new Item(Name, Price, Icon);
    }
}

