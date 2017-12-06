using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateScript : MonoBehaviour {

	

	Animator anim;

	// Use this for initialization
	void Start()
	{
		anim = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void OpenGate()
	{
		anim.SetBool("Open", true);
	}

	public void CloseGate()
	{
		anim.SetBool("Open", false);
		//Debug.Log("dsadas");
	}
}
