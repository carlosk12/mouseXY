using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    private Rigidbody2D rb2d;
    private GameObject upDownColBox;
    private GameObject leftRightColBox;
    private bool isUpOrDown = true;
    //private bool inAir = false;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

	// Use this for initialization
	void Start () {

        Physics2D.gravity = new Vector3(0, -9.81F, 0);
    
        transform.GetChild(1).gameObject.SetActive(false);
        transform.GetChild(2).gameObject.SetActive(true);
    }
	
    void Update() { }

    void FixedUpdate ()
    {
        if(isUpOrDown)
        {
            PlayerMoveUD();
        }
        else
        {
            PlayerMoveLR();
        }

        if(Input.GetKeyUp(KeyCode.Space))
        {
            //gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
            rb2d.velocity = new Vector2(0, 5);
            //inAir = true;
        }
        
        //Vector2 movement = new Vector2(speed, 0);

        //rb2d.AddForce(movement);
        //gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveHor * speed, gameObject.GetComponent<Rigidbody2D>().velocity.y);

        //if (Input.GetKeyDown(KeyCode.LeftArrow))
        //{
        //    //rb2d.AddForce(new Vector2(speed, 0));
        //    gameObject.GetComponent<Rigidbody2D>().velocity = -movement;
        //}
        //else if (Input.GetKeyDown(KeyCode.RightArrow))
        //{
        //    //rb2d.AddForce(new Vector2(speed, 0));
        //    gameObject.GetComponent<Rigidbody2D>().velocity = movement;
        //}

        if (Input.GetKeyDown(KeyCode.A))
        {
            print("A");
            Physics2D.gravity = new Vector3(-9.81F, 0, 0);
            transform.GetChild(1).gameObject.SetActive(true);
            transform.GetChild(2).gameObject.SetActive(false);
            isUpOrDown = false;
            //rb2d.MoveRotation(-90);
        }
        else if(Input.GetKeyDown(KeyCode.S))
        {
            print("S");
            Physics2D.gravity = new Vector3(0, -9.81F, 0);
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(true);
            isUpOrDown = true;
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            print("W");
            Physics2D.gravity = new Vector3(0, 9.81F, 0);
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(true);
            isUpOrDown = true;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            print("D");
            Physics2D.gravity = new Vector3(9.81F, 0, 0);
            transform.GetChild(1).gameObject.SetActive(true);
            transform.GetChild(2).gameObject.SetActive(false);
            isUpOrDown = false;
        }

        //if (Input.GetKeyUp(KeyCode.LeftArrow))
        //{
        //    rb2d.velocity = Vector2.zero;
        //    rb2d.angularVelocity = 0;
        //}
        //else if (Input.GetKeyUp(KeyCode.DownArrow))
        //{
        //    rb2d.velocity = Vector2.zero;
        //    rb2d.angularVelocity = 0;
        //}
        //else if (Input.GetKeyUp(KeyCode.UpArrow))
        //{
        //    rb2d.velocity = Vector2.zero;
        //    rb2d.angularVelocity = 0;
        //}
        //else if (Input.GetKeyUp(KeyCode.RightArrow))
        //{
        //    rb2d.velocity = Vector2.zero;
        //    rb2d.angularVelocity = 0;
        //}
    }

    void PlayerMoveUD()
    {
        float moveHor = Input.GetAxis("Horizontal");
        float moveVer = Input.GetAxis("Vertical");

        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveHor * speed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
        //gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveHor * speed, moveVer * speed);
        //rb2d.AddForce(new Vector2(moveHor * speed, rb2d.velocity.y));
    }

    void PlayerMoveLR()
    {
        float moveHor = Input.GetAxis("Horizontal");
        float moveVer = Input.GetAxis("Vertical");

        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x, moveVer * speed);
        //gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveVer * speed, moveHor * speed);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.name == "CratePink")
        {
            col.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.name == "CratePink")
        {
            col.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;

        }
    }
}
