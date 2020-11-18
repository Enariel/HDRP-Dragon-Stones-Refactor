using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/* ============================================
 *                  Inventory
 * --------------------------------------------
 *      Base inventory script from which other
 *  characters, enemies, and NPCs will have.
 *  ===========================================
 */


namespace Dragon_Stones.Inventory_Systems
{
    public class Inventory : MonoBehaviour
    {
        //Variables
        [SerializeField] private List<Item> items;

        public void AddItem(Item aItem)
		{
            items.Add(aItem);
		}
        public void RemoveItem(Item aItem)
		{
            items.Remove(aItem);
		}
    }
}