using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour {

	void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(Time.timeScale != 0)
            {
                Time.timeScale = 0;
                gameObject.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                gameObject.SetActive(false);
            }
        }
    }

    public void UnpauseGame()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
}
