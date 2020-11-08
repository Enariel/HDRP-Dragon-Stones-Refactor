//Copyright (c) FuchsFarbe

using System.Collections.Generic;
using UnityEngine;
using Dragon_Stones.Spell_System;
using Dragon_Stones.Character.Stats;
using Dragon_Stones.Game_Managers.Target;

/* ============================================
*                   Name
* --------------------------------------------
*           - Summary of script - 
*  ===========================================
*/
namespace Dragon_Stones.Spell_System
{
    public class Spellbook : MonoBehaviour
    {
        #region Variables
        //References
        public List<Spell> spells;
        public List<Spell> playerSpells;
        private GameObject player;
		//Variables
		#endregion

		#region Singleton Spellbook Instance
		//Singleton Region
		public static Spellbook instance;
		public static Spellbook Instance
		{
			get
			{
				if (instance == null)
				{
					instance = FindObjectOfType<Spellbook>();

					if (instance == null)
					{
						GameObject spare = new GameObject("Spellbook");
						instance = spare.AddComponent<Spellbook>();
					}
				}

				return instance;
			}
		}
		#endregion

		#region Unity Methods
		void Start()
		{
            player = GameObject.FindGameObjectWithTag("Player");
		}

        void Update()
		{
			CastPlayerSpell();
		}
		#endregion
		public void CastPlayerSpell()
		{
			if (Input.GetButtonDown("Spell_1"))
			{
				foreach (Spell spell in spells)
				{
					//Take away costs
					Cast(spell, player);
				}
			}
		}
		public void Cast(Spell aSpell, GameObject aCaster)
		{
			Cast_Spell cs = new Cast_Spell(aSpell, aCaster);
			StartCoroutine(cs.Invoke());
		}
    }
}