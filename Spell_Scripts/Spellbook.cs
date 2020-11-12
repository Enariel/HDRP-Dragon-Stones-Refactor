//Copyright (c) FuchsFarbe

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Dragon_Stones.Input;

/* ============================================
*					Spellbook
* --------------------------------------------
*		Contains methods for executing spells
*	and also acts like a centralized spell 
*	database.
*  ===========================================
*/
namespace Dragon_Stones.Spell_System
{
    public class Spellbook : MonoBehaviour
    {
        #region Variables
        //References
        private GameObject player;
		//Variables
		#endregion

		#region Input Events
		//Main controls
		private Dragon_Stones_Input inputMaps;
		//Individual events
		private InputAction spell1;
		private InputAction spell2;
		private InputAction spell3;
		private InputAction spell4;
		private InputAction basicAttack;
		#endregion

		#region Singleton Spellbook Instance
		//Singleton Region
		public static Spellbook _instance;
		public static Spellbook Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = FindObjectOfType<Spellbook>();

					if (_instance == null)
					{
						GameObject spare = new GameObject("Spellbook");
						_instance = spare.AddComponent<Spellbook>();
					}
				}

				return _instance;
			}
		}
		#endregion

		#region Unity Methods
		private void Awake()
		{
			inputMaps = new Dragon_Stones_Input();

			spell1 = inputMaps.Combat.Spell_1;
			spell2 = inputMaps.Combat.Spell_2;
			spell3 = inputMaps.Combat.Spell_3;
			spell4 = inputMaps.Combat.Spell_4;
			basicAttack = inputMaps.Combat.Basic_Attack;
		}
		void Start()
		{
            player = GameObject.FindGameObjectWithTag("Player");
		}
		private void OnEnable()
		{
			spell1.Enable();
			spell2.Enable();
			spell3.Enable();
			spell4.Enable();
			basicAttack.Enable();
		}
		private void OnDisable()
		{
			spell1.Disable();
			spell2.Disable();
			spell3.Disable();
			spell4.Disable();
			basicAttack.Disable();
		}
		#endregion
    }
}