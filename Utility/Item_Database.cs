//Copyright (c) FuchsFarbe

using Dragon_Stones.Inventory_Systems;
using System.Collections.Generic;
using UnityEngine;

/* ============================================
*               Item Database
* --------------------------------------------
*       The item database is just a way to 
*   store all of the games items.
*  ===========================================
*/
namespace Dragon_Stones
{
    public class Item_Database : MonoBehaviour
    {
		#region Variables

		//References

		//Variables
		public List<Item> gameItems;
		#endregion

		#region Singleton
		public static Item_Database instance;
		private void Awake()
		{
			instance = this;
		}
		#endregion

	}
}