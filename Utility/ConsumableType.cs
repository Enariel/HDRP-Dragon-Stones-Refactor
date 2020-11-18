using System;

/* ============================================
 *              Consumables
 * --------------------------------------------
 *      Consumables are items that can be 
 *  stacked, made, and alter stats. Consumables
 *  use a simpler version of a Spell-Form 
 *  system. 
 *      Stacking is set to a default of 99, 
 *  but the stack amount can be modified here
 *  as long as 'canStack' = true
 *  ===========================================
 */

namespace Dragon_Stones.Inventory_Systems
{
	[Flags]
	public enum ConsumableType
	{
		health = 1 << 0,
		buff = 1 << 1,
		Phyr = 1 << 2,
		recipeItem = 1 << 3
	}
}
