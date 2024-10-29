using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    public float speed = 3;
    public Vector3 targetposition;
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
        transform.position = Vector3.MoveTowards(transform.position, targetposition, speed * Time.deltaTime);
    }
}
