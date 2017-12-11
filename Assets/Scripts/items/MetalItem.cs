using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/MetalItem")]
public class MetalItem : Item {
    //public GameObject character = null;
    public string character;
    public float metalDuration;
    override public void Use()
    {
        
    }
   public void Use(string character)
    {
        if (character != null)
        {
            //Debug.Log("Chamando ok");
            MetalManager.instance.GoTime(name, character, metalDuration);
        }
    }

}
