//Copyright (c) FuchsFarbe

using System;
using System.Collections;
using UnityEngine;

/* ============================================
*               Equipment Manager
* --------------------------------------------
*		
*  ===========================================
*/
namespace Dragon_Stones.Inventory_Systems
{
	public  class Equipment_Manager : MonoBehaviour
    {
		#region Equipment Manager Singleton
		//Player's Inventory singleton
		public static Equipment_Manager instance;
		private void Awake()
		{
			if (instance != null)
			{
				Debug.LogWarning("More than one equipment manager instance");
			}

			instance = this;

			equipSlot = new EquipmentSlotData[9]
			{
				new EquipmentSlotData(EquipSlot.accessory, new Equipment()),
				new EquipmentSlotData(EquipSlot.head, new Equipment()),
				new EquipmentSlotData(EquipSlot.accessory, new Equipment()),
				new EquipmentSlotData(EquipSlot.weapon, new Weapon()), //Weapon only
				new EquipmentSlotData(EquipSlot.chest, new Equipment()),
				new EquipmentSlotData(EquipSlot.weapon, new Weapon()), //Weapon only
				new EquipmentSlotData(EquipSlot.hand, new Equipment()),
				new EquipmentSlotData(EquipSlot.leg, new Equipment()),
				new EquipmentSlotData(EquipSlot.robe, new Equipment()),
			};
		}
		#endregion

		#region Variables

		//References
		Player_Inventory pi;
		//Variables
		[SerializeField] private EquipmentSlotData[] equipSlot;

		#endregion

		private void Start()
		{
			pi = Player_Inventory.instance;
			//Start each scene with null items to avoid duplicate empties.
			foreach (EquipmentSlotData e in equipSlot)
			{
				e.EquipItem = null;
			}
			//Find a way to initialize items play has saved. 
		}

		public void EquipItem(Equipment newItem)
		{
			if (newItem is Weapon)
			{
				EquipWeapon(newItem as Weapon);
			}
			else
			{
				switch (newItem.Slot)
				{
					case EquipSlot.accessory:
						AddAccessory(newItem);
						break;
					case EquipSlot.chest:
						EquipArmor(newItem, newItem.Slot);
						break;
					case EquipSlot.hand:
						EquipArmor(newItem, newItem.Slot);
						break;
					case EquipSlot.head:
						EquipArmor(newItem, newItem.Slot);
						break;
					case EquipSlot.leg:
						EquipArmor(newItem, newItem.Slot);
						break;
					case EquipSlot.robe:
						EquipArmor(newItem, newItem.Slot);
						break;
				}
			}
		}

		private void EquipArmor(Equipment newArmor, EquipSlot slot)
		{
			//Get the enums as a number;
			int numSlots = Enum.GetNames(typeof(EquipSlot)).Length;

			//Get the target index
			int slotIndex = (int)slot;

			for (int i = 0; i < numSlots; i++)
			{
				equipSlot[slotIndex].EquipItem = newArmor;
				Debug.Log("Armor Equipped. ");
			}
		}

		private void EquipWeapon(Weapon newWeapon)
		{
			Weapon oldWeapon = null;
			Weapon oldOffhand = null;

			//If 2hander
			if (!newWeapon.CanDualWield)
			{
				//Remove both weapon slots
				//Check to see if slot 1 is a 2hander
				if (equipSlot[3].EquipItem != null)
				{
					oldWeapon = equipSlot[3].EquipItem as Weapon;
					oldOffhand = equipSlot[5].EquipItem as Weapon;

					if (oldWeapon.CanDualWield == true)
					{
						pi.AddPlayerItem(oldWeapon);
						pi.AddPlayerItem(oldOffhand);

						equipSlot[3].EquipItem = newWeapon;
					}
					else
					{
						return;
					}
				}
				else if (equipSlot[3].EquipItem != null && equipSlot[5].EquipItem == null)
				{
					equipSlot[5].EquipItem = newWeapon;
				}
				else if (equipSlot[5].EquipItem != null && equipSlot[3].EquipItem == null)
				{
					equipSlot[3].EquipItem = newWeapon;
				}
				else
				{
					equipSlot[3].EquipItem = newWeapon;
				}

			}
			else
			{
				//Check to see if slot 1 is a 2hander
				if (equipSlot[3].EquipItem != null)
				{
					oldWeapon = equipSlot[3].EquipItem as Weapon;
					oldOffhand = equipSlot[5].EquipItem as Weapon;

					if (oldWeapon.CanDualWield == true)
					{
						pi.AddPlayerItem(oldWeapon);
						pi.AddPlayerItem(oldOffhand);

						equipSlot[3].EquipItem = newWeapon;
					}
					else
					{
						return;
					}
				}
				else if (equipSlot[3].EquipItem != null && equipSlot[5].EquipItem == null)
				{
					equipSlot[5].EquipItem = newWeapon;
				}
				else if (equipSlot[5].EquipItem != null && equipSlot[3].EquipItem == null)
				{
					equipSlot[3].EquipItem = newWeapon;
				}
				else
				{
					equipSlot[3].EquipItem = newWeapon;
				}
			}

			Debug.Log("Weapon equipped. ");
		}

		private void AddAccessory(Equipment newAcc)
		{
			Debug.Log("Accessory added. ");
		}
	}
}