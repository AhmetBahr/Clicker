using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miniFriends : MonoBehaviour
{

    [Header("Damage")]
    [SerializeField] private float damage;
    [SerializeField] private float damageUpgrade;

    [Header("Time")]
    [SerializeField] private float time = 0;
    [SerializeField] private float Countdown = 5;

    [Header("Scripts")]
    [SerializeField] private Main main;

    


    void Start()
    {
        main = GameObject.Find("Player_Enemy").GetComponent<Main>();
            
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

}
