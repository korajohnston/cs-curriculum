using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public Transform player;
    float xdirection;
    float xspeed;
    float xvector;

    // Start is called before the first frame update
    void Start()
    {
        xspeed = 4;
        xdirection = 0;
        xvector = 0;
    }

    // Update is called once per frame
    void Update()
    {
        xdirection = Input.GetAxis("Horizontal");
        xvector = xdirection * xspeed;
        player.position += new Vector3(xvector, 0, 0) * Time.deltaTime;
    }

}
