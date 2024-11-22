using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatforms : MonoBehaviour
{
    public List<GameObject> waypoints;
    public int currentWaypoint = 0;
    private float speed = 4;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, waypoints[currentWaypoint].transform.position) < 1f)
        {
            currentWaypoint++;
            currentWaypoint %= waypoints.Count;
        }

        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypoint].transform.position,
            1.5f * Time.deltaTime);
    }

    /*private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            gameObject.transform.parent = platform.transform;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        gameObject.transform.parent = null;
    }
    */
}
