using UnityEngine;
/*
public class ResourceInteraction
{
    private Resources resources;
    public float start_time = 0;
    private bool in_process = false;
    private bool recovery = false;

    public ResourceInteraction(Resources resources)
    {
        this.resources = resources;
    }

    public void StartPickup()
    {
        in_process = true;
        start_time = Time.time;
    }

    public void PickupResource()
    {
        Player.Instance.inventory.AddItem(resources.item);
        StopPickup();
        resources.main_object.SetActive(false);
        resources.replace_obj.SetActive(true);
    }
    public void StartRecovery()
    {
        recovery = true;
        resources.cloud.SetActive(true);
        resources.cloud.GetComponentInChildren<Image>().fillAmount = 1;
        start_time = Time.time;
    }
    public void FinishRecovery()
    {
        recovery = false;
        resources.cloud.SetActive(false);
        resources.main_object.SetActive(true);
        resources.replace_obj.SetActive(false);
    }

    public void StopPickup()
    {
        in_process = false;
        Player.Instance.work_timer.gameObject.SetActive(false);
        Player.Instance.RemoveResource();
    }

    public void Update()
    {
        if (in_process)
        {
            if (Time.time - start_time >= resources.pickup_time)
            {
                PickupResource();
                StartRecovery();
            }
        }

        if (recovery)
        {
            resources.cloud.GetComponentInChildren<Image>().fillAmount = 1 - (Time.time - start_time) / resources.time_to_recovery;
            if (Time.time - start_time >= resources.time_to_recovery)
                FinishRecovery();
        }
    }
}
*/

public abstract class Resources : MonoBehaviour, IInteractable
{
    public ItemSO item_so;
    public int amount;
    public float interact_distance;
    public abstract void Interact(Player player);
}
