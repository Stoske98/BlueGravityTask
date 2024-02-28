using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Item/Cloth")]
public class ClothSO : ItemSO
{
    public RuntimeAnimatorController anim_controller;

    public override Item CreateItem()
    {
        return new Cloth(Name, Price, Icon, anim_controller);
    }
}

