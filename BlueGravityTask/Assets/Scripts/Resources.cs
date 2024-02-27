using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        Player.Instance.inventory.AddItem(resources.item);
    }

    public void StopPickup()
    {
        in_process = false;
        Player.Instance.work_timer.gameObject.SetActive(false);
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


public class Resources : MonoBehaviour
{
    public float pickup_time;
    public float time_to_recovery;
    public GameObject main_object;
    public GameObject replace_obj;
    public float pick_up_distance;
    public  GameObject cloud;
    public Item item;

    public ResourceInteraction resource_interaction;

    private void Start()
    {
        resource_interaction = new ResourceInteraction(this);
    }


    private void Update()
    {
        resource_interaction.Update();
    }

}
[Serializable]
public class Item
{
    public string name;
    public int price;
    public Sprite icon;
}
