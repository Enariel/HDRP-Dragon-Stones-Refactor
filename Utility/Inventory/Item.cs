using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        [SerializeField] private string title;
        [SerializeField] private string desc;
        [SerializeField] private string id;
        [SerializeField] private int shopBaseCost;
        [SerializeField] private int shopSellCost;
        [SerializeField] private bool canSell = true;

        [Header("Visuals")]
        [SerializeField] private GameObject itemPreFab;
        [SerializeField] private Sprite icon;

        //Abstract functions

        //Use item
        public abstract void UseItem(Item item);
        public abstract void UseManyItems(Item item, int aAmount);


        //Getters and Setters
        public string Title { get => title; set => title = value; }
    }
}