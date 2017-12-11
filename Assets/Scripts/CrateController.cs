using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateController : MonoBehaviour {

    private bool inAir = false;
    private int counter = 0;
	private AudioManager audio;

	// Use this for initialization
	void Start () {
		audio = FindObjectOfType<AudioManager>();
	}
	
	// Update is called once per frame
	void Update () { 
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

		/*if (col.gameObject.tag != "Player")
		{
			var velocity = col.relativeVelocity;
			Debug.Log("velocity " + velocity);
			if (velocity.x > 9 || velocity.x < -9)
			{
				audio.Play("boxHitWall");
			}
			//Debug.Log("velocity " + velocity);
			//audio.Play("boxHitWall");
		}*/

		//if (col.gameobject.name != "player" && gameobject.transform.position.y > col.gameobject.transform.position.y)
		//{
		//    inair = false;
		//}
		//else
		//{
		//    inAir = true;
		//}
	}

	void OnCollisionExit2D(Collision2D col)
    {
        counter--;

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
    }

    public bool isCrateInAir()
    {
        return inAir;
    }
}
