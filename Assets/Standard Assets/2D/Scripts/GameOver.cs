﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{

    public Text winText;

    // Use this for initialization
    void Start()
    {
        //winText = GameObject.FindGameObjectWithTag("Canvas").GetComponent<UnityEngine.UI.Text>();

        //winText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            winText.gameObject.SetActive(true);
        }
    }
}
    
