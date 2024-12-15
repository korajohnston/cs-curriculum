using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Numerics;
using UnityEngine;
using UnityEngine.Animations;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

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
    public GameObject playerProjectilePrefab;
    private float coolDown;
    private float firerate = 1;
    public float jumpSpeed = 8f;
    private Rigidbody2D rb;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool isTouchingGround;
    private bool isTouchingPlatform; 

    // Start is called before the first frame update
    void Start()
    {
        xspeed = 4;
        xdirection = 0;
        xvector = 0;
        _controller = FindFirstObjectByType<TopDown_AnimatorController>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        xdirection = Input.GetAxis("Horizontal");
        xvector = xdirection * xspeed;
        player.position += new Vector3(xvector, 0, 0) * Time.deltaTime;
        
        ydirection = Input.GetAxis("Vertical");
        yvector = ydirection * yspeed;
        player.position += new Vector3(0, yvector, 0) * Time.deltaTime;
        coolDown -= Time.deltaTime;
       
        if (Input.GetButtonDown("Jump") && isTouchingGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }
        
        // new varob;e is touching
        // in update
        // if isTouchingGround == true || isTouchingPlatform == true
        // {isTouching = true}
        
        //float someValue = 0.4f;
        //Physics2D.Raycast(transform.position, -Vector2.up, someValue);
        //Debug.DrawRay(transform.position, Vector3.down, Color.cyan);
        


        if (Input.GetMouseButton(0))
        {
            GameObject clone = Instantiate(playerProjectilePrefab, transform.position, Quaternion.identity);
            Rigidbody2D cloneRB = clone.GetComponent<Rigidbody2D>();
            coolDown = firerate;
            
            if (_controller.facing == "left")
            {
                cloneRB.AddForce(Vector2.right * 8f, ForceMode2D.Impulse);
            }

            if (_controller.facing == "right")
            {
                cloneRB.AddForce(Vector2.left * 8f, ForceMode2D.Impulse);
            }

            if (_controller.facing == "up")
            {
                cloneRB.AddForce(Vector2.up * 8f, ForceMode2D.Impulse);
            }

            if (_controller.facing == "down")
            {
                cloneRB.AddForce(Vector2.down * 8f, ForceMode2D.Impulse);
            }
           
        }
        
    }
}

