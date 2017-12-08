using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class ColorTo
{
    public Color32 color;
    public GameObject prefab;
    public GameObject child;
}


public class LevelLoader : MonoBehaviour {

    public Texture2D levelMap;
    public ColorTo[] colorTo;
    public int Xpos;
    public int Ypos;

    // Use this for initialization
    void Start () {
    }
	
	public void EmptyMap()
    {
        while(transform.childCount > 0)
        {
            Transform c = transform.GetChild(0);
            c.SetParent(null);
            Destroy(c.gameObject);
        }
    }

    public void LoadMap()
    {
        EmptyMap();

        Color32[] allPixels = levelMap.GetPixels32();
        Color32 TheCol = Color.blue;

        int width = levelMap.width;
        int height = levelMap.height;

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                SpawnTileAt(allPixels[x + (y * width)], x, y);

                if(allPixels[x + (y * width)].Equals(TheCol))
                {
                    Xpos = x;
                    Ypos = y;
                }
            }
        }
    
    }

    public void SpawnTileAt(Color32 c, int x , int y)
    {
        if(c.a <= 0)
        {
            return;
        }
        foreach (ColorTo ctp in colorTo)
        {
            
            if (c.Equals(ctp.color))
            {
                GameObject go = (GameObject)Instantiate(ctp.prefab, new Vector3(x, y, 0), Quaternion.identity);

                if(ctp.child != null)
                {
                    GameObject go2 = (GameObject)Instantiate(ctp.child, new Vector3(x, y, 0), Quaternion.identity);
                    go2.transform.parent = go.transform;
                }
                else
                {
                    go.transform.SetParent(transform, true);
                }
                
                //go.transform.parent = transform;

                //if (go.transform.childCount > 0)
                //{
                //    child = go.transform.GetChild(0);
                //    //Debug.Log(go.transform.GetChild(0).name);

                //}


            }
        }


    }
}
