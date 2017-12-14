using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialScript : MonoBehaviour {

    public Image TutorialImg;
    private bool enabled = false;

	// Use this for initialization
	void Start () {
        TutorialImg.enabled = false;
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName == "Level1")
        {
            TutorialImg.enabled = true;
            //StartCoroutine(Appear());
        }
        
        //TutorialImg.enabled = true;
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
        
        yield return new WaitForSeconds(2);
        
    }
}
