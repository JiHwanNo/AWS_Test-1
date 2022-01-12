using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransactionManager : MonoBehaviour
{
    // This script can be extended with other IAP transaction information.
    // As is, it only listens for button interactions to trigger analytics 
    // events for demo purposes.

    // IAP Buttons
    public Button BuySmallGemPack;
    public Button BuyMediumGemPack;
    public Button BuyLargeGemPack;
    public Button BuyPremiumGemPack;

    // Virtual Goods Buttons
    public Button BuyRainbow;
    public Button BuyUnicorn;
    public Button BuyFrost;
    public Button BuyLove;
    public Button BuyPoo;
    public Button BuyGlass;
    public Button BuyLava;
    public Button BuyStarry;
    public Button BuyStudent;
    public Button BuyGarnet;
    public Button BuyLime;
    public Button BuyLavender;


    // Start is called before the first frame update
    void Start()
    {

        //Add IAP Listeners
        BuySmallGemPack.onClick.AddListener(Events.Buy_Small_Gem_Pack);
        BuyMediumGemPack.onClick.AddListener(Events.Buy_Medium_Gem_Pack);
        BuyLargeGemPack.onClick.AddListener(Events.Buy_Large_Gem_Pack);
        BuyPremiumGemPack.onClick.AddListener(Events.Buy_Premium_Gem_Pack);

        //Add Virtual Goods Listeners
        BuyRainbow.onClick.AddListener(Events.Buy_Rainbow_Hat);
        BuyUnicorn.onClick.AddListener(Events.Buy_Unicorn_Hat);
        BuyFrost.onClick.AddListener(Events.Buy_Frost_Hat);
        BuyLove.onClick.AddListener(Events.Buy_Love_Hat);
        BuyPoo.onClick.AddListener(Events.Buy_Poo_Hat);
        BuyGlass.onClick.AddListener(Events.Buy_Glass_Hat);
        BuyLava.onClick.AddListener(Events.Buy_Lava_Hat);
        BuyStarry.onClick.AddListener(Events.Buy_Starry_Hat);
        BuyStudent.onClick.AddListener(Events.Buy_Student_Hat);
        BuyGarnet.onClick.AddListener(Events.Buy_Garnet_Hat);
        BuyLime.onClick.AddListener(Events.Buy_Lime_Hat);
        BuyLavender.onClick.AddListener(Events.Buy_Lavender_Hat);

        Debug.Log("Listeners set");
    }

}
