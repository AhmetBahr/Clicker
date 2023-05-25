using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Main : MonoBehaviour
{
    [SerializeField] private float baseHealth = 15;
    [SerializeField] private float currentHealth;
    [SerializeField] private float health_Plus_State = 10; // random

    [SerializeField] private float damage = 10;
 

    [SerializeField] private TMP_Text textState;
    [SerializeField] private TMP_Text textMoney;

    public HealthBar healthBar;

    [SerializeField] private GameObject player;

    [SerializeField] private GameObject hitParticule;

    [SerializeField] private Animator anim;



    void Start()
    {

        currentHealth = baseHealth;
        healthBar.SetMaxHealth(baseHealth);

        textState.text = PlayerPrefs.GetInt("State").ToString();
        textMoney.text = PlayerPrefs.GetInt("Money").ToString();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            TakeDamage(damage);

            Instantiate(hitParticule, player.transform.position, Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)));

            //To Do sound
            DamageAnimation();

            
        }

        if(currentHealth <= 0)
        {
            stateFinish();
        }

        textState.text = "State: " + PlayerPrefs.GetInt("State").ToString();
        textMoney.text = PlayerPrefs.GetInt("Money").ToString();
    }

    private void stateFinish()
    {
        PlayerPrefs.SetInt("State", PlayerPrefs.GetInt("State") + 1); //  state = state + 1;
        heal_fulling();
    }

    private void heal_fulling()
    {
        currentHealth = baseHealth + (health_Plus_State * (PlayerPrefs.GetInt("State") +1) );
        healthBar.SetMaxHealth(currentHealth);
    }

    public void TakeDamage(float damagee)
    {
        currentHealth -= damagee;
        PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + Random.Range(3,7));  // money = money + random

        healthBar.setHealth(currentHealth);
     
    }

    private void DamageAnimation()
    {
        anim.SetTrigger("Damage");
    }


}
