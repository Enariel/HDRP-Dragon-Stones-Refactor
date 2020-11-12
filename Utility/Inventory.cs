using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/* ============================================
 *                  Inventory
 * --------------------------------------------
 *      Base inventory script from which other
 *  characters, enemies, and NPCs will have.
 *  
 *      For players, it serves as a bag, for
 *  enemies it'll serve as a drop table. For
 *  NPCs itll be items contained within their 
 *  shops.
 *  ===========================================
 */


namespace Dragon_Stones.Inventory_Systems
{
    public class Inventory : MonoBehaviour
    {
        //Variables
        public List<Item> items;

        public virtual void AddItem(Item item)
        {
            items.Add(item);
        }
        public virtual void RemoveItem(Item item)
        {
            if (!items.Contains(item))
            {
                return;
            }
            items.Remove(item);
        }
    }
}