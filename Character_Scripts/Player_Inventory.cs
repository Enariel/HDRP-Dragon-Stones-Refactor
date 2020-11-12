using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/* ============================================
 *              Player Inventory
 * --------------------------------------------
 *      Singleton class that inherits Inventory
 *  base class. This will make it easier to 
 *  keep references to player inventory as well
 *  as separate player bags from other types
 *  of inventories.
 *  ===========================================
 */


namespace Dragon_Stones.Inventory_Systems
{
    public class Player_Inventory : Inventory
    {
        //Instance
        public static Player_Inventory player_Inventory;

        private void Awake()
        {
            if (player_Inventory == null)
            {
                player_Inventory = this;
            }
            else if (player_Inventory != this)
            {
                Destroy(this.gameObject);
            }
        }
    }
}