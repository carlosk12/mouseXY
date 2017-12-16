using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackToMenu : MonoBehaviour {

    public Image img;
    bool imgOn;
	// Use this for initialization
	void Start () {
        img.enabled = false;
        imgOn = false;  
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKey)
        {
            img.enabled = false;
            imgOn = false;
        }
    }

    public void ActivateImg()
    {
        img.enabled = true;
        imgOn = true;
        
    }

    
}
