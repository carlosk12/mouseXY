using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MouePLayerController : MonoBehaviour {

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
	private AudioManager audio;
    private mouseSprite mouseSp;

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

		transform.GetChild(1).gameObject.SetActive(false);
		transform.GetChild(2).gameObject.SetActive(true);
		transform.GetChild(3).gameObject.SetActive(false);
		transform.GetChild(4).gameObject.SetActive(true);
		transform.GetChild(5).gameObject.SetActive(false);
		transform.GetChild(6).gameObject.SetActive(false);
	}

	void FixedUpdate()
	{
		if (isUpOrDown)
		{
			PlayerMoveUD();
		}
		else
		{
			PlayerMoveLR();
		}

		if (jump)
		{
			Jump();
			jump = false;
		}
	}

	void Update()
	{

		if (Input.GetKeyDown(KeyCode.Space) && !inAir)
		{
			audio.Play("mouseJump");
			jump = true;
		}

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }

		/**
		 * A = Gravity pulls you towards the left
		 * S = Gravity pulls you towards the bottom
		 * W = Gravity pulls you towards the top
		 * D = Gravity pulls you towards the right
		 * */
		if (Input.GetKeyDown(KeyCode.LeftArrow))
		{

			Physics2D.gravity = new Vector2(-9.81F, 0);
			transform.GetChild(1).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.transform.localScale = new Vector3(1, 1, 1);
            transform.GetChild(2).gameObject.SetActive(false);

			transform.GetChild(3).gameObject.SetActive(false);
			transform.GetChild(4).gameObject.SetActive(false);
			transform.GetChild(5).gameObject.SetActive(true);
			transform.GetChild(6).gameObject.SetActive(false);

			isUpOrDown = false;
			normal = Vector2.right;

			if (!facingRight)
			{
				flipPlayerX();
			}

			if (!gravityLeft)
			{
				audio.Play("gravityLeftRight");
			}
			gravityRight = false;
			gravityUp = false;
			gravityDown = false;
			gravityLeft = true;
		}
		else if (Input.GetKeyDown(KeyCode.DownArrow))
		{
			Physics2D.gravity = new Vector2(0, -9.81F);
			transform.GetChild(1).gameObject.SetActive(false);
			transform.GetChild(2).gameObject.SetActive(true);
            //transform.GetChild(2).gameObject.transform.localScale = new Vector3(1, 1, 1);

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

			if (!gravityDown)
			{
				audio.Play("gravityUpDown");
			}
			gravityRight = false;
			gravityUp = false;
			gravityDown = true;
			gravityLeft = false;
		}
		else if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			Physics2D.gravity = new Vector2(0, 9.81F);
			transform.GetChild(1).gameObject.SetActive(false);
			transform.GetChild(2).gameObject.SetActive(true);
            //transform.GetChild(2).gameObject.transform.localScale = new Vector3(1, -1, 1);

            transform.GetChild(3).gameObject.SetActive(true);
			transform.GetChild(4).gameObject.SetActive(false);
			transform.GetChild(5).gameObject.SetActive(false);
			transform.GetChild(6).gameObject.SetActive(false);
			normal = Vector2.down;
			isUpOrDown = true;

			if (facingUp)
			{
				flipPlayerY();
			}

			if (!gravityUp)
			{
				audio.Play("gravityUpDown");
			}
			gravityRight = false;
			gravityUp = true;
			gravityDown = false;
			gravityLeft = false;
		}
		else if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			Physics2D.gravity = new Vector2(9.81F, 0);
			transform.GetChild(1).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.transform.localScale = new Vector3(1, -1, 1);
            transform.GetChild(2).gameObject.SetActive(false);

			transform.GetChild(3).gameObject.SetActive(false);
			transform.GetChild(4).gameObject.SetActive(false);
			transform.GetChild(5).gameObject.SetActive(false);
			transform.GetChild(6).gameObject.SetActive(true);
			normal = Vector2.left;
			isUpOrDown = false;

			if (!facingRight)
			{
				flipPlayerX();
			}

			if (!gravityRight)
			{
				audio.Play("gravityLeftRight");
			}
			gravityRight = true;
			gravityUp = false;
			gravityDown = false;
			gravityLeft = false;
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

        if (moveHor < 0 && facingRight == true)
		{

            flipPlayerX();
            if(facingUp)
            {
                Debug.Log("Vinstri Niður");
                //transform.GetChild(2).gameObject.transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                Debug.Log("Vinstri Upp");
                //transform.GetChild(2).gameObject.transform.localScale = new Vector3(1, -1, 1);
            }
            
        }
		else if (moveHor > 0 && facingRight == false)
		{
			flipPlayerX();
            if (facingUp)
            {
                Debug.Log("Hægri Niður");
                //transform.GetChild(2).gameObject.transform.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                Debug.Log("Vinstri Upp");
                //transform.GetChild(2).gameObject.transform.localScale = new Vector3(-1, -1, 1);
            }
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

	void PlayerMoveLR()
	{
		float moveHor = Input.GetAxis("Horizontal");
		float moveVer = Input.GetAxis("Vertical");

		if (moveVer < 0 && facingUp == false)
		{
			flipPlayerY();

            transform.GetChild(1).gameObject.transform.localScale = new Vector3(1, 1, 1);
            //mouseSp.anim.enabled = true;
        }
		else if (moveVer > 0 && facingUp == true)
		{
			flipPlayerY();
            transform.GetChild(1).gameObject.transform.localScale = new Vector3(-1, 1, 1);
            //mouseSp.anim.enabled = true;
        }
        else if (moveHor == 0 && moveVer == 0)
        {
            //mouseSp.anim.enabled = false;
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

	void flipPlayerX()
	{
        //GetComponentInChildren<mouseSprite>().flipPlayerX();
        mouseSp.flipPlayerX();

		facingRight = !facingRight;
	}

	void flipPlayerY()
	{
        //GetComponentInChildren<mouseSprite>().flipPlayerY();
        mouseSp.flipPlayerY();

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

		if (counter == 0)
		{
			inAir = true;
		}
	}
}
