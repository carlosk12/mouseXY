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

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    
	void Start () {

        Physics2D.gravity = new Vector2(0, -9.81f);

        normal = Vector2.up;
    
        transform.GetChild(1).gameObject.SetActive(false);
        transform.GetChild(2).gameObject.SetActive(true);
        transform.GetChild(5).gameObject.SetActive(false);
        transform.GetChild(6).gameObject.SetActive(false);
    }
	
    void Update()
    {
        //Debug.Log(inAir);
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

        if(Input.GetKeyUp(KeyCode.Space) && !inAir)
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
            transform.GetChild(6).gameObject.SetActive(true);

            isUpOrDown = false;
            normal = Vector2.right;

            if(facingRight)
            {
                flipPlayerX();
            }
            //rb2d.MoveRotation(-90);
        }
        else if(Input.GetKeyDown(KeyCode.S))
        {
            Physics2D.gravity = new Vector2(0, -9.81F);
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(true);

            transform.GetChild(3).gameObject.SetActive(true);
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
            transform.GetChild(4).gameObject.SetActive(true);
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
            transform.GetChild(5).gameObject.SetActive(true);
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
        Debug.Log("Jump");
        inAir = true;
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

        rb2d.velocity = new Vector2(moveHor * speed, rb2d.velocity.y);
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

        rb2d.velocity = new Vector2(rb2d.velocity.x, moveVer * speed);
        //gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveVer * speed, moveHor * speed);
    }

    void flipPlayerX()
    {
        //transform.Find("mouseSprite").flipPlayer();
        //.GetComponent<mouseSprite>().flipPlayer();
        GetComponentInChildren<mouseSprite>().flipPlayerX();

        //transform.Find("mouseSprite").GetComponents<mouseSprite>().flipPlayer();
        facingRight = !facingRight;
    }

    void flipPlayerY()
    {
        GetComponentInChildren<mouseSprite>().flipPlayerY();

        facingUp = !facingUp;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //if (col.gameObject.name == "CratePink" && col.gameObject.GetComponent<CrateController>().isCrateInAir())
        //{
        //    col.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        //}

        if (normal == Vector2.up)
        {
            Debug.Log("Collision object:" + col.gameObject.name + ", normal: " + col.contacts[0].normal.ToString("#.000") + ", lenght: " + col.contacts.Length);

            foreach (ContactPoint2D cl in col.contacts)
            {
                if(cl.normal.Equals(Vector2.up))
                {
                    inAir = false;
                }
            }

            Debug.Log("inAir: " + inAir);
            //if (col.contacts[0].normal == Vector2.up)
            //{
            //    inAir = false;
            //}
            //if (col.gameObject.transform.position.y < gameObject.transform.position.y)
            //{
            //    inAir = false;
            //}
        }
        else if (normal == Vector2.down)
        {
            if (col.contacts[0].normal == Vector2.down)
            {
                inAir = false;
            }
            //if (col.gameObject.transform.position.y > gameObject.transform.position.y)
            //{
            //    inAir = false;
            //}
        }
        else if (normal == Vector2.left)
        {
            if (col.contacts[0].normal == Vector2.left)
            {
                inAir = false;
            }
            //if (col.gameObject.transform.position.x > gameObject.transform.position.x)
            //{
            //    inAir = false;
            //}
        }
        else if (normal == Vector2.right)
        {
            if (col.contacts[0].normal == Vector2.right)
            {
                inAir = false;
            }
            //if (col.gameObject.transform.position.x < gameObject.transform.position.x)
            //{
            //    inAir = false;
            //}
        }

        //if (col.gameObject.transform.position.y < gameObject.transform.position.y)
        //{
        //    inAir = false;
        //}
    }

    void OnCollisionExit2D(Collision2D col)
    {
        //if (col.gameObject.name == "CratePink")
        //{
        //    col.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        //}

        //if (normal == Vector2.up)
        //{
        //    if (col.gameObject.transform.position.y > gameObject.transform.position.y)
        //    {
        //        inAir = true;
        //    }
        //}
        //else if (normal == Vector2.down)
        //{
        //    if (col.gameObject.transform.position.y < gameObject.transform.position.y)
        //    {
        //        inAir = true;
        //    }
        //}
        //else if (normal == Vector2.left)
        //{
        //    if (col.gameObject.transform.position.x < gameObject.transform.position.x)
        //    {
        //        inAir = true;
        //    }
        //}
        //else if (normal == Vector2.right)
        //{
        //    if (col.gameObject.transform.position.x > gameObject.transform.position.x)
        //    {
        //        inAir = true;
        //    }
        //}

        //if (!(col.gameObject.name == "CratePink"))
        //{
        //inAir = true;
        //}
    }
}
