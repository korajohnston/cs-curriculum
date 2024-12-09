using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectPotion : MonoBehaviour
{
    public bool hasPotion;
    //public float timer = 10.0f;
    public GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        hasPotion = false;
        gm = FindFirstObjectByType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        print(message: hasPotion);
        gm.timerText.text = "timer: " + gm.timer;
        
        if (hasPotion == true)
        {
            gm.timer -= Time.deltaTime;
        }

        if (gm.timer <= 0.0f)
        {
            hasPotion = false;
        }
        
        if (hasPotion == false)
        {
            gm.timer = 10f;
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
