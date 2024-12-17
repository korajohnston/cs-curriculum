using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class Health : MonoBehaviour
{
    public GameManager gm;
    private TopDown_EnemyAnimator _enemyAttacking;
    public CollectPotion potion;
    public bool inLava = false;
    
    // Start is called before the first frame update
    void Start()
    {
        gm = FindFirstObjectByType<GameManager>();
        potion = GetComponent<CollectPotion>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inLava)
        {
            if (potion.hasPotion || potion.hasBigPotion)
            {
                gm.ChangeHealth(amount: 0);
            }
            else
            {
                gm.ChangeHealth(amount: -10);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Spikes"))
        {
            gm.ChangeHealth(amount:-10);
            print("we have " + gm.health + " health!");
        }

        if (other.gameObject.CompareTag("Projectile"))
        {
            gm.ChangeHealth(amount: -1);
            print("we have " + gm.health + " health!");
        }
        
        if (other.gameObject.CompareTag("Enemy"))
        {
            gm.ChangeHealth(-1);
        }

        if (other.gameObject.CompareTag("Lava"))
        {
            inLava = true;
            
        }
    }
}
