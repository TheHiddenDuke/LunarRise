using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;



public class menuButton : MonoBehaviour {
    private GameObject myMenu;
    private GameObject myQuest;
    private GameObject myMission;
    public Text title;
    public Text detail;
    

    // Use this for initialization
    void Start () {
        myMenu = GameObject.FindGameObjectWithTag("Menu");
        myQuest = GameObject.FindGameObjectWithTag("Quest");
        myMission = GameObject.FindGameObjectWithTag("QuestDetail");
        myMission.SetActive(false);

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
    public void Quest()
    {
        myQuest.SetActive(!myQuest.activeSelf);
    }
    public void Mission()
    {
        myMission.SetActive(!myMission.activeSelf);


        List<Dictionary<string, string>> allTextDic = GameObject.Find("Canvas").GetComponent<loadQuest>().questLoad();
        if (allTextDic != null)
        {


            Dictionary<string, string> dic = allTextDic[1];
            title.text = dic["title"];
            detail.text = dic["details"];


        }
    }

    public Text[] details;

    public void Tutorial()
    {
        myMission.SetActive(!myMission.activeSelf);

        List<Dictionary<string, string>> allTextDic = GameObject.Find("Canvas").GetComponent<loadQuest>().questLoad();
        if (allTextDic != null)
        {

            Dictionary<string, string> dic = allTextDic[0];

            title.text = dic["title"];
            detail.text = dic["details"];
        }
    }
    public void backQuest()
    {
        myMission.SetActive(!myMission.activeSelf);
    }
    
}
