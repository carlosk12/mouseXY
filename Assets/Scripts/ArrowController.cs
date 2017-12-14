using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour {

    private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
	    //if(Input.GetKeyDown(KeyCode.A))
     //   {
     //       col.rotate(90);
     //   }

    }

    void FixedUpdate(){
        //if(rb2d.angularVelocity < 0.01f)
        //{
        //    rb2d.angularVelocity = rb2d.angularVelocity / 3;
        //}

        //Debug.Log("AngVel: " + rb2d.angularVelocity);
    }
}
