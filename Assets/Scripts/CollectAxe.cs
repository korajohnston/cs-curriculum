using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectAxe : MonoBehaviour
{
    private int axe;
    public static MobileEnemy me;
    public bool HasAxe = false;
    
    // Start is called before the first frame update
    void Start()
    {
        me = FindObjectOfType<MobileEnemy>();
        HasAxe = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        HasAxe = true;
    }
}

//hurts enemy if player attacking = true
//hurts player if enemy attacking = true
//make player shoot at enemy like projectile with player projectile use turret and projectile script