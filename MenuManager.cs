using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{

    [SerializeField] private Button FriendActive;
    [SerializeField] private Button FriendUpgrade;


    public void FriendUpgradeButton()
    {
        Debug.Log("Upgrade");

    }

    public void RemoveButton()
    {
        Destroy(FriendActive.gameObject);

    }

}
