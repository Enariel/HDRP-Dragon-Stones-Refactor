//Copyright (c) FuchsFarbe

using Dragon_Stones.Inventory_Systems;
using UnityEngine;
using UnityEngine.UI;

/* ============================================
*               Inventory Slot Ui
* --------------------------------------------
*       This script controls the item display
*   of an inventory slot.
*  ===========================================
*/
namespace Dragon_Stones.UI
{
    public class Inventory_Slot_UI : MonoBehaviour
    {
        #region Variables

        //References
        [SerializeField] private Item item;
        [SerializeField] private Image icon;
        [SerializeField] private Button removeButton;
        //Variables

        #endregion

        public void AddItem(Item newItem)
		{
            item = newItem;

            this.icon.enabled = true;
            this.icon.sprite = item?.Icon;
            removeButton.interactable = true;
            removeButton.gameObject.SetActive(true);
		}

        public void ClearSlot()
		{
            item = null;

            icon.sprite = null;
            icon.enabled = false;
            removeButton.interactable = false;
            removeButton.gameObject.SetActive(false);
        }

        public void OnRemoveButtonPressed()
		{
            Player_Inventory.instance.RemoveItem(item);
		}

    }
}