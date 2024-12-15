using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDectector : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isGrounded;
    public bool check;
    // Update is called once per frame
    void Update()
    {
        if (isGrounded != true)
        {
            check = false;
        }
    }
}
