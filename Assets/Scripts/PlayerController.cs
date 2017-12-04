using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    private Rigidbody2D rb2d;
    private GameObject upDownColBox;
    private GameObject leftRightColBox;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();

        Physics2D.gravity = new Vector3(0, -9.81F, 0);


        transform.GetChild(1).gameObject.SetActive(false);
        transform.GetChild(2).gameObject.SetActive(true);

        //rb2d.freezeRotation = true;
    }
	
    void Update() {
    }

    void FixedUpdate () {
        float moveHor = Input.GetAxis("Horizontal");
        float moveVer = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHor * speed, moveVer * speed);

        rb2d.AddForce(movement);

        if (Input.GetKeyDown(KeyCode.A))
        {
            print("A");
            Physics2D.gravity = new Vector3(-9.81F, 0, 0);
            transform.GetChild(1).gameObject.SetActive(true);
            transform.GetChild(2).gameObject.SetActive(false);
            //rb2d.MoveRotation(-90);
        }
        else if(Input.GetKeyDown(KeyCode.S))
        {
            print("S");
            Physics2D.gravity = new Vector3(0, -9.81F, 0);
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            print("W");
            Physics2D.gravity = new Vector3(0, 9.81F, 0);
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            print("D");
            Physics2D.gravity = new Vector3(9.81F, 0, 0);
            transform.GetChild(1).gameObject.SetActive(true);
            transform.GetChild(2).gameObject.SetActive(false);
        }
    }
}
