using UnityEngine;
using UnityEngine.UI;

public class RecoveryTimeBasedResources : TimeBasedResource
{
    public float time_to_recovery;
    public GameObject main_object;
    public GameObject replace_obj;
    public GameObject cloud;
    private bool recovery = false;
    public override void Interact(Player player)
    {
        if ((transform.position - player.transform.position).magnitude < interact_distance && !recovery)
        {
            timer = Time.time;
            work = true;
            this.player = player;
            player.work_timer.gameObject.SetActive(true);
            player.SetPlayerWork(work);
        }
    }
    public new void Update()
    {
        if (work)
        {
            if (player.movement.isMoving())
                StopWork();

            player.work_timer.fillAmount = 1 - (Time.time - timer) / pickup_time;

            if (Time.time - timer >= pickup_time)
            {
                StopWork();
                for (int i = 0; i < amount; i++)
                    player.inventory.AddItem(item_so.CreateItem());

                StartRecovery();
            }
        }

        if(recovery)
        {
            cloud.GetComponentInChildren<Image>().fillAmount = 1 - (Time.time - timer) / time_to_recovery;
            if (Time.time - timer >= time_to_recovery)
                FinishRecovery();
        }
    }
    public void StartRecovery()
    {
        recovery = true;
        cloud.SetActive(true);
        main_object.SetActive(false);
        replace_obj.SetActive(true);
        cloud.GetComponentInChildren<Image>().fillAmount = 1;
        timer = Time.time;

    }
    private void FinishRecovery()
    {
        recovery = false;
        cloud.SetActive(false);
        main_object.SetActive(true);
        replace_obj.SetActive(false);
    }
}
