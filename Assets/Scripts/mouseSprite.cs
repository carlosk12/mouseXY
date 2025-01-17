﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseSprite : MonoBehaviour {

    public Sprite[] sprites;
    private SpriteRenderer renderer;
    [HideInInspector]
    public Animator anim;

    void Awake()
    {
        renderer = gameObject.GetComponent<SpriteRenderer>();
        anim = gameObject.GetComponent<Animator>();
    }
    
    void Start () {
        renderer.sprite = sprites[0];
        //anim.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (Physics2D.gravity.x == 0)
        {
            if (Physics2D.gravity.y < 0)
            {
                renderer.sprite = sprites[0];

            }
            else if (Physics2D.gravity.y > 0)
            {
                renderer.sprite = sprites[1];
            }
        }
        else if (Physics2D.gravity.y == 0)
        {
            if (Physics2D.gravity.x < 0)
            {
                renderer.sprite = sprites[3];
            }
            else if (Physics2D.gravity.x > 0)
            {
                renderer.sprite = sprites[2];
            }
        }

        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    flipPlayerX();
        //}
        //else if (Input.GetKeyDown(KeyCode.S))
        //{
        //    renderer.sprite = sprites[0];
        //}
        //else if (Input.GetKeyDown(KeyCode.W))
        //{
        //}
        //else if (Input.GetKeyDown(KeyCode.D))
        //{
        //    renderer.sprite = sprites[3];
        //}

        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    anim.enabled = true;
        //}
        //else if (Input.GetKeyDown(KeyCode.S))
        //{
        //    anim.enabled = true;
        //}
        //else if (Input.GetKeyDown(KeyCode.W))
        //{
        //    anim.enabled = true;
        //}
        //else if (Input.GetKeyDown(KeyCode.D))
        //{
        //    anim.enabled = true;
        //}

        //if (Input.GetKeyUp(KeyCode.A))
        //{
        //    anim.enabled = false;
        //}
        //else if (Input.GetKeyUp(KeyCode.S))
        //{
        //    anim.enabled = false;
        //}
        //else if (Input.GetKeyUp(KeyCode.W))
        //{
        //    anim.enabled = false;
        //}
        //else if (Input.GetKeyUp(KeyCode.D))
        //{
        //    anim.enabled = false;
        //}
    }

    public void flipPlayerX()
    {
        renderer.flipX = !renderer.flipX;
    }

    public void flipPlayerY()
    {
        renderer.flipY = !renderer.flipY;
    }

    public void flipPlayerX(bool input)
    {
        renderer.flipX = input;
    }

    public void flipPlayerY(bool input)
    {
        renderer.flipY = input;
    }
}