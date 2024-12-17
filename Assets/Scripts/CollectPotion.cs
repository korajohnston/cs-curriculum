using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectPotion : MonoBehaviour
{
    public bool hasPotion;
    public bool hasBigPotion;
    public GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        hasPotion = false;
        hasBigPotion = false;
        gm = FindFirstObjectByType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        print(message: hasPotion);
        gm.timerText.text = "timer: " + gm.timer;
        
        if (hasPotion)
        {
            gm.timer -= Time.deltaTime;
        }
        if (hasBigPotion)
        {
            gm.timer -= Time.deltaTime;
        }

        if (gm.timer <= 0.0f)
        {
            hasPotion = false;
            hasBigPotion = false;
            gm.timer = 0f;
        }
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PinkPotion"))
        {
            hasPotion = true;
            gm.timer = 10f;
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("BigPotion"))
        {
            hasBigPotion = true;
            gm.timer = 20f;
            Destroy(other.gameObject);
        }
    }
}
