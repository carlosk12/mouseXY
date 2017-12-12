using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBoxOrPlayer : MonoBehaviour {

    public LevelLoader lvl;    

	// Use this for initialization
	void Start () {
        lvl = FindObjectOfType<LevelLoader>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "TheBox")
        {
            Destroy(col.gameObject);
            Instantiate(col.gameObject, new Vector3(col.transform.position.x, col.transform.position.y, 0), Quaternion.identity);
        }

    }
}
