public class InstantResource : Resources
{
    public override void Interact(Player player)
    {
        for (int i = 0; i < amount; i++)
            player.inventory.AddItem(item_so.CreateItem());
    }

    public override bool IsValidInteraction(Player player)
    {
        if ((transform.position - player.transform.position).magnitude < interact_distance && !player.IsPlayerWork())
            return true;
        return false;
    }
}