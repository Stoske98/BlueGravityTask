using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    #region Player Singleton
    private static Player _instance;
    public static Player Instance
    {
        get => _instance;
        private set
        {
            if (_instance == null)
                _instance = value;
            else if (_instance != value)
            {
                Debug.Log("Player instance already exist, destroying duplicate!");
                Destroy(value);
            }
        }
    }
    private void Awake()
    {
        Instance = this;
    }
    #endregion
    public Inventory inventory;
    public PlayerMovement movement;
    public Image work_timer;
    private Resources current_resources;
    [HideInInspector] public bool work = false;
    private void Start()
    {
        inventory = new Inventory();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 rayOrigin = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.zero);

            if (hit.collider != null)
            {
                    GameObject objectHit = hit.collider.gameObject;
                    Resources resources = objectHit.GetComponentInParent<Resources>();
                    if (resources != null && current_resources == null && (objectHit.transform.position - transform.position).magnitude < resources.pick_up_distance) 
                    {

                        work = true;
                        current_resources = resources;
                        current_resources.resource_interaction.StartPickup();
                        work_timer.gameObject.SetActive(true);
                    }
            }
        }
        if(work && current_resources != null)
        {
            work_timer.fillAmount = 1 - (Time.time - current_resources.resource_interaction.start_time) / current_resources.pickup_time;
        }
        if(current_resources != null && movement.isMoving() && work)
        {
            work = false;
            current_resources.resource_interaction.StopPickup();
            current_resources = null;
        }
    }
}
