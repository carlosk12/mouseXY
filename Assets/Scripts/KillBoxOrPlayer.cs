using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBoxOrPlayer : MonoBehaviour {

    public LevelLoader lvl;
    private GameObject spawnPoint;
    private Vector3 boxLocation;
    private Vector3 PlayerLocation;

    private void Awake()
    {
		spawnPoint = GameObject.FindGameObjectWithTag("TheBox");
        boxLocation = spawnPoint.transform.position;
		
        spawnPoint = GameObject.Find("leftRightCol");
        PlayerLocation = spawnPoint.transform.position;
    }
    // Use this for initialization
    void Start () {
        

	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "TheBox")
        {
			FindObjectOfType<AudioManager>().Play("boxDeath");

			//Destroy(col.gameObject);
			col.gameObject.transform.position = boxLocation;
            col.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
			

        }
        else if (col.gameObject.tag == "Player")
        {
			FindObjectOfType<AudioManager>().Stop("boxDeath");
			FindObjectOfType<AudioManager>().Play("mouseDeath");

			Debug.Log("helloThere");
            GameController.i.getCurrLevel();
        }

    }
}
