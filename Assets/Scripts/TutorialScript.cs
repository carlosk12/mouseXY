using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialScript : MonoBehaviour {

    public Image TutorialImg;

	// Use this for initialization
	void Start () {
        StartCoroutine(Appear());
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKey)
        {
            TutorialImg.enabled = false;
        }
	}

    IEnumerator Appear()
    {
        TutorialImg.enabled = false;
        yield return new WaitForSeconds(2);
        TutorialImg.enabled = true;
    }
}
