using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerProjectile : MonoBehaviour
{
    public float speed = 3;
    public Vector2 enemytargetposition;
    public float timer;
    private float DeathTime = 4;
    
    // Start is called before the first frame update


    void Start()
    {
        Destroy(gameObject, DeathTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

