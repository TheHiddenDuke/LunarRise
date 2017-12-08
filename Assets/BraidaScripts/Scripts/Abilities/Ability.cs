﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : ScriptableObject {

    public string aname = "New Ability";
    public Sprite aSprite;
    public AudioClip aSound;
    public float aBaseCoolDown = 1f;
    public bool available = false;
    public Ability requirement = null;
    

    public abstract void Initialize(GameObject obj);
    public abstract void TriggerAbility();
	
}
