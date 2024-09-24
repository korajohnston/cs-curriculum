using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using TMPro;
public class collectcoin : MonoBehaviour
{

    public static GameManager gm; 
    int coins;
    public TextMeshProUGUI coinText;

    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        coins = 0; 
        coinText.text = "coins: " + gm.coins;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Coin"))
        {
            gm.coins += 1;
            coinText.text = "Coins: " + gm.coins;
            //print("we have " + gm.coins + " coins!");
            Destroy(other.gameObject);
        }
    }
}
