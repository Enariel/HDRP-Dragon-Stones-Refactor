using UnityEngine;

/* ============================================
 *              Item Display
 * --------------------------------------------
 *      This is the UI display manager for 
 *  dealing with items and inventories.
 *  ===========================================
 */

namespace Dragon_Stones.Inventory_Systems
{
    public class Inventory_Display : MonoBehaviour
    {
        //References
        public Inventory bag;
        public Transform content; //The transform content of an inventory 
        public Item_Display displayPrefab;
        //Variables


        private void Start()
        {
            if (bag)
            {
                return;
            }
        }

        //Takes Item as parameter to display the Item
        public virtual void DisplayContents(Inventory aBag)
        {
            //Make sure not more than one listener, keep it clean
            if (this.bag)
            {
                return;
            }
            //Add event to inventory to listen for change
            this.bag = aBag;
            RefreshBagContents();
        }

        public virtual void RefreshBagContents()
        {
            //Clear contents first
            foreach(Transform t in content)
            {
                Destroy(t.gameObject);
            }
            //Grab each item from inventory
            foreach (Item item in bag.items)
            {
                //Instantiate UI prefab
                Item_Display display = Item_Display.Instantiate(displayPrefab, content);
                //Add event listener
            }
        }

        #region Event Responders

        public void AddToPlayerBag(Item item)
        {
            Player_Inventory.player_Inventory.AddItem(item);
        }
        public void RemoveFromThisBag(Item item)
        {
            bag.RemoveItem(item);
        }
        public void UseItem(Item item)
        {
            item.UseItem(item);
        }

        #endregion
    }
}