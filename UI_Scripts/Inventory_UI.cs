//Copyright (c) FuchsFarbe

using System;
using UnityEngine;
using Dragon_Stones.Inventory_Systems;

/* ============================================
*               Inventory UI
* --------------------------------------------
*       Inventory UI is a script for 
*   maintaining and controlling UI components
*   for player's inventory.
*  ===========================================
*/
namespace Dragon_Stones.UI
{
    public class Inventory_UI : MonoBehaviour
    {
		#region Variables

		//References
		public Transform slotParent;
		private Player_Inventory pInventory;
		//Variables
		private Inventory_Slot_UI[] itemSlots;
		//Events
		Canvas_Manager canvas_Manager;
		#endregion

		#region Unity Methods
		private void Start()
		{
			pInventory = Player_Inventory.instance;
			canvas_Manager = Canvas_Manager.instance;
			itemSlots = slotParent.GetComponentsInChildren<Inventory_Slot_UI>();
		}
		void OnEnable()
		{
			Player_Inventory.ItemsChanged += UpdateUI;
			Canvas_Manager.BagOpened += UpdateUI;
		}
		void OnDisable()
		{
			Player_Inventory.ItemsChanged -= UpdateUI;
			Canvas_Manager.BagOpened -= UpdateUI;
		} 
		#endregion

		void UpdateUI()
		{
			for(int i = 0; i < itemSlots.Length; i++)
			{
				if (i < pInventory.playerItems.Count)
				{
					itemSlots[i]?.AddItem(pInventory?.playerItems[i]);
				}
				else
				{
					itemSlots[i].ClearSlot();
				}
			}
		}

	}
}