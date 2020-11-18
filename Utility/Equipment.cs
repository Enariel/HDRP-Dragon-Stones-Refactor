
using System.Collections.Generic;
using UnityEngine;

namespace Dragon_Stones.Inventory_Systems
{
	[CreateAssetMenu(menuName = "Item/Equipment", fileName = "New Equipment")]
    public class Equipment : Item
    {
        [Header("Equipment Details")]
        [SerializeField] EquipSlot slot;
        [SerializeField] private List<StatModifiers> statsToMod;

		//Getters
		#region Getters

		public EquipSlot Slot { get => slot; }
		public List<StatModifiers> StatsToMod { get => statsToMod; } 

		#endregion

		public override void UseItem(Item aItem)
        {
            //Use here will equip an item to a slot
            Equipment_Manager.instance.EquipItem(aItem as Equipment);
            RemoveFromInventory();
        }
    }
}
