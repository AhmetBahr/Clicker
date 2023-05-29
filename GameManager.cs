using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{



    [Header("Friend_1")]
    [SerializeField] private GameObject miniFriend_1;
    [SerializeField] private Button FriendActive_1;
    [SerializeField] private Button FriendUpgrade_1;
    [SerializeField] private float price_1;

    [Header("Friend_")]
    [SerializeField] private GameObject miniFriend_2;
    [SerializeField] private Button FriendActive_2;
    [SerializeField] private Button FriendUpgrade_2;
    [SerializeField] private float price_2;



    private void Update()
    {
        miniFriend_Controll();
    }


    public void FriendUpgradeButton() 
    {
        Debug.Log("Upgrade");

    }

    public void RemoveButton()
    {
        FriendActive_1.transform.position = new Vector2 (-100, 10);

    }

    public void Friend_1_SetActive()
    {
        miniFriend_1.SetActive(true);
        PlayerPrefs.SetInt("Friend_1", 1);

    }

    public void Friend_2_SetActive()
    {
        miniFriend_1.SetActive(true);
        PlayerPrefs.SetInt("Friend_2", 1);

    }

    private void miniFriend_Controll()
    {
        if (PlayerPrefs.GetInt("Friend_1") > 0)
        {
            miniFriend_1.SetActive(true);
            FriendActive_1.gameObject.SetActive(false);

        }

        if (PlayerPrefs.GetInt("Friend_2") > 0)
        {
            miniFriend_2.SetActive(true);
            FriendActive_2.gameObject.SetActive(false);

        }

    }
}
