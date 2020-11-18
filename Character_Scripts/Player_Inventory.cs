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
		public Item[] playerEquipment = new Item[10];
		[SerializeField] private int bagSlots = 20; //Max bag slots 

		public int BagSlots { get => bagSlots; set => bagSlots = value; }

		#endregion

		#region Unity Methods
		private void Start()
		{
			ItemsChanged?.Invoke();
		}
		#endregion

		#region Custom Methods
		public void AddPlayerItem(Item aItem)
		{
			if (playerItems.Count >= bagSlots)
			{
				Debug.Log("Not enough bag space.");
			}
			else
			{
				playerItems.Add(aItem);
			}

			//Make sure there is a method subscribed before calling it
			ItemsChanged?.Invoke();
		}
		public void RemovePlayerItem(Item aItem)
		{
			//TODO: Invoke prompt
			playerItems.Remove(aItem);
			//Keeps list from being populated with null values
			playerItems.RemoveAll(aItem => aItem == null);
			ItemsChanged?.Invoke();
		} 
		#endregion
	}
}