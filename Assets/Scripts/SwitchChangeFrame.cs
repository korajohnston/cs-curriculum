using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchChangeFrame : MonoBehaviour
{
    public Sprite[] sprites;
    private SpriteRenderer spriteRenderer;
    private int currentSpriteIndex;
    // Start is called before the first frame update
    void Start()
    {
       spriteRenderer = GetComponent<SpriteRenderer>();

       if (sprites.Length == 0)
       {
           Debug.LogError("No Sprite Selected");
       }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (sprites.Length > 0)
            {
                currentSpriteIndex = (currentSpriteIndex + 1) % sprites.Length;
                spriteRenderer.sprite = sprites[currentSpriteIndex];
                Debug.Log("Sprite changed to: " + spriteRenderer.sprite.name);
            }
        }
    }
}
