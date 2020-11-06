//Copyright (c) FuchsFarbe

using System.Collections.Generic;
using UnityEngine;
using Dragon_Stones.Spell_System;

/* ============================================
*                   Name
* --------------------------------------------
*           - Summary of script - 
*  ===========================================
*/
namespace Dragon_Stones
{
    public class Spell_Tester : MonoBehaviour
    {
        #region Variables

        //References
        public List<Spell> spells = new List<Spell>();
        private GameObject player;
        //Variables

        #endregion

        void Start()
		{
            player = GameObject.FindGameObjectWithTag("Player");
		}

        void Update()
		{
            if (Input.GetButtonDown("Spell_1"))
			{
                foreach (Spell spell in spells)
				{
                    spell.Cast(spell, player);
				}
			}
		}

    }
}