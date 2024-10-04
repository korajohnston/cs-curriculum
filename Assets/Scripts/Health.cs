using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Health : MonoBehaviour
{
    public GameManager gm;
    
    // Start is called before the first frame update
    void Start()
    {
        gm = FindFirstObjectByType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Spikes"))
        {
            gm.ChangeHealth(amount:-1);
            print("we have " + gm.health + " health!");
        }

        if (other.gameObject.CompareTag("Projectile"))
        {
            gm.ChangeHealth(amount: -1);
            print("we have " + gm.health + " health!");
        }
        
        if (other.gameObject.CompareTag("Enemy"))
        {
            gm.ChangeHealth(-3);
        }
    }
}
