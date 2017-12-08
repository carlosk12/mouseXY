using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

	public GateTrigger[] gateTrig;
	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay2D() {
		anim.SetBool("GoDown", true);

		foreach (GateTrigger i in gateTrig){
			i.Toggle(true);
		}
	}

	void OnTriggerExit2D() {
		anim.SetBool("GoDown", false);

		foreach (GateTrigger i in gateTrig){
			i.Toggle(false);
		}
	}

	// visual indicator to show witch gates the button is connected to
	private void OnDrawGizmos()
	{
		Gizmos.color = Color.cyan;

		foreach (GateTrigger i in gateTrig) {
			Gizmos.DrawLine(transform.position, i.transform.position);
		}
	}

	

}
