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
    private bool work;
    private void Start()
    {
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
                IInteractable interactable = objectHit.GetComponentInParent(typeof(IInteractable)) as IInteractable;
                if (interactable != null && !work)
                    interactable.Interact(this);
            }
        }
    }

    public void SetPlayerWork(bool _work)
    {
        work = _work;
    }

}

public interface IInteractable
{
    void Interact(Player player);

}

