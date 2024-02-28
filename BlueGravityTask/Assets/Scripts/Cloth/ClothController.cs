using UnityEngine;

public class ClothController : MonoBehaviour
{
    public ClothSO base_cloth_so;
    public SpriteRenderer cloth_renderer;
    public Animator cloth_animator;
    private Cloth current_cloth;
    private void Start()
    {
        current_cloth = base_cloth_so.CreateItem() as Cloth;
    }
    public void SetCloth(Cloth _cloth)
    {
        Player.Instance.inventory.RemoveItem(_cloth.name);
        Player.Instance.inventory.AddItem(current_cloth);
        if (_cloth.name == "Basic")
        {
            cloth_animator.runtimeAnimatorController = null;
            cloth_renderer.sprite = null;
        }
        else
        {
            cloth_renderer.sprite = _cloth.icon;
            cloth_animator.runtimeAnimatorController = _cloth.controller;
        }
        current_cloth = _cloth;
    }

}
