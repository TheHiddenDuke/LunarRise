using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour {
    Inventory inventory;
    public Transform itemsParent;
    InventorySlot[] slots;

	// Use this for initialization
	void Start () {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
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

        for(int i = 0; i < 4; i++) {

        }
    }
}
