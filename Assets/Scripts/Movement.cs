using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Transform player;
    float xdirection;
    float xspeed;
    float xvector;
    float ydirection;
    [SerializeField]
    float yspeed;
    private float yvector;
    public TopDown_AnimatorController _controller;
    public Animator animator;
    public int WalkDir;
    public GameObject playerProjectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        xspeed = 4;
        xdirection = 0;
        xvector = 0;
        // get animator somehow C:
    }

    // Update is called once per frame
    void Update()
    {
        WalkDir = animator.GetInteger("WalkDir");
        xdirection = Input.GetAxis("Horizontal");
        xvector = xdirection * xspeed;
        player.position += new Vector3(xvector, 0, 0) * Time.deltaTime;

        ydirection = Input.GetAxis("Vertical");
        yvector = ydirection * yspeed;
        player.position += new Vector3(0, yvector, 0) * Time.deltaTime;
        
        if (Input.GetMouseButton(0))
        {
            GameObject clone = Instantiate(playerProjectilePrefab, transform.position, Quaternion.identity);
            Rigidbody2D cloneRB = clone.GetComponent<Rigidbody2D>();

            if (WalkDir == 1 && Input.GetAxis("Horizontal") < 0)
            {
                cloneRB.AddForce(Vector2.left);
            }
            if (WalkDir == 1 && Input.GetAxis("Horizontal") > 0)
            {
                cloneRB.AddForce(Vector2.right);
            }
            if (WalkDir == 0)
            {
                cloneRB.AddForce(Vector2.up);
            }
            if (WalkDir == 2)
            {
                cloneRB.AddForce(Vector2.down);
            }

        }
    }

}
