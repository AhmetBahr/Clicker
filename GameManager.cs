using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject miniFriend1;

    [SerializeField] private Button FriendActive;
    [SerializeField] private Button FriendUpgrade;



    private void Update()
    {
        Friend_1_Controll();
    }


    public void FriendUpgradeButton() 
    {
        Debug.Log("Upgrade");

       

    }

    public void RemoveButton()
    {
        FriendActive.transform.position = new Vector2 (-100, 10);

    }

    public void Friend_1_SetActive()
    {
        miniFriend1.SetActive(true);
        PlayerPrefs.SetInt("Friend_1", 1);
       // PlayerPrefs.SetInt("Friend_1_Button", 1);

    }

    private void Friend_1_Controll()
    {
        if (PlayerPrefs.GetInt("Friend_1") > 0)
        {
            miniFriend1.SetActive(true);
            //Destroy(FriendActive.gameObject);  
            FriendActive.gameObject.SetActive(false);

        }


    }
}
