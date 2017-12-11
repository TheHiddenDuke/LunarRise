using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : MonoBehaviour {

    #region Singleton
    public static AIManager instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    public GameObject[] partyAllies = new GameObject[2];
    
}
