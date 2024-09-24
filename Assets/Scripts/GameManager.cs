using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int coins;
    public static GameManager gm;
    public int health;
    private  int max_Health = 10;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI coinText;

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
        coinText.text = "coins: " + gm.coins;
        coins = 0;
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
    }

    public int GetHealth()
    {
        return health;
    }

    public void ChangeHealth(int amount)
    {
        health += amount;
        if (health > max_Health)
        {
            health = max_Health;
        }

        if (health < 1)
        {
            Die();
            //also update health text
        }
    }
}
