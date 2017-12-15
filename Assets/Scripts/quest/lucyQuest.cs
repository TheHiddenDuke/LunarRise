using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.Linq;
using System.Xml.Linq;

public class lucyQuest : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        List<Dictionary<string, string>> allTextDic = questLoad();
        List<Dictionary<string, string>> allTextDialDic = dialLoad();
        if (allTextDic != null || allTextDialDic != null)
        {

            Dictionary<string, string> dic = allTextDic[0];
            Dictionary<string, string> dic1 = allTextDic[0];

            dic = allTextDic[1];
            dic1 = allTextDic[1];

        }

    }
    public List<Dictionary<string, string>> questLoad()
    {
        TextAsset txtXmlAsset = Resources.Load<TextAsset>("TutorialQuest");
        var doc = XDocument.Parse(txtXmlAsset.text);

        var allDict = doc.Element("questLog").Elements("quest");
        

        List<Dictionary<string, string>> allTextDic = new List<Dictionary<string, string>>();
        List<Dictionary<string, string>> allDial = new List<Dictionary<string, string>>();

        foreach (var oneDict in allDict)
        {
            

            var title = oneDict.Elements("title");
            var npcName = oneDict.Elements("npcName");

            
            XElement elementT = title.ElementAt(0);
            XElement elementN = npcName.ElementAt(0);

            string first = elementN.ToString().Replace("<npcName>", string.Empty).Replace("</npcName>", string.Empty).Replace("\n", string.Empty);
            string second = elementT.ToString().Replace("<title>", string.Empty).Replace("</title>", string.Empty).Replace("\n", string.Empty);
            

            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("npcName", first);
            dic.Add("title", second);
            
            

            allTextDic.Add(dic);
            
        }
        return allTextDic;
    }

    public List<Dictionary<string, string>> dialLoad()
    {
        TextAsset txtXmlAsset = Resources.Load<TextAsset>("TutorialQuest");
        var doc = XDocument.Parse(txtXmlAsset.text);

        var allDict = doc.Element("questLog").Elements("quest");

        List<Dictionary<string, string>> allTextDic = new List<Dictionary<string, string>>();

        foreach (var oneDict in allDict)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            
            foreach (var lucyDial in oneDict.Elements("lucy"))
            {

                var dialogue = lucyDial.Elements("dialogue");
                XElement elementDL = dialogue.ElementAt(0);
                string fir = elementDL.ToString().Replace("<dialogue>", string.Empty).Replace("</dialogue>", string.Empty).Replace("\n", string.Empty);

                dic.Add("dialogueLucy", fir);


            }

            foreach (var abnerDial in oneDict.Elements("abner"))
            {
                var dialogue = abnerDial.Elements("dialogue");
                XElement elementDL = dialogue.ElementAt(0);
                string fir = elementDL.ToString().Replace("<dialogue>", string.Empty).Replace("</dialogue>", string.Empty).Replace("\n", string.Empty);

                dic.Add("dialogueAbner", fir);
            }



            allTextDic.Add(dic);

        }
        return allTextDic;
    }


    // Update is called once per frame
    void Update()
    {

    }
}
