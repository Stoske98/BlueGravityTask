public class InstantResource : Resources
{
    public override void Interact(Player player)
    {
        if((transform.position - player.transform.position).magnitude < interact_distance)
            for (int i = 0; i < amount; i++)
                player.inventory.AddItem(item_so.CreateItem());
    }
}
