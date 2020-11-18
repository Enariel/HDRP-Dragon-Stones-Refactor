//Copyright (c) FuchsFarbe

using System;
using UnityEngine;

namespace Dragon_Stones.Inventory_Systems
{
	[Serializable]
    public class StatModifiers
    {
        [SerializeField] private Stat stat;
        [SerializeField] private float bonus;

		#region Getters

		public Stat Stat { get => stat; set => stat = value; }
		public float Bonus { get => bonus; set => bonus = value; } 

		#endregion
	}
}
