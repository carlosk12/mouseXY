using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateController : MonoBehaviour {

    private bool inAir = false;
    private int counter = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(inAir);
	}

    void Rest()
    {
        Debug.Log("Bla");
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        counter++;

        if (col.gameObject.tag == "Player" && counter > 1)
        {
            if (-Physics2D.gravity.normalized == Vector2.up || -Physics2D.gravity.normalized == Vector2.down)
            {
                GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
            }
            else if (-Physics2D.gravity.normalized == Vector2.left || -Physics2D.gravity.normalized == Vector2.right)
            {
                GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
            }
        }
        if (col.gameObject.name != "Player" && gameObject.transform.position.y > col.gameObject.transform.position.y)
        {
            inAir = false;
        }
        else
        {
            inAir = true;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag != "Player")
        {
            counter--;
        }

        if (col.gameObject.tag == "Player")
        {
            if (-Physics2D.gravity.normalized == Vector2.up || -Physics2D.gravity.normalized == Vector2.down)
            {
                GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            }
            else if (-Physics2D.gravity.normalized == Vector2.left || -Physics2D.gravity.normalized == Vector2.right)
            {
                GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            }
        }


        //if(counter == 0 && )
    }

    public bool isCrateInAir()
    {
        return inAir;
    }
}
