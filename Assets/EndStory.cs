using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndStory : MonoBehaviour {

    public Text Continue;
    GameController gameCon;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(Appear());
        gameCon = GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    IEnumerator Appear()
    {
        yield return new WaitForSeconds(3);
        Continue.gameObject.SetActive(true);
    }
}
