using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

	public GateTrigger[] gateTrig;
	public int colCounter = 0;

	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
        LevelLoader load = GetComponent<LevelLoader>();

	}
	
	// Update is called once per frame
	void Update () {
	}

	private void OnTriggerEnter2D(Collider2D collision) {

		colCounter++;
		anim.SetBool("GoDown", true);

        foreach (GateTrigger i in gateTrig){
        	i.Toggle(true);
        }

		if (colCounter == 1)
		{
			FindObjectOfType<AudioManager>().Play("buttonDown");
			FindObjectOfType<AudioManager>().Stop("buttonUp");
		}
	}

	//void OnTriggerExit2D() {
	private void OnTriggerExit2D(Collider2D collision)
	{
		colCounter--;
		Debug.Log("colCounter" + colCounter);

		if (colCounter == 0)
		{
			anim.SetBool("GoDown", false);

			foreach (GateTrigger i in gateTrig)
			{
				i.Toggle(false);
			}
			FindObjectOfType<AudioManager>().Play("buttonUp");
			FindObjectOfType<AudioManager>().Stop("buttonDown");
		}
	}

	// visual indicator to show witch gates the button is connected to
	public void OnDrawGizmos()
	{
		Gizmos.color = Color.cyan;

		foreach (GateTrigger i in gateTrig) {
			Gizmos.DrawLine(transform.position, i.transform.position);
		}
	}



}
