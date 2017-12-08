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
            int x = lvl.Xpos;
            int y = lvl.Ypos;
            Debug.Log("Ypos: " + y);
            Destroy(col.gameObject);
            Instantiate(col.gameObject, new Vector3(x, y, 0), Quaternion.identity);
        }

    }
}
