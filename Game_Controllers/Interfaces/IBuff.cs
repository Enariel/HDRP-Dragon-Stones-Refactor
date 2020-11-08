//Copyright (c) FuchsFarbe

/* ============================================
*                   IBuff
* --------------------------------------------
*       Interface for doing buffs and debuffs
*  ===========================================
*/
using System.Collections;
using UnityEngine;

namespace Dragon_Stones.Spell_System.Forms
{
    public interface IBuff
    {
        #region Variables

        //References

        //Variables

        #endregion

        IEnumerator DoBuff(Cast_Spell spellInst, GameObject target, Vector3 targetPos);
    }
}