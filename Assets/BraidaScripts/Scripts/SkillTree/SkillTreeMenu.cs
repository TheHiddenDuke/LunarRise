using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillTreeMenu : MonoBehaviour {
    public Button[] charactersButtons = new Button[3];
    public GameObject[] skillTrees = new GameObject[3];
    public GameObject skillTreeMenu;
    public GameObject currentSkillTree;
    public bool changedMenu;
    // Use this for initialization
	void Start () {
        changedMenu = PlayerManager.instance.player.GetComponent<cylMove>().changedMenu;
	}
	
	// Update is called once per frame
	void Update () {
        if (changedMenu)
        {
            if (Input.GetButtonDown("SkillTreeMenu"))
            {

                skillTreeMenu.SetActive(false);
                changedMenu = false;
                currentSkillTree.SetActive(!currentSkillTree.activeSelf);

                
            }
        }
    }
    public void CreateMenuEthan()
    {
        changedMenu = true;
        skillTrees[0].SetActive(true);
        currentSkillTree = skillTrees[0];
        skillTreeMenu.SetActive(false);

    }
    public void CreateMenuElyse()
    {
        changedMenu = true;
        skillTrees[1].SetActive(true);
        currentSkillTree = skillTrees[1];
        skillTreeMenu.SetActive(false);
    }
    public void CreateMenuMax()
    {
        changedMenu = true;
        skillTrees[2].SetActive(true);
        currentSkillTree = skillTrees[2];
        skillTreeMenu.SetActive(false);
    }
}
