using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class DropdownScript : MonoBehaviour {
    public GameController gameCon;
    public List<string> dropdownItems;
    public Dropdown dd;
    int picked;
    
    LoadSceneOnClick onClick;
	
	void Start () {
       
        dd = GameObject.Find("Dropdown").GetComponent<Dropdown>();
        gameCon = GameObject.FindObjectOfType<GameController>();
        dropdownItems = gameCon.scenePaths.ToList();
        dropdownItems[0] = "Select a level";
        populateDropdown();
        Time.timeScale = 1;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void populateDropdown()
    {
        dd.AddOptions(dropdownItems);
    }

    public void indexChanged(int index)
    {
        //onClick = GetComponent<LoadSceneOnClick>();
        picked = index;
        //onClick.GetIndex(dd.value);
    }

    public void submitClicked()
    {
        if (picked != 0)
        {
            gameCon.ChangeIndexAndLoad(picked);
        }
    }
}
