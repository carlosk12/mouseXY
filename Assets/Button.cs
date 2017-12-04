using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay2D()
	{
		anim.SetBool("GoDown", true);
	}

	void OnTriggerExit2D()
	{
		anim.SetBool("GoDown", false);
	}

}
