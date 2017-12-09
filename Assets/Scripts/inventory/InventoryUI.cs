using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour {
    Inventory inventory;
    public Transform itemsParent;
    InventorySlot[] slots;
    EquipSlot[] equipmentSlot;
    Equipment[] currentEquip = new Equipment[4];
    GameObject gameManager;
    public GameObject equip;

	// Use this for initialization
	void Start () {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();


        gameManager = GameObject.FindGameObjectWithTag("GameManager");

        equipmentSlot = equip.GetComponentsInChildren<EquipSlot>();

        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void UpdateUI()
    {
        //Update Inventory
        for (int i = 0; i < slots.Length; i++)
        {
            if(i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
        //Update Equipment
        
        
    }
    public void UpdateEquip()
    {
        currentEquip = gameManager.GetComponent<EquipmentManager>().SendArray();

        for (int i = 0; i < equipmentSlot.Length; i++)
        {
            equipmentSlot[i].AddItem(currentEquip[i]);
        }
    }
}
