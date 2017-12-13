using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalManager : MonoBehaviour {
    #region Singleton
    public static MetalManager instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion
    public int numberOfCharacters;
    public GameObject[] characters = new GameObject[3]; 
    public bool[] metalEffect = new bool[3] ;
    public float[] time = new float[3] ;
    public float[] metalDuration = new float[3];
    public string[] metalName = new string[3];
    // Use this for initialization
    void Start () {
        
        for(int i = 0; i < time.Length; i++)
        {
            time[i] = 0;
        }
        for (int i = 0; i < metalDuration.Length; i++)
        {
            metalDuration[i] = 0;
        }
        for (int i = 0; i < metalName.Length; i++)
        {
            metalName[i] = null;
        }
    }
	
	// Update is called once per frame
	void Update () {
        
		for(int i=0; i < metalEffect.Length; i++)
        {
            if (metalEffect[i])
            {
                time[i] = time[i] + Time.deltaTime;
                if (time[i] >= metalDuration[i])
                {
                    metalEffect[i] = false;
                    time[i] = 0;
                    characters[i].GetComponent<PartyStats>().LoseMetalEffect(metalName[i]);
                    metalName[i] = null;
                }
            }
        }
	}
    public int AmongCharacters(GameObject obj)
    {
        for(int i = 0; i<characters.Length; i++)
        {
            if (characters[i] == obj) {
                return i;
            }
           
        }
        return -1;
    }

    public void GoTime(string metalName, string characterName, float duration)
    {
        Debug.Log("Ta indo");
        for (int i = 0; i < characters.Length; i++)
        {
            if (characters[i].name == characterName)
            {
                if (this.metalName[i] == null)
                {
                    metalEffect[i] = true;
                    metalDuration[i] = duration;
                    this.metalName[i] = metalName;
                    characters[i].GetComponent<PartyStats>().GainMetalEffect(metalName);
                }
                else
                {
                    Debug.Log("Already under effect of " + this.metalName[i]);
                }
                }
        }
    }
    
}
