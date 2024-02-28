using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    #region UIManager Singleton
    private static UIManager _instance;
    public static UIManager Instance
    {
        get => _instance;
        private set
        {
            if (_instance == null)
                _instance = value;
            else if (_instance != value)
            {
                Debug.Log("UIManager instance already exist, destroying duplicate!");
                Destroy(value);
            }
        }
    }
    #endregion
    private void Awake()
    {
        Instance = this;
    }
    public TextMeshProUGUI player_coins;
    public GameObject shop;
    public void UpdatePlayerCoins(int coins)
    {
        player_coins.text = coins.ToString();
    }

    public void CloseShop()
    {
        shop.gameObject.SetActive(false);
    }

}
