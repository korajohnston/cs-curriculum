using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private float coolDown;
    private float firerate = 2;
    private GameObject projectilePrefab;
     
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        coolDown = Time.deltaTime;
    }

    private void OnTriggerStay(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player") & coolDown < 0)
        {
            //GameObject projectile Instantiate(projectilePrefab());
            Bullet.target = Player.transform.position;
            cooldown = firerate;
        }
    }
    
}
