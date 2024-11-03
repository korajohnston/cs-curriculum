using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerProjectile : MonoBehaviour
{
    public float speed = 3;
    public Vector2 enemytargetposition;
    public float timer;
    private float DeathTime = 4;
    public TopDown_AnimatorController _controller;
    public Animator animator;
    public int WalkDir;
    public GameObject playerProjectilePrefab;
    public string facing;
    // Start is called before the first frame update


    void Start()
    {
        Destroy(gameObject, DeathTime);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Vector3.MoveTowards(transform.position, enemytargetposition, speed * Time.deltaTime);
        //transform.position = Vector2;
    }
}

