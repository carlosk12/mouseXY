using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateTrigger : MonoBehaviour {

	public GateScript gate;
	public bool ignoreTrigger;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D collision) {
		if (ignoreTrigger) {
			return;
		}
		else if (collision.tag == "Player") {
			gate.OpenGate();
		}
	}

	private void OnTriggerExit2D(Collider2D collision) {
		if (ignoreTrigger){
			return;
		}
		else if (collision.tag == "Player") {
			gate.CloseGate();
		}
	}

	public void Toggle(bool state) {
		if (state)
			gate.OpenGate();
		else
			gate.CloseGate();
	}

	// vizual indicate what gates have triggers activated
	private void OnDrawGizmos() {
		if (!ignoreTrigger) {
			BoxCollider2D box = GetComponent<BoxCollider2D>();
			Gizmos.DrawWireCube(transform.position, new Vector2(box.size.x, box.size.y));
		}
	}

}
