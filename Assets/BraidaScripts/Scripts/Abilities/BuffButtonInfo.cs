using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffButtonInfo : AbilityButtonInfo
{

    public GameObject character;

    // Use this for initialization
    void Start()
    {
        requirement = ability.requirement;
    }

    // Update is called once per frame
    void Update()
    {
        available = ability.available;

    }
}
