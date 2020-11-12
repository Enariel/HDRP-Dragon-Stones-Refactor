//Copyright (c) FuchsFarbe

using Dragon_Stones.Spell_System;
using UnityEngine;

/* ============================================
*               Damage Calculation
* --------------------------------------------
*		The damage calculations are created
*	in this script.
*  ===========================================
*/
namespace Dragon_Stones.Character.State
{
    public class Damage_Calculation
    {
		#region Variables

		//References

		//Variables

		#endregion

		public void ApplyDamage(Character_Stats target, Element element)
		{
			int magDam = TotalMagickDamage(target, element);
			int physDam = TotalPhysicalDamage(target, element);
		}
		private int TotalMagickDamage(Character_Stats cs, Element element)
		{
			int dmg = 0;
			return dmg;
		}
		private int TotalPhysicalDamage(Character_Stats cs, Element element)
		{
			int dmg = 0;
			return dmg;
		}

	}
}