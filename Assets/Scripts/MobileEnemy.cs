using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class MobileEnemy : MonoBehaviour
{
    public List<GameObject> waypoints;
    public int currentWaypoint = 0;
    private float speed = 4;
    public GameObject player;
    States State;
    private bool StartofState = true;

    private float attackTimer = 1.3f;
    private float attackCooldown = 0;
    private float attackRate = 1;

    private TopDown_EnemyAnimator _animator;
    
    
    public int health = 5;

    public enum States 
    {
        Patroll,
        Chase,
        Attack,
        Die
    }

    void Start()
    {
        _animator = GetComponentInChildren<TopDown_EnemyAnimator>();
        
    }
    // Update is called once per frame
    void Update()
    {
        print(State);
        if (State == States.Chase)
        {
            Chase();
        }

        if (State == States.Patroll)
        {
            Patroll();
        }
        
        if (State == States.Attack)
        {
            Attack();
            //temporary until we get the animation working, eventually will just be the end of the animation frame
            attackTimer -= Time.deltaTime;
            
        }
        
        if (State == States.Die)
        {
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (player == null)
            {
                player = other.gameObject;
            }
            else
            {
                SwitchState(States.Attack);

            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (State == States.Chase)
            {
                player = null;    
            }
            else
            {
                SwitchState(States.Chase);
            }
            
        }
    }

    void Patroll()
    {
        if (Vector3.Distance(transform.position, waypoints[currentWaypoint].transform.position) < 1f)
        {
            currentWaypoint++;
            currentWaypoint %= waypoints.Count;
        }
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypoint].transform.position,1.5f * Time.deltaTime);

        if (player != null)
        {
            SwitchState(States.Chase);
        }

        if (health < 0)
        {
            SwitchState(States.Die);
        }
        
        
    }
    
    void Chase()
    {
        if(player == null) 
        {
            State = States.Patroll;
        }
        else
        {
            //move towards player
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }

    }

    void Attack()
    {
        
        if (!_animator.IsAttacking)
        {
            attackCooldown -= Time.deltaTime;
            print("the enemy is attacking"+_animator.IsAttacking);
            if (attackCooldown < 0)
            {
                _animator.Attack();
                attackCooldown = attackRate;
            }
            
        }
        
    }

    void Die()
    {
        print("enemy died");
        gameObject.SetActive(false);
        //instatiate a coin or something else to drop?
        //maybe with a random range if we drop or not
    }

    void SwitchState(States _state)
    {
        State = _state;
        StartofState = true;
    }
}
