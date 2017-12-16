using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour {

    GameController gameCon;
    int level;

    void Awake()
    {
        gameCon = GetComponent<GameController>();
    }

    public void LoadByIndex(int sceneIndex)
    {
        //gameCon.ChangeIndexAndLoad(level);
        //SceneManager.LoadScene(sceneIndex);
    }

    public void GetIndex(int index)
    {
        level = index;
    }
}
