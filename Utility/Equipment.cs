
using System.Collections.Generic;
using UnityEngine;

namespace Dragon_Stones.Inventory_Systems
{
	[CreateAssetMenu(menuName = "Item/Equipment", fileName = "New Equipment")]
    class Equipment : Item
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
            Debug.Log(this.Title + " has been used");
            //Make sure item is passed as equipment so it can be equipped
            Equip(aItem as Equipment);
        }
        public void Equip(Equipment equipment)
		{
            Debug.Log("Equipping: " + equipment.Title);
		}
    }
}
