using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateScript : MonoBehaviour {

	

	Animator anim;
    bool active;

	// Use this for initialization
	void Start()
	{
		anim = GetComponent<Animator>();
        Debug.Log(anim.name);
        active = false;
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void OpenGate()
	{
        if (active == false)
        {
            anim.SetBool("Open", true);
            active = true;
        }
	}

	public void CloseGate()
	{
        if (anim != null)
        {
            if (anim.runtimeAnimatorController != null)
            {
                if (active == true)
                {
                    anim.SetBool("Open", false);
                    active = false;
                }
            }
        }

		anim.SetBool("Open", false);
		//Debug.Log("dsadas");
	}
}
