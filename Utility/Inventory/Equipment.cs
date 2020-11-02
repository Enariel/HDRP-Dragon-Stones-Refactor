using System;
using UnityEngine;

namespace Dragon_Stones.Inventory_Systems
{
    [Flags]
    public enum EquipSlot
    {
        head = 1 << 0,
        headAccessory = 1 << 1,
        hand1 = 1 << 2,
        hand2 = 1 << 3,
        auxHand1 = 1 << 4,
        auxHand2 = 1 << 5,
        chest = 1 << 6,
        legs = 1 << 7,
        feet = 1 << 8,
        accessory1 = 1 << 9,
        accessory2 = 1 << 10,
    }
    [Flags]
    public enum StatModifiers
    {
        Strength = 1 << 0,
        Magick = 1 << 1,
        Dexterity = 1 << 2,
        Health = 1 << 3,
        Phyr = 1 << 4,
    }

    [CreateAssetMenu(menuName = "Item/Equipment", fileName = "New Equipment")]
    class Equipment : Item
    {
        [Header("Equipment Details")]
        [SerializeField] EquipSlot slot;
        [SerializeField] StatModifiers statsToMod;
        public override void UseItem(Item aItem)
        {
            //Use here will equip an item to a slot
            Debug.Log(this.Title + "has been used");
        }
        public override void UseManyItems(Item aItem, int aAmount)
        {
            throw new NotImplementedException();
        }
    }
}
