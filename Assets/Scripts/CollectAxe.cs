using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollectAxe : MonoBehaviour
{
    private int axe;
    private bool HasAxe = false;
    private TopDown_AnimatorController _animator;

    // Start is called before the first frame update
    void Start()
    {
        HasAxe = false;
        _animator = GetComponentInChildren<TopDown_AnimatorController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Axe"))
        {
            HasAxe = true;
            _animator.SwitchToAxe();
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("CollisionDoor"))
        {
            if (HasAxe)
            {
                other.gameObject.SetActive(false);
            }

            if (HasAxe == false)
            {
                other.gameObject.SetActive(true);
            }
        }
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.gameObject.CompareTag("WoodDoor"))
        {
            if (HasAxe)
            {
                Destroy(other.gameObject);
            }

            if (HasAxe == false)
            {
                other.gameObject.SetActive(true);
            }
        }
    }
}

    

