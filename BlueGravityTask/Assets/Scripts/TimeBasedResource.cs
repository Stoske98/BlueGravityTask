using UnityEngine;

public class TimeBasedResource : Resources
{
    public float pickup_time;
    protected float timer;
    protected bool work;
    protected Player player;

    public override void Interact(Player player)
    {
        if ((transform.position - player.transform.position).magnitude < interact_distance)
        {
            timer = Time.time;
            work = true;
            this.player = player;
            player.work_timer.gameObject.SetActive(true);
            player.SetPlayerWork(work);
        }
    }

    public void Update()
    {
        if (work)
        {
            if(player.movement.isMoving())
                StopWork();

            player.work_timer.fillAmount = 1 - (Time.time - timer) / pickup_time;

            if (Time.time - timer >= pickup_time)
            {
                StopWork();
                for (int i = 0; i < amount; i++)
                    player.inventory.AddItem(item_so.CreateItem());
            }
        }
    }

    public void StopWork()
    {
        work = false;
        player.SetPlayerWork(work);
        player.work_timer.gameObject.SetActive(false);
    }

}
