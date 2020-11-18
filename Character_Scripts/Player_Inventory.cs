using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/* ============================================
 *              Player Inventory
 * --------------------------------------------
 *		Keeps track of player items.
 *  ===========================================
 */


namespace Dragon_Stones.Inventory_Systems
{
    public class Player_Inventory : Inventory
    {
		#region Player Inventory Singleton
		//Player's Inventory singleton
		public static Player_Inventory instance;
		private void Awake()
		{
			if (instance != null)
			{
				Debug.LogWarning("More than one player inventory instance");
			}

			instance = this;
		}
		#endregion

		#region Variables

		//Events
		public delegate void OnItemChanged();
		public static event OnItemChanged ItemsChanged;
		//Variables
		public List<Item> playerItems = new List<Item>();
		[SerializeField] private int bagSlots = 20; //Max bag slots 

		#endregion

		#region Unity Methods
		private void Start()
		{
			ItemsChanged?.Invoke();
		} 
		#endregion

		public void AddPlayerItem(Item aItem)
		{
			if (playerItems.Count >= bagSlots)
			{
				Debug.Log("Not enough bag space.");
			}

			playerItems.Add(aItem);

			//Make sure there is a method subscribed before calling it
			ItemsChanged?.Invoke();
		}
		public void RemovePlayerItem(Item aItem)
		{
			playerItems.Remove(aItem);
			ItemsChanged?.Invoke();
		}
	}
}