using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.Linq;
using System.Xml.Linq;

public class loadQuest : MonoBehaviour {

	// Use this for initialization
	void Start () {
        List<Dictionary<string, string>> allTextDic = questLoad();
        if(allTextDic != null)
        {

            Dictionary<string, string> dic = allTextDic[0];
            

            dic = allTextDic[1];
            


        }
        
    }
    public List<Dictionary<string, string>> questLoad()
    {
        TextAsset txtXmlAsset = Resources.Load<TextAsset>("QuestLog");
        var doc = XDocument.Parse(txtXmlAsset.text);
            
        var allDict = doc.Element("questLog").Elements("quest");
        List<Dictionary<string, string>> allTextDic = new List<Dictionary<string, string>>();
        foreach (var oneDict in allDict)
        {
            var title = oneDict.Elements("title");
            var desc = oneDict.Elements("details");
            XElement elementT = title.ElementAt(0);
            XElement elementD = desc.ElementAt(0);
            string first = elementT.ToString().Replace("<title>", string.Empty).Replace("</title>", string.Empty).Replace("\n", string.Empty);
            string second = elementD.ToString().Replace("<details>", string.Empty).Replace("</details>", string.Empty).Replace("\n", string.Empty);

            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("title", first);
            dic.Add("details", second);

            allTextDic.Add(dic);
        }
        return allTextDic;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
