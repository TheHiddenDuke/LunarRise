using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;



public class menuButton : MonoBehaviour {
    private GameObject myMenu;
    private GameObject myQuest;
    private GameObject myMission;
    private GameObject myEquip;
    public Text title;
    public Text detail;
    

    // Use this for initialization
    void Start () {
        myMenu = GameObject.FindGameObjectWithTag("Menu");
        myQuest = GameObject.FindGameObjectWithTag("Quest");
        myMission = GameObject.FindGameObjectWithTag("QuestDetail");
        myEquip = GameObject.FindGameObjectWithTag("Equip");
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

    public void Equipment()
    {
        myEquip.SetActive(!myEquip.activeSelf);
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

        questGiver();
    }
    public void backQuest()
    {
        myMission.SetActive(!myMission.activeSelf);
    }

    public Text npcName;
    public Text questName;
    public Text dialogueLucy;
    //public Text dialogueAbner;
    private string[] dial;
    

    public void questGiver()
    {
        List<Dictionary<string, string>> nameDic = GameObject.Find("Canvas").GetComponent<lucyQuest>().questLoad();
        List<Dictionary<string, string>> dialDic = GameObject.Find("Canvas").GetComponent<lucyQuest>().dialLoad();

        
        if(nameDic != null)
        {
            Dictionary<string, string> dic = nameDic[0];
        npcName.text = dic["npcName"];
        questName.text = dic["title"];
            for(int e = 0; e < 3; e++)
            {
                //Dictionary<string, string> dicDial = dialDic[e];

                //dial[e] = dicDial["dialogue"];
                //Debug.Log(dial[e]);
            }


        }
    }
}
