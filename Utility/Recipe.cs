using UnityEngine;

/* ============================================
 *                  Recipe
 * --------------------------------------------
 *      Recipe SO adds modularity to creating
 *  recipes for the game. A recipe is used to 
 *  create consumables or other items.
 *  ===========================================
 */

namespace Dragon_Stones.Inventory_Systems
{
	[CreateAssetMenu(menuName = "Item/Recipe", fileName = "New Recipe")]
	class Recipe : ScriptableObject
	{
		[Header("Recipe Details")]
		[SerializeField] private Consumable ingredient;
		[SerializeField] private int ingredientAmount;

		public void CreateItem(Item aItem)
		{
			Debug.Log("You made a" + aItem.Title + "!");
		}
	}
}

