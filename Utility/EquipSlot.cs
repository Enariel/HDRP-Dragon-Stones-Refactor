using System;

namespace Dragon_Stones.Inventory_Systems
{
	[Flags]
    public enum EquipSlot
    {
		head = 1 << 0,
        hand1 = 1 << 1,
        hand2 = 1 << 2,
        auxHand1 = 1 << 3,
        auxHand2 = 1 << 4,
        chest = 1 << 5,
        legs = 1 << 6,
        feet = 1 << 7,
        accessory1 = 1 << 8,
        accessory2 = 1 << 9,
    }
}
