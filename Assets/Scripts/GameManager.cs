using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int coins;
    public static GameManager gm;
    public int health;
    private  int max_Health = 10;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI coinText;
    private string currentSceneName; 

    void Awake()
    {
        if(gm != null && gm != this)
        {
            //imposter found
            Destroy(this.gameObject);
        } 
        else
        {
            //original
            gm = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    
    // Start is called before the first frame update
    void Start()
    {
        //set restart scene
        coins = 0;
        coinText.text = "coins: " + gm.coins;
        health = 10;
        healthText.text = "health: " + gm.health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void Die()
    {
        print("you died.");
        //restart level
        //sm reload
        //sm load scene
    }

    public int GetHealth()
    {
        return health;
    }

    public void ChangeHealth(int amount)
    {
        healthText.text = "health: " + gm.health;
        health += amount;
        if (health > max_Health)
        {
            health = max_Health;
        }

        if (health < 1)
        {
            Die();
            //also update health text
            health = max_Health;
            coins = 0;
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
        healthText.text = "health: " + gm.health;
        coinText.text = "coins: " + gm.coins;
    }
}
