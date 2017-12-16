using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyDropdown : MonoBehaviour {

    public static DontDestroyDropdown i;

    void Awake()
    {
        if (!i)
        {
            i = this;

        }

        else
        {
            DestroyObject(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
