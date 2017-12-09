using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour {

    private ParticleSystem particles;

	// Use this for initialization
	void Start () {
        particles = GetComponent<ParticleSystem>();	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.A))
        {
            //particles.shape.box.(new Vector3(0, -90, 0));
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {

        }
        else if (Input.GetKeyDown(KeyCode.W))
        {

        }
        else if (Input.GetKeyDown(KeyCode.D))
        {

        }
    }


}
