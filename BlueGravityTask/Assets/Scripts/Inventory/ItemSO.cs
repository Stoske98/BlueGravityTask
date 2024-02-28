using UnityEngine;
[CreateAssetMenu(fileName = "Item", menuName = "Item/Basic")]
public class ItemSO : ScriptableObject
{
    public string Name;
    public int Price;
    public Sprite Icon;

    public virtual Item CreateItem()
    {
        return new Item(Name, Price, Icon);
    }
}

