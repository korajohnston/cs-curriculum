using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public List<GameObject> waypoints;
    public int currentWaypoint = 0;
    private float speed = 4;
    public GameObject player;
    

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, waypoints[currentWaypoint].transform.position) < 1f)
        {
            currentWaypoint++;
            currentWaypoint %= waypoints.Count;
        }
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypoint].transform.position,1.5f * Time.deltaTime);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }
    
}
