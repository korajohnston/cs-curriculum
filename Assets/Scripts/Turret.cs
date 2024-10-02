using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private float coolDown;
    private float firerate = 2;
    public GameObject projectilePrefab;
     
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        coolDown -= Time.deltaTime;
    }

  private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") & coolDown < 0)
        {
            //GameObject projectile Instantiate(projectilePrefab());
            GameObject clone = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            Projectile script = clone.GetComponent<Projectile>();
            script.targetposition = other.gameObject.transform.position;
            coolDown = firerate;
        }
    }
}