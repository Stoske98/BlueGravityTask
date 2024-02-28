using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public List<ItemSO> sell_items;
    public List<ItemSO> buy_items;
    public Sprite picture;
    public GameObject shop_obj;
    public Transform content;
    public GameObject item_prefab;
    public Image salesman_picture;
    [HideInInspector]public bool sell;

    public void OpenSellShop()
    {
        sell = true;
        OpenShop(sell_items);
    }

    public void OpenBuyShop()
    {
        sell = false;
        OpenShop(buy_items);
    }

    private void OpenShop(List<ItemSO> items)
    {
        for (int i = 0; i < content.childCount; i++)
        {
            Destroy(content.GetChild(i).gameObject);
        }

        foreach (var item in items)
        {
            ShopItemUI shop_item = Instantiate(item_prefab, content).GetComponent<ShopItemUI>();
            shop_item.Init(this, item);
        }
        salesman_picture.sprite = picture;
        shop_obj.SetActive(true);

    }
}
