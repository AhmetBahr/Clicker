using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miniFriends : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float damageUpgrade;

    [SerializeField] private float time = 0;
    [SerializeField] private float Countdown = 5;

    [SerializeField] private Main main;

    [SerializeField] private GameObject miniFriend;


    void Start()
    {
        main = GameObject.Find("Player").GetComponent<Main>();
            
    }

    
    void Update()
    {
        time += Time.deltaTime;

        if(time > Countdown)
        {
            main.TakeDamage(damage);

            time = 0;

        }
        
    }

    public void miniFriendSetActive()
    {
        miniFriend.SetActive(true);

    }



}
