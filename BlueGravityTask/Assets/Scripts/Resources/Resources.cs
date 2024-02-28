using UnityEngine;

public abstract class Resources : MonoBehaviour, IInteractable
{
    public ItemSO item_so;
    public int amount;
    public float interact_distance;
    public Texture2D valid_cursor;
    public Texture2D unvalid_cursor;
    protected bool is_hover;

    public abstract void Interact(Player player);
    public abstract bool IsValidInteraction(Player player);
}
