using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using TMPro;
public class collectcoin : MonoBehaviour
{

    public static GameManager gm; 
    int coins;

    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        coins = 0;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Coin"))
        {
            gm.coins += 1;
            //print("we have " + gm.coins + " coins!");
            Destroy(other.gameObject);
            gm.coinText.text = "coins: " + gm.coins;
        }
    }
}
