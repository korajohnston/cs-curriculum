using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectPotion : MonoBehaviour
{
    public bool hasPotion;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        hasPotion = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (hasPotion == true)
        {
            timer = 4;
        }

        if (timer <= 0)
        {
            hasPotion = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PinkPotion"))
        {
            hasPotion = true;
            Destroy(other);
        }
    }
}
