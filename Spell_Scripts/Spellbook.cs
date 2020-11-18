//Copyright (c) FuchsFarbe

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Dragon_Stones.Input;
using System;

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
		private Dictionary<string, Ability> m_SpellMap = new Dictionary<string, Ability>();
		[SerializeField] private List<Ability> abilities;
		public string spellID = "";
		#endregion

		#region Input Events
		//Main controls
		private Dragon_Stones_Input input;
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
			//Empty dictionary and refill it
			m_SpellMap = new Dictionary<string, Ability>();

			foreach (Ability spell in abilities)
			{
				m_SpellMap.Add(spell.id, spell);
			}

			//Input stuff
			input = new Dragon_Stones_Input();

			spell1 = input.Combat.Spell_1;
			spell2 = input.Combat.Spell_2;
			spell3 = input.Combat.Spell_3;
			spell4 = input.Combat.Spell_4;

			basicAttack = input.Combat.Basic_Attack;

			spell1.performed += ctx => PlayerCast(ctx);
		}
		private void PlayerCast(InputAction.CallbackContext ctx)
		{
			//TODO: Get spell data from somewhere to cast the correct spell.
			ExecuteSpell(m_SpellMap[spellID]);
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
		void ExecuteSpell(Ability aSpell)
		{
			StartCoroutine(aSpell.Execute(aSpell, player));
		}
    }
}