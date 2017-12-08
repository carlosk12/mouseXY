using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class GameController : MonoBehaviour {
    //public string levelFileName;
    //string filePath = Application.dataPath + "/Maps/" + levelFileName;
    //byte[] bytes = System.IO.File.ReadAllBytes(filePath);
    // Use this for initialization
    public float LevelDelay = 2f;
    public Texture2D [] maps;
    public LevelLoader load;
    private int level = -1;
    public GameObject levelDestroyer;
    static public GameController i;

    void Awake () {

        if (!i)
        {
            i = this;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            DestroyObject(gameObject);
        }
        GetNextLevel();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GetNextLevel()
    {
        level++;
        load.levelMap = maps[level];
        load.LoadMap();

    }
}
