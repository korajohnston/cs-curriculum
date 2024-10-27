using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
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

    private float attackTimer = 0.75f;
    private float attackCooldown = 0;
    private float attackRate = 2;

    private TopDown_EnemyAnimator _animator;
    public BoxCollider2D hitbox;
    public Vector2 originalHitBoxSize;
    public Vector2 attackingHitBoxSize;
    
    
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
        hitbox = GetComponent<BoxCollider2D>();
        originalHitBoxSize = hitbox.size;
        attackingHitBoxSize = new Vector2(x: 2f, y: 2f);
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
            //The following timer is being started when the animator plays attack animation
            //attackTimer -= Time.deltaTime;
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
        ChangeHitBoxSize(originalHitBoxSize);
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
            if (attackCooldown < 0)
            {
                _animator.Attack();
                ChangeHitBoxSize(attackingHitBoxSize);
            }
            else
            {
                ChangeHitBoxSize(originalHitBoxSize);
            }
           
        }
        else
        {
            attackTimer -= Time.deltaTime;
            if (attackTimer < 0)
            {
                ChangeHitBoxSize(originalHitBoxSize);
                attackCooldown = attackRate;
                attackTimer = 0.75f;
            }
            
        }

        /*attackCooldown -= Time.deltaTime;
            print("the enemy is attacking"+_animator.IsAttacking);
            if (attackCooldown < 0 && attackCooldown > -2)
            {
                ChangeHitBoxSize(attackingHitBoxSize);
                _animator.Attack();
                if (attackCooldown < -2)
                { 
                    attackCooldown = attackRate; 
                    ChangeHitBoxSize(originalHitBoxSize);  
                }
                 
            }
            
            if 1 < attackCooldown then set it back to originalhitBoxSize
            //else if (attackCooldown > 1)
            //{
               //hitbox.size = hitBoxSize;
            //}
        }
        */
    }

    void ChangeHitBoxSize(Vector2 size)
    {
        hitbox.size = size;
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

