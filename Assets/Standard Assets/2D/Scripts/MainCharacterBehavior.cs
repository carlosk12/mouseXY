using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterBehavior : MonoBehaviour {
    // Use this for initialization
    public int playerSpeed = 10;
    public bool facingRight = true;

    public int playerJumpPower = 1250;
    public float moveX;
    public float groundRadius = 0.2f;
    public bool grounded = false;
    public LayerMask whatIsGround;
    bool Levelcomplete;

    private float gravity;

    public Transform groundCheck;

    void Start()
    {
        Levelcomplete = false;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();

        
    }

    /*void OnTriggerEnter2D(Collider2D other)
    {

        //Checks if other gameobject has a Tag of Player
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerController>().alive = false;
            Time.timeScale = 0;
        }
    }*/


    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Physics2D.gravity = new Vector3(-9.81f, 0f, 0f);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            Physics2D.gravity = new Vector3(0f, 9.81f, 0f);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Physics2D.gravity = new Vector3(0f, -9.81f, 0f);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Physics2D.gravity = new Vector3(9.81f, 0f, 0f);
        }
    }

    void PlayerMove()
    {
        //aontrols66 
        moveX = Input.GetAxis("Horizontal");
        //animation
        //player direction
        if (Input.GetButton("Jump"))
        {
            Jump();
        }

        //grounded = Physics2D;

        if (moveX < 0.0f && facingRight == true)
        {
            flipPlayer();
        }
        else if (moveX > 0.0f && facingRight == false)
        {
            flipPlayer();
        }

        //physics
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }

    void Jump()
    {
        //jumping code
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);
    }



    void flipPlayer()
    {
        facingRight = !facingRight;
        Vector2 localScale = gameObject.transform.localScale;
        transform.localScale = localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

}
