using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    // MenuManager singleton
    public static MenuManager Instance = null;

    // Panels to apply in editor
    [SerializeField] private GameObject LoginPanel;
    [SerializeField] private GameObject SignupPanel;
    [SerializeField] private GameObject CoinStorePanel;
    [SerializeField] private GameObject RecommendationsPanel;

    // UI Buttons & Input Fields
    public GameObject BankButtonGameObject;
    public Button RedirectButton;
    public Button ReturnButton;
    public Button BankButton;
    public Button CoinStoreBackButton;

    private void Awake()
    {
        Instance = this.gameObject.GetComponent<MenuManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //Events.Call_App_Load();

        RedirectButton.onClick.AddListener(Redirect);
        ReturnButton.onClick.AddListener(Return_To_Login);
        BankButton.onClick.AddListener(Load_Coin_Store);
        CoinStoreBackButton.onClick.AddListener(Close_Coin_Store);
    }

    // Button Functions
    public void Return_To_Login()
    {
        Close_Signup_Panel();
        Load_Login_Panel();
    }

    public void Redirect()
    {
        Close_Login_Panel();
        Load_Signup_Panel();
    }

    public void Load_Coin_Store()
    {
        Close_Recommendations_Panel();
        Load_Coin_Store_Panel();
    }

    public void Close_Coin_Store()
    {
        Close_Coin_Store_Panel();
        Load_Recommendations_Panel();
    }

    // Functions that set panels active and inactive
    public void Close_Login_Panel()
    {
        LoginPanel.SetActive(false);
    }

    public void Load_Login_Panel()
    {
        LoginPanel.SetActive(true);
    }

    public void Close_Signup_Panel()
    {
        SignupPanel.SetActive(false);
    }

    public void Load_Signup_Panel()
    {
        SignupPanel.SetActive(true);
    }

    public void Close_Recommendations_Panel()
    {
        RecommendationsPanel.SetActive(false);
        BankButtonGameObject.SetActive(false);
    }

    public void Load_Recommendations_Panel()
    {
        RecommendationsPanel.SetActive(true);
        BankButtonGameObject.SetActive(true);
    }

    public void Close_Coin_Store_Panel()
    {
        CoinStorePanel.SetActive(false);
        BankButtonGameObject.SetActive(false);
    }

    public void Load_Coin_Store_Panel()
    {
        CoinStorePanel.SetActive(true);
        BankButtonGameObject.SetActive(true);
    }
}
