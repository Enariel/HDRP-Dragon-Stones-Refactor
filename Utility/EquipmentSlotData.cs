//Copyright (c) FuchsFarbe

using System;
using UnityEngine;

/* ============================================
*				Equipment Slot Data
* --------------------------------------------
*		Equipment slot data tells which slot
*	in the character equipment to bind to.
*  ===========================================
*/
namespace Dragon_Stones.Inventory_Systems
{
	[Serializable]
	public class EquipmentSlotData
	{
		[SerializeField] private EquipSlot slot;
		[SerializeField] private Equipment equipItem;

		public EquipmentSlotData(EquipSlot slot, Equipment equipItem)
		{
			this.slot = slot;
			this.equipItem = equipItem;
		}

		public EquipSlot Slot { get => slot; set => slot = value; }
		public Equipment EquipItem { get => equipItem; set => equipItem = value; }
	}
	
}