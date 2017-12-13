using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffManager : MonoBehaviour {

    #region Singleton
    public static BuffManager instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    public GameObject[] characters = new GameObject[3];
    public float[] timeDuration = new float[3];
    public bool[] buffEffect = new bool[3];
    public float[] time = new float[3];
    public float[] multiplier = new float[3];
    public BuffAbility[] abilities = new BuffAbility[3];
   
    // Use this for initialization
    void Start () {
        for (int i = 0; i < timeDuration.Length; i++)
        {
            timeDuration[i] = 0;
        }
        
        for (int i = 0; i < time.Length; i++)
        {
            time[i] = 0;
        }

    }
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < buffEffect.Length; i++)
        {
            if (buffEffect[i])
            {
                time[i] = time[i] + Time.deltaTime;
                if (time[i] >= timeDuration[i])
                {
                    buffEffect[i] = false;
                    time[i] = 0;
                    abilities[i].TakeEffect(characters[i]);
                    
                    
                }
            }
        }
    }
    

}
