using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform target;
    public Transform from;
    public Transform to;
    public float speed = 2.1F;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        //transform.position = target.position;

        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.rotation = Quaternion.Slerp(from.rotation, to.rotation, Time.time * speed);
            //transform.LookAt(target, Vector2.right);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            transform.LookAt(target, Vector2.left);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            transform.LookAt(target, Vector2.down);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            transform.LookAt(target, Vector2.up);
        }
        //else if (Input.GetKeyDown(KeyCode.DownArrow))
        //{
        //    transform.Rotate(Vector2.up, 10.0f * Time.deltaTime);
        //}
        //else if (Input.GetKeyDown(KeyCode.UpArrow))
        //{
        //    transform.Rotate(Vector2.down, 10.0f * Time.deltaTime);
        //}
        //else if (Input.GetKeyDown(KeyCode.RightArrow))
        //{
        //    transform.Rotate(Vector2.left, 10.0f * Time.deltaTime);
        //}
    }
}
