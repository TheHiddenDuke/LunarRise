using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item {
    public EquipmentSlot equipSlot;

    public int armorModifier;
    public int damageModifier;
    public Text dmg;
    public Text def;

    public override void Use()
    {
        base.Use();

        //Equip item
        EquipmentManager.instance.Equip(this);

        //Remove from inventory

        RemoveFromInventory();
    }

    private void OnMouseEnter()
    {
        
        def.text = armorModifier.ToString();
        dmg.text = damageModifier.ToString();
    }

}

public enum EquipmentSlot { Head, Chest, Weapon, Feet   }