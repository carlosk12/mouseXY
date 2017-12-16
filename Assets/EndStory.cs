using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndStory : MonoBehaviour {

    public Text Continue;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(Appear());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            GameController.i.ChangeIndexAndLoad(-1);
        }
    }

    IEnumerator Appear()
    {
        yield return new WaitForSeconds(3);
        Continue.gameObject.SetActive(true);
    }
}
