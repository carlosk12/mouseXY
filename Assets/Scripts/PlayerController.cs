using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    private Rigidbody2D rb2d;
    private GameObject upDownColBox;
    private GameObject leftRightColBox;
    private bool isUpOrDown = true;
    private bool inAir = false;
    private Vector2 normal;
    private CrateController bla;
    private bool facingRight = false;
    private bool facingUp = false;
    private int counter = 0;
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    
	void Start () {

        Physics2D.gravity = new Vector2(0, -9.81f);

        normal = Vector2.up;
    
        transform.GetChild(1).gameObject.SetActive(false);
        transform.GetChild(2).gameObject.SetActive(true);
        transform.GetChild(3).gameObject.SetActive(false);
        transform.GetChild(4).gameObject.SetActive(true);
        transform.GetChild(5).gameObject.SetActive(false);
        transform.GetChild(6).gameObject.SetActive(false);
    }
	
    void Update()
    {
    }

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

        if(Input.GetKeyDown(KeyCode.Space) && !inAir)
        {
            Jump();
        }
        
        /**
         * A = Gravity pulls you towards the left
         * S = Gravity pulls you towards the bottom
         * W = Gravity pulls you towards the top
         * D = Gravity pulls you towards the right
         * */
        if (Input.GetKeyDown(KeyCode.A))
        {
            Physics2D.gravity = new Vector2(-9.81F, 0);
            transform.GetChild(1).gameObject.SetActive(true);
            transform.GetChild(2).gameObject.SetActive(false);

            transform.GetChild(3).gameObject.SetActive(false);
            transform.GetChild(4).gameObject.SetActive(false);
            transform.GetChild(5).gameObject.SetActive(true);
            transform.GetChild(6).gameObject.SetActive(false);

            isUpOrDown = false;
            normal = Vector2.right;

            if(facingRight)
            {
                flipPlayerX();
            }
        }
        else if(Input.GetKeyDown(KeyCode.S))
        {
            Physics2D.gravity = new Vector2(0, -9.81F);
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(true);

            transform.GetChild(3).gameObject.SetActive(false);
            transform.GetChild(4).gameObject.SetActive(true);
            transform.GetChild(5).gameObject.SetActive(false);
            transform.GetChild(6).gameObject.SetActive(false);
            normal = Vector2.up;
            isUpOrDown = true;

            if (facingUp)
            {
                flipPlayerY();
            }
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            Physics2D.gravity = new Vector2(0, 9.81F);
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(true);

            transform.GetChild(3).gameObject.SetActive(true);
            transform.GetChild(4).gameObject.SetActive(false);
            transform.GetChild(5).gameObject.SetActive(false);
            transform.GetChild(6).gameObject.SetActive(false);
            normal = Vector2.down;
            isUpOrDown = true;

            if(facingUp)
            {
                flipPlayerY();
            }
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Physics2D.gravity = new Vector2(9.81F, 0);
            transform.GetChild(1).gameObject.SetActive(true);
            transform.GetChild(2).gameObject.SetActive(false);

            transform.GetChild(3).gameObject.SetActive(false);
            transform.GetChild(4).gameObject.SetActive(false);
            transform.GetChild(5).gameObject.SetActive(false);
            transform.GetChild(6).gameObject.SetActive(true);
            normal = Vector2.left;
            isUpOrDown = false;

            if (facingRight)
            {
                flipPlayerX();
            }
        }
    }

    void Jump()
    {
        rb2d.AddForce(-(Physics2D.gravity) * 30);
    }

    void PlayerMoveUD()
    {
        float moveHor = Input.GetAxis("Horizontal");
        float moveVer = Input.GetAxis("Vertical");

        if(moveHor < 0 && facingRight == false)
        {
            flipPlayerX();
        }
        else if(moveHor > 0 && facingRight == true)
        {
            flipPlayerX();
        }

        if (inAir)
        {
            speed = 6;
            if (rb2d.velocity.x >= -4.5f && rb2d.velocity.x <= 4.5f)
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x + moveHor * speed * Time.deltaTime, rb2d.velocity.y);
            }
        }
        else
        {
            speed = 250;
            rb2d.velocity = new Vector2(moveHor * speed * Time.deltaTime, rb2d.velocity.y);
        }
    }

    void PlayerMoveLR()
    {
        float moveHor = Input.GetAxis("Horizontal");
        float moveVer = Input.GetAxis("Vertical");

        if (moveVer < 0 && facingUp == false)
        {
            flipPlayerY();
        }
        else if (moveVer > 0 && facingUp == true)
        {
            flipPlayerY();
        }

        if (inAir)
        {
            speed = 6;
            if(rb2d.velocity.y >= -4.5f && rb2d.velocity.y <= 4.5f)
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, rb2d.velocity.y + moveVer * speed * Time.deltaTime);
            }
        }
        else
        {
            speed = 250;
            rb2d.velocity = new Vector2(rb2d.velocity.x, moveVer * speed * Time.deltaTime);
        }

    }

    void flipPlayerX()
    {
        GetComponentInChildren<mouseSprite>().flipPlayerX();
        
        facingRight = !facingRight;
    }

    void flipPlayerY()
    {
        GetComponentInChildren<mouseSprite>().flipPlayerY();

        facingUp = !facingUp;
    }

    void OnCollisionEnter2D(Collision2D col)
    {

    }

    void OnCollisionExit2D(Collision2D col)
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        counter++;

        inAir = false;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        counter--;

        if(counter == 0)
        {
            inAir = true;
        }
    }
}
