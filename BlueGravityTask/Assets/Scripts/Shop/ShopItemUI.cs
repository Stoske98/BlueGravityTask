using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemUI : MonoBehaviour
{
    public Image icon;
    public TextMeshProUGUI item_name;
    public TextMeshProUGUI price;
    [HideInInspector]public ItemSO item;
    [HideInInspector]public Shop shop;

    public void Init(Shop _shop, ItemSO _item)
    {
        shop = _shop;
        item = _item;
        icon.sprite = item.Icon;
        item_name.text = item.Name;
        price.text = item.Price.ToString();
    }

    public void ActionOnClick()
    {
        if(shop.sell)
            Sell();
        else
            Buy();
    }

    public void Sell()
    {
        Player player = Player.Instance;
        if (player.inventory.IsItemExist(item.Name))
        {
            player.inventory.RemoveItem(item.Name);
            player.coins += item.Price;
            UIManager.Instance.UpdatePlayerCoins(player.coins);
        }
    }
    public void Buy()
    {
        Player player = Player.Instance;
        if(player.coins - item.Price >= 0)
        {
            player.inventory.AddItem(item.CreateItem());
            player.coins -= item.Price;
            UIManager.Instance.UpdatePlayerCoins(player.coins);
        }

    }
}
