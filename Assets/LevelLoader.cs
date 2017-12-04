using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ColorTo
{
    public Color32 color;
    public GameObject prefab;


}

public class LevelLoader : MonoBehaviour {

    public Texture2D levelMap;
    public ColorTo[] colorTo;
	// Use this for initialization
	void Start () {

        LoadMap();

	}
	
	void EmptyMap()
    {
        while(transform.childCount > 0)
        {
            Transform c = transform.GetChild(0);
            c.SetParent(null);
            Destroy(c.gameObject);
        }
    }

    void LoadMap()
    {
        EmptyMap();
        Color32[] allPixels = levelMap.GetPixels32();
        int width = levelMap.width;
        int height = levelMap.height;

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                SpawnTileAt(allPixels[x + (y * width)], x, y);
            }
        }
        
    }

    void SpawnTileAt(Color32 c, int x , int y)
    {
        if(c.a <= 0)
        {
            return;
        }
        foreach (ColorTo ctp in colorTo)
        {
            if(c.Equals(ctp.color))
            {
                GameObject go = (GameObject)Instantiate(ctp.prefab, new Vector3(x, y, 0), Quaternion.identity);

            }
        }

        Debug.LogError("No color to prefab found for: " + c.ToString());
    }
}
