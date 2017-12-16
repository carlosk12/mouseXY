using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePlayerController : MonoBehaviour {

    public float speed;
    private Rigidbody2D rb2d;
    private GameObject upDownColBox;
    private GameObject leftRightColBox;
    private bool isUpOrDown = true;
    private bool inAir = false;
    private Vector2 normal;
    private CrateController bla;
    private bool facingRight = false;
    private bool feetUp = false;
    private bool facingUp = true;
    private bool feetLeft = true;
    private AudioManager audio;
    private mouseSprite mouseSp;
    private int collisionID = 1;

    // indicates what direction the gravity is pulling
    private bool gravityRight = false;
    private bool gravityUp = false;
    private bool gravityDown = true; // <- default starting gravity
    private bool gravityLeft = false;

    private int counter = 0;
    bool jump;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        audio = FindObjectOfType<AudioManager>();
        mouseSp = GetComponentInChildren<mouseSprite>();
    }

    void Start()
    {
        Physics2D.gravity = new Vector2(0, -9.81f);

        normal = Vector2.up;

        transform.GetChild(1).gameObject.SetActive(false);  //LeftRightCol
        transform.GetChild(2).gameObject.SetActive(true);   //UpDownCol
        //transform.GetChild(7).gameObject.SetActive(false);  //RightCol
        //transform.GetChild(8).gameObject.SetActive(false);  //UpCol

        transform.GetChild(3).gameObject.SetActive(false);  //Top
        transform.GetChild(4).gameObject.SetActive(true);   //Bottom
        transform.GetChild(5).gameObject.SetActive(false);  //Left
        transform.GetChild(6).gameObject.SetActive(false);  //Right
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !inAir)
        {
            audio.Play("mouseJump");
            jump = true;
        }

        /**
         * A = Gravity pulls you towards the left
         * S = Gravity pulls you towards the bottom
         * W = Gravity pulls you towards the top
         * D = Gravity pulls you towards the right
         * */
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Physics2D.gravity = new Vector2(0, -9.81F);

            transform.GetChild(1).gameObject.SetActive(false);  //LeftRightCol  
            transform.GetChild(2).gameObject.SetActive(true);   //UpDownCol
            //transform.GetChild(7).gameObject.SetActive(false);  //RightCol
            //transform.GetChild(8).gameObject.SetActive(false);  //UpCol

            transform.GetChild(3).gameObject.SetActive(false);  //Top
            transform.GetChild(4).gameObject.SetActive(true);   //Bottom
            transform.GetChild(5).gameObject.SetActive(false);  //Left
            transform.GetChild(6).gameObject.SetActive(false);  //Right


            if (!gravityDown)
            {
                audio.Play("gravityUpDown");
            }

            gravityRight = false;
            gravityUp = false;
            gravityDown = true;
            gravityLeft = false;

            feetUp = false;
            //facingRight = false;
            feetLeft = true;
            facingUp = true;

            if(!facingRight)
            {
                GetComponentInChildren<mouseSprite>().flipPlayerX(false);
            }
            GetComponentInChildren<mouseSprite>().flipPlayerY(false);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Physics2D.gravity = new Vector2(0, 9.81F);

            transform.GetChild(1).gameObject.SetActive(false);  //LeftRightCol
            transform.GetChild(2).gameObject.SetActive(true);  //UpDownCol
            //transform.GetChild(7).gameObject.SetActive(false);  //RightCol
            //transform.GetChild(8).gameObject.SetActive(true);   //UpCol

            transform.GetChild(3).gameObject.SetActive(true);   //Top
            transform.GetChild(4).gameObject.SetActive(false);  //Bottom
            transform.GetChild(5).gameObject.SetActive(false);  //Left
            transform.GetChild(6).gameObject.SetActive(false);  //Right


            if (!gravityUp)
            {
                audio.Play("gravityUpDown");
            }

            gravityRight = false;
            gravityUp = true;
            gravityDown = false;
            gravityLeft = false;

            feetUp = true;
            //facingRight = false;
            feetLeft = true;
            facingUp = true;

            if (!facingRight)
            {
                GetComponentInChildren<mouseSprite>().flipPlayerX(false);
            }
            GetComponentInChildren<mouseSprite>().flipPlayerY(false);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Physics2D.gravity = new Vector2(-9.81F, 0);

            transform.GetChild(1).gameObject.SetActive(true);  //LeftRightCol
            transform.GetChild(2).gameObject.SetActive(false);  //UpDownCol
            //transform.GetChild(7).gameObject.SetActive(false);  //RightCol
            //transform.GetChild(8).gameObject.SetActive(false);   //UpCol

            transform.GetChild(3).gameObject.SetActive(false);   //Top
            transform.GetChild(4).gameObject.SetActive(false);  //Bottom
            transform.GetChild(5).gameObject.SetActive(true);  //Left
            transform.GetChild(6).gameObject.SetActive(false);  //Right


            if (!gravityLeft)
            {
                audio.Play("gravityLeftRight");
            }

            gravityRight = false;
            gravityUp = false;
            gravityDown = false;
            gravityLeft = true;

            feetUp = false;
            facingRight = false;
            feetLeft = true;
            facingUp = true;

            if (!facingUp)
            {
                GetComponentInChildren<mouseSprite>().flipPlayerY(false);
            }
            GetComponentInChildren<mouseSprite>().flipPlayerX(false);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Physics2D.gravity = new Vector2(9.81F, 0);

            transform.GetChild(1).gameObject.SetActive(true);  //LeftRightCol
            transform.GetChild(2).gameObject.SetActive(false);  //UpDownCol
            //transform.GetChild(7).gameObject.SetActive(true);  //RightCol
            //transform.GetChild(8).gameObject.SetActive(false);   //UpCol

            transform.GetChild(3).gameObject.SetActive(false);   //Top
            transform.GetChild(4).gameObject.SetActive(false);  //Bottom
            transform.GetChild(5).gameObject.SetActive(false);  //Left
            transform.GetChild(6).gameObject.SetActive(true);  //Right


            if (!gravityRight)
            {
                audio.Play("gravityLeftRight");
            }

            gravityRight = true;
            gravityUp = false;
            gravityDown = false;
            gravityLeft = false;

            feetUp = false;
            facingRight = false;
            feetLeft = false;
            facingUp = true;

            if (!facingUp)
            {
                GetComponentInChildren<mouseSprite>().flipPlayerY(false);
            }
            GetComponentInChildren<mouseSprite>().flipPlayerX(false);
        }
    }

    void FixedUpdate()
    {
        if (jump)
        {
            Jump();
            jump = false;
        }

        if(gravityDown)
        {
            PlayerMoveDown();
        }
        else if(gravityUp)
        {
            PlayerMoveUp();
        }
        else if(gravityLeft)
        {
            PlayerMoveLeft();
        }
        else if(gravityRight)
        {
            PlayerMoveRight();
        }
    }

    private void PlayerMoveDown()
    {
        float moveHor = Input.GetAxis("Horizontal");
        float moveVer = Input.GetAxis("Vertical");

        if(moveHor < 0)
        {
            GetComponentInChildren<mouseSprite>().flipPlayerX(false);
            //transform.GetChild(2).gameObject.transform.localScale = new Vector3(1, 1, 1);

            facingRight = false;
        }
        else if(moveHor > 0)
        {
            GetComponentInChildren<mouseSprite>().flipPlayerX(true);
            //transform.GetChild(2).gameObject.transform.localScale = new Vector3(-1, 1, 1);

            facingRight = true;
        }

        if (facingRight)
        {
            //transform.GetChild(2).gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }

        if (inAir)
        {
            speed = 6;
            if (rb2d.velocity.x >= -4.5f && rb2d.velocity.x <= 4.5f)
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x + moveHor * speed * Time.fixedDeltaTime, rb2d.velocity.y);
            }
        }
        else
        {
            speed = 250;
            rb2d.velocity = new Vector2(moveHor * speed * Time.fixedDeltaTime, rb2d.velocity.y);
        }
    }

    private void PlayerMoveUp()
    {
        float moveHor = Input.GetAxis("Horizontal");
        float moveVer = Input.GetAxis("Vertical");

        if (moveHor < 0)
        {
            GetComponentInChildren<mouseSprite>().flipPlayerX(false);
            //transform.GetChild(8).gameObject.transform.localScale = new Vector3(1, -1, 1);

            facingRight = false;
        }
        else if (moveHor > 0)
        {
            GetComponentInChildren<mouseSprite>().flipPlayerX(true);
            //transform.GetChild(8).gameObject.transform.localScale = new Vector3(-1, -1, 1);

            facingRight = true;
        }

        if (facingRight)
        {
            //transform.GetChild(8).gameObject.transform.localScale = new Vector3(-1, -1, 1);
        }

        if (!feetUp)
        {
            //GetComponentInChildren<mouseSprite>().flipPlayerY();

            feetUp = true;
        }

        if (inAir)
        {
            speed = 6;
            if (rb2d.velocity.x >= -4.5f && rb2d.velocity.x <= 4.5f)
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x + moveHor * speed * Time.fixedDeltaTime, rb2d.velocity.y);
            }
        }
        else
        {
            speed = 250;
            rb2d.velocity = new Vector2(moveHor * speed * Time.fixedDeltaTime, rb2d.velocity.y);
        }
    }

    private void PlayerMoveLeft()
    {
        float moveHor = Input.GetAxis("Horizontal");
        float moveVer = Input.GetAxis("Vertical");

        if (moveVer < 0)
        {
            GetComponentInChildren<mouseSprite>().flipPlayerY(true);
            //transform.GetChild(1).gameObject.transform.localScale = new Vector3(1, 1, 1);

            facingUp = false;
        }
        else if (moveVer > 0)
        {
            GetComponentInChildren<mouseSprite>().flipPlayerY(false);
            //transform.GetChild(1).gameObject.transform.localScale = new Vector3(-1, 1, 1);

            facingUp = true;
        }

        if(!facingUp)
        {
            //transform.GetChild(1).gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }

        if (!feetLeft)
        {
            //GetComponentInChildren<mouseSprite>().flipPlayerX();

            feetLeft = true;
        }

        if (inAir)
        {
            speed = 6;
            if (rb2d.velocity.y >= -4.5f && rb2d.velocity.y <= 4.5f)
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, rb2d.velocity.y + moveVer * speed * Time.fixedDeltaTime);
            }
        }
        else
        {
            speed = 250;
            rb2d.velocity = new Vector2(rb2d.velocity.x, moveVer * speed * Time.fixedDeltaTime);
        }
    }

    private void PlayerMoveRight()
    {
        float moveHor = Input.GetAxis("Horizontal");
        float moveVer = Input.GetAxis("Vertical");

        if (moveVer < 0)
        {
            GetComponentInChildren<mouseSprite>().flipPlayerY(true);
            //transform.GetChild(7).gameObject.transform.localScale = new Vector3(1, -1, 1);

            facingUp = false;
        }
        else if (moveVer > 0)
        {
            GetComponentInChildren<mouseSprite>().flipPlayerY(false);
            //transform.GetChild(7).gameObject.transform.localScale = new Vector3(-1, -1, 1);

            facingUp = true;
        }

        if(!facingUp)
        {
            //transform.GetChild(7).gameObject.transform.localScale = new Vector3(-1, -1, 1);
        }

        if (feetLeft)
        {
            //GetComponentInChildren<mouseSprite>().flipPlayerX();

            feetLeft = true;
        }

        if (inAir)
        {
            speed = 6;
            if (rb2d.velocity.y >= -4.5f && rb2d.velocity.y <= 4.5f)
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, rb2d.velocity.y + moveVer * speed * Time.fixedDeltaTime);
            }
        }
        else
        {
            speed = 250;
            rb2d.velocity = new Vector2(rb2d.velocity.x, moveVer * speed * Time.fixedDeltaTime);
        }
    }

    void Jump()
    {
        rb2d.AddForce(-(Physics2D.gravity) * 30);
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
