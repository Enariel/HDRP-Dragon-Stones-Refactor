//Copyright (c) FuchsFarbe

using UnityEngine;

/* ============================================
 *                    Item
 * --------------------------------------------
 *      Base item class from which every item 
 *  has in order to be interacted with.
 *  ===========================================
 */

namespace Dragon_Stones.Inventory_Systems
{
	[CreateAssetMenu(menuName = "Item")]
	public abstract class Item : ScriptableObject
	{
		#region Variables
		//Variables
		[Header("Basic Information")]
		[SerializeField] private string title;
		[SerializeField] private string desc;
		[SerializeField] private string id;
		[SerializeField] private int shopBaseCost;
		[SerializeField] private int shopSellCost;
		[SerializeField] private bool canSell = true;

		[Header("Visuals")]
		[SerializeField] private GameObject itemPreFab;
		[SerializeField] private Sprite icon; 
		#endregion

		#region Getters and Setters
		public string Title => title;

		public string Desc => desc;

		public string Id => id;

		public int ShopBaseCost { get => shopBaseCost; set => shopBaseCost = value; }
		public int ShopSellCost { get => shopSellCost; set => shopSellCost = value; }
		public bool CanSell { get => canSell; set => canSell = value; }
		public GameObject ItemPreFab { get => itemPreFab; set => itemPreFab = value; }
		public Sprite Icon { get => icon; set => icon = value; }

		#endregion

		//Abstract functions for using items
		public abstract void UseItem(Item item);
	}
}