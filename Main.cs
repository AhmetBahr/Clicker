using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    [Header("Core")]
    [SerializeField] private Button attackBt;

    [Header("Health")]
    [SerializeField] private float baseHealth;
    [SerializeField] private float currentHealth;
    [SerializeField] private float health_Plus_State = 10; // random


    [Header("Damage")]
    [SerializeField] private float damage = 10;

    [Header("Text")]
    [SerializeField] private TMP_Text textState;
    [SerializeField] private TMP_Text textMoney;
    [SerializeField] private TMP_Text textHealth;


    [Header ("Object")]
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject hitParticule;

    [Header("Animator")]
    [SerializeField] private Animator anim;

    [Header("Sprite")]
    [SerializeField] private Sprite [] spriteRenderer;

    [Header("Scripts")]
    public HealthBar healthBar;

    void Start()
    {

        currentHealth = baseHealth;
        healthBar.SetMaxHealth(baseHealth);

        textState.text = PlayerPrefs.GetInt("State").ToString();
        textMoney.text = PlayerPrefs.GetInt("Money").ToString();
    }

    void Update()
    {

        Controller();


    }

    private void Controller()
    {

        if (currentHealth <= 0)
        {
            stateFinish();
        }

        textHealth.text = currentHealth.ToString();
        textState.text = "State: " + PlayerPrefs.GetInt("State").ToString();
        textMoney.text = PlayerPrefs.GetInt("Money").ToString();
    }

    public void Attack()
    {

            TakeDamage(damage);

            Instantiate(hitParticule, player.transform.position, Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)));

            //To Do sound
            DamageAnimation();


        
    }

    private void stateFinish()
    {
        PlayerPrefs.SetInt("State", PlayerPrefs.GetInt("State") + 1); //  state = state + 1;
        heal_fulling();
        ChangeSprite();
    }

    private void heal_fulling()
    {
      //  currentHealth = baseHealth + (Random.Range(5, 10) * (PlayerPrefs.GetInt("State") + 1));

        currentHealth = baseHealth + (health_Plus_State * (PlayerPrefs.GetInt("State")) );
        
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


    private void ChangeSprite()
    {
        GetComponent<SpriteRenderer>().sprite = spriteRenderer[Random.Range(0, spriteRenderer.Length)];
    }
}
