//Copyright (c) FuchsFarbe

using UnityEngine;
using Dragon_Stones.Character;

/* ============================================
*               Item Object
* --------------------------------------------
*       The monobehaviour that describes
*   item interactions with the player in the
*   physical overworld.
*  ===========================================
*/
namespace Dragon_Stones.Inventory_Systems
{
    public class ItemObject : MonoBehaviour, IInteractable
	{
		#region Variables

		//References
		private Player_Inventory pi;
		[SerializeField] private Item item;
		//Variables
		#endregion

		#region Unity Methods

		private void Start()
		{
			pi = Player_Inventory.instance;
		}

		#endregion

		public void Interact()
		{
			Debug.Log("Interacting with " + item.Title);

			//TODO: Add checks for picking up the item
			//Check to make sure inventory isnt full
			if (pi.playerItems.Count < pi.BagSlots)
			{
				pi?.AddPlayerItem(item);
				//Destory item once added
				Destroy(this.gameObject);
			}
		}
	}
}