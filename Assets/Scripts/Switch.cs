using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Switch3"))
        {
            Destroy(GameObject.FindWithTag("RockDoor3"));
        }
        
        if (other.gameObject.CompareTag("Switch2"))
        {
            Destroy(GameObject.FindWithTag("RockDoor2"));
        }
        
        if (other.gameObject.CompareTag("Switch1"))
        {
            Destroy(GameObject.FindWithTag("RockDoor"));
        }
    }
}
