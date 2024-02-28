using UnityEngine;

public class Cloth : Item, IEquippable
{
    public RuntimeAnimatorController controller;

    public Cloth(string _name, int _price, Sprite _icon, RuntimeAnimatorController _controller) : base(_name, _price, _icon)
    {
        controller = _controller;
    }

    public void Equip()
    {
        Player.Instance.gameObject.GetComponent<ClothController>().SetCloth(this);
    }
}
