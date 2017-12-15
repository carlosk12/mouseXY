﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    //public string levelFileName;
    //string filePath = Application.dataPath + "/Maps/" + levelFileName;
    //byte[] bytes = System.IO.File.ReadAllBytes(filePath);
    // Use this for initialization
    public float LevelDelay = 2f;
    //public Texture2D [] maps;
    //public LevelLoader load;
    public string[] scenePaths;
    // public GameObject levelDestroyer;
    static public GameController i;
    private int level = 0;
    
    private AssetBundle loadAsset;

    void Awake () {

        if (!i)
        {
            i = this;
            
        }

        else
        {
            DestroyObject(gameObject);
        }

		DontDestroyOnLoad(gameObject);

		//SceneManager.LoadScene(nextScene);

		//GetNextLevel();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GetNextLevel()
    {
        level++;
        Debug.Log("Level loading: " + scenePaths[0]);
        //load.levelMap = maps[level];
        
        SceneManager.LoadScene(scenePaths[level], LoadSceneMode.Single);

    }
    public void getCurrLevel()
    {
        SceneManager.LoadScene(scenePaths[level], LoadSceneMode.Single);
    }
}
