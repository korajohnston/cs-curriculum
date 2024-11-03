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
    public States State;
    private bool StartofState = true;

    public float attackTimer = 0.75f;
    public float attackCooldown = 0;
    public float attackRate = 2;

    private TopDown_EnemyAnimator _animator;
    public BoxCollider2D hitbox;
    public Vector2 originalHitBoxSize;
    public Vector2 attackingHitBoxSize;

    public bool AbleToAttack = false;
    public int health = 1;

    public GameObject axeltemPrefab;

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
        health = 1;
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
                AbleToAttack = true;
            }
            if (health < 0)
            {
                SwitchState(States.Die);
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
                SwitchState(States.Patroll);
            }
            else
            {
                SwitchState(States.Chase);
                AbleToAttack = false;
            }
            if (health < 0)
            {
                SwitchState(States.Die);
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
            SwitchState(States.Patroll);
        }
        else
        {
            //move towards player
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
        if (health < 0)
        {
            SwitchState(States.Die);
        }

    }

    void Attack()
    {
        if (!_animator.IsAttacking)
        {
            //attackCooldown, time between attacks
            //attackTimer, length of attack
            //attackRate, resets the cooldown
            
            attackCooldown -= Time.deltaTime;
            if (attackCooldown <= 0)
            {
                _animator.Attack();
                ChangeHitBoxSize(attackingHitBoxSize);
                attackCooldown = attackRate;
            }
            else
            {
                ChangeHitBoxSize(originalHitBoxSize);
            }
           
        }
       
        else
        {
            attackTimer -= Time.deltaTime;
            if (attackTimer <= 0)
            {
                ChangeHitBoxSize(originalHitBoxSize);
                attackCooldown = attackRate;
                attackTimer = 0.75f;
            }
            
            
        }
        
    }

    void ChangeHitBoxSize(Vector2 size)
    {
        hitbox.size = size;
    }
    void Die()
    {
        print("enemy died");
        gameObject.SetActive(false);
        GameObject clone = Instantiate(axeltemPrefab, transform.position, Quaternion.identity);
        //instatiate a coin or something else to drop?
        //maybe with a random range if we drop or not
    }

    void SwitchState(States _state)
    {
        State = _state;
        StartofState = true;
    }

    void onTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerProjectile"))
        {
            health -= 1;
        }
    }
    
}

