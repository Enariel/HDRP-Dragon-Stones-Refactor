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
		//Variables
		[Header("Basic Information")]
		[SerializeField] private readonly string title;
		[SerializeField] private readonly string desc;
		[SerializeField] private readonly string id;
		[SerializeField] private int shopBaseCost;
		[SerializeField] private int shopSellCost;
		[SerializeField] private bool canSell = true;

		[Header("Visuals")]
		[SerializeField] private GameObject itemPreFab;
		[SerializeField] private Sprite icon;

		#region Getters

		public string Title { get => title; }
		public string Desc { get => desc; }
		public string Id { get => id; }
		public int ShopBaseCost { get => shopBaseCost; }
		public int ShopSellCost { get => shopSellCost; }
		public bool CanSell { get => canSell; }
		public GameObject ItemPreFab { get => itemPreFab; }
		public Sprite Icon { get => icon; }

		#endregion

		//Abstract functions for using items
		public abstract void UseItem(Item item);
	}
}