//Copyright (c) FuchsFarbe

using Dragon_Stones.Character.State;
using System.Collections;
using UnityEngine;

/* ============================================
*                   Name
* --------------------------------------------
*           - Summary of script - 
*  ===========================================
*/
namespace Dragon_Stones.Spell_System.Forms
{
	public class Burn_Debuff : MonoBehaviour, IBuff
	{
		#region Variables

		//References

		//Variables
		[SerializeField] private float tickSeconds;
		[SerializeField] private Element thisElement = Element.Fire;

		#endregion
		public IEnumerator DoBuff(Cast spellInst, GameObject target, Vector3 targetPos)
		{
			var spellData = spellInst.Data;
			Character_Stats targetStats = target.GetComponent<Character_Stats>();
			int timer = 0;
			//Duration based off of modifier and spell duration
			while (timer < spellData.duration + (spellData.duration * spellData.modifierPercent))
			{
				if (targetStats)
				{

				}
				yield return new WaitForSeconds(tickSeconds);
				timer++;
			}
		}
	}
}