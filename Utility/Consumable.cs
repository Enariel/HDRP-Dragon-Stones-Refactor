using System;
using System.Collections.Generic;
using UnityEngine;

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

    [CreateAssetMenu(menuName = "Item/Consumable", fileName = "New Consumable")]
    class Consumable : Item
    {
        [Header("Consumable Details")]
        [SerializeField] private ConsumableType conType;
        [Tooltip("This property is the base property for modifications to any stat or buff. If you want to make an HP potion, set this to the amount you want to heal by. If a buff, set it to a percent in '90' or '87.34' format. ")]
        [SerializeField] private float mod;
        [SerializeField] private bool canStack = true;
        [SerializeField] private int maxStack = 99;
        [Header("Recipe")]
        [SerializeField] private Recipe[] recipe;

        public override void UseItem(Item aItem)
        {
            //Will consume the item and remove it from a stack
            Debug.Log(aItem.Title + "has been used");
        }
        public override void UseManyItems(Item aItem, int aAmount)
        {
            throw new NotImplementedException();
        }
    }
}
