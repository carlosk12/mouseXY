using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseSprite : MonoBehaviour {

    //public Sprite[] sprites;
    private SpriteRenderer renderer;
    [HideInInspector]
    public Animator anim;

    void Awake()
    {
        renderer = gameObject.GetComponent<SpriteRenderer>();
        anim = gameObject.GetComponent<Animator>();
    }
    
    void Start () {
        //renderer.sprite = sprites[0];
        anim.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        if(Physics2D.gravity.x == 0)
        {
            if(Physics2D.gravity.y < 0)
            {
                //renderer.sprite = sprites[0];
                
            }
            else if(Physics2D.gravity.y > 0)
            {
                //renderer.sprite = sprites[1];
            }
        }
        else if(Physics2D.gravity.y == 0)
        {
            if(Physics2D.gravity.x < 0)
            {
                //renderer.sprite = sprites[2];
            }
            else if(Physics2D.gravity.x > 0)
            {
                //renderer.sprite = sprites[3];
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

        //if (Input.GetKeyDown(KeyCode.LeftArrow))
        //{
        //    renderer.sprite = sprites[2];
        //}
        //else if (Input.GetKeyDown(KeyCode.S))
        //{
        //    renderer.sprite = sprites[0];
        //}
        //else if (Input.GetKeyDown(KeyCode.W))
        //{
        //    renderer.sprite = sprites[1];
        //}
        //else if (Input.GetKeyDown(KeyCode.D))
        //{
        //    renderer.sprite = sprites[3];
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
}
