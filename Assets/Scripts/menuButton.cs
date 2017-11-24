using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;



public class menuButton : MonoBehaviour {
    public GameObject myMenu;


    // Use this for initialization
    void Start () {
        myMenu = GameObject.FindGameObjectWithTag("Menu");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Continue()
    {
        myMenu.SetActive(!myMenu.activeSelf);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
