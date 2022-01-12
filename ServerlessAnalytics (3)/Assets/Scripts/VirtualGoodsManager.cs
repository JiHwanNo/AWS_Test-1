using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class VirtualGoodsManager : MonoBehaviour
{

    // Virtual Goods
    public GameObject rainbow;
    public GameObject unicorn;
    public GameObject frost;
    public GameObject love;
    public GameObject poo;
    public GameObject glass;
    public GameObject lava;
    public GameObject starry;
    public GameObject student;
    public GameObject garnet;
    public GameObject lime;
    public GameObject lavender;

    public Transform hatsGrid;

    // Dictionary to match virtual goods item_ids with game objects
    private static Dictionary<string, GameObject> virtualGoods;

    // Initial of hat game objects for ordering
    private List<GameObject> hats = new List<GameObject>();

    // List of Popular Hats returned from Personalize
    private static List<string> allHats = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        Create_Virtual_Goods();

        // Set Initial Hats
        Display_All();

    }

    // Creates virtual goods values
    private void Create_Virtual_Goods()
    {
        // Match item_ids with game objects
        virtualGoods = new Dictionary<string, GameObject>()
        {
            { "5", rainbow },
            { "6", unicorn },
            { "7", frost },
            { "8", love },
            { "9", poo },
            { "10", glass },
            { "11", lava },
            { "12", starry },
            { "13", student },
            { "14", garnet },
            { "15", lime },
            { "16", lavender }
        };

        // Set Initial hat order of ids 
        string[] hatsIds = { "16", "15", "14", "13", "12", "11", "10", "9", "8", "7", "6,", "5" };
        allHats.AddRange(hatsIds);
    }


    // Displays original order of hats based on value
    private void Display_All()
    {
        int allPosition = 0;

        // Match ids with dictionary of virtual goods and reposition display all 
        foreach (string id in allHats)
        {
            if (virtualGoods.ContainsKey(id))
            {
                GameObject hat = virtualGoods[id];
                hat.transform.SetSiblingIndex(allPosition);
                allPosition++;
            }
        }
    }

}
