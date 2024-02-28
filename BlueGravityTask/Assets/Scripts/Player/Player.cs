using UnityEngine;
using UnityEngine.EventSystems;
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
    public int coins = 0;
    public Image work_timer;
    private bool work;
    private IInteractable interactable;
    public Texture2D basic_cursor;
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && interactable != null && interactable.IsValidInteraction(this))
            interactable.Interact(this);

        Hover();
    }
    public void Hover()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider != null)
        {
            if(EventSystem.current.IsPointerOverGameObject())
            {
                interactable = null;
                Cursor.SetCursor(basic_cursor, Vector2.zero, CursorMode.Auto);
                return;
            }

            if (hit.collider.gameObject.GetComponentInParent(typeof(IInteractable)) is IInteractable _interactable)
            {
                if(_interactable != interactable || movement.isMoving())
                {
                    interactable = _interactable;
                    if (_interactable is Resources resources)
                        if (_interactable.IsValidInteraction(this))
                            Cursor.SetCursor(resources.valid_cursor, Vector2.zero, CursorMode.Auto);
                        else
                            Cursor.SetCursor(resources.unvalid_cursor, Vector2.zero, CursorMode.Auto);
                }
            }
            else if(interactable != null)
            {
                interactable = null;
                Cursor.SetCursor(basic_cursor, Vector2.zero, CursorMode.Auto);

            }
        }
    }
    public void SetPlayerWork(bool _work)
    {
        work = _work;
    }

    public bool IsPlayerWork()
    {
        return work;
    }
}
