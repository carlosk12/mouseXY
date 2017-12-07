using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WinGame : MonoBehaviour {

	public TextMeshPro winText;

	private void Awake()
	{
		winText.gameObject.SetActive(false);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			winText.gameObject.SetActive(true);
		}
	}
}
