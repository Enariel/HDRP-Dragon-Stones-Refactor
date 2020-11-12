//Copyright (c) FuchsFarbe

using UnityEngine;

/* ============================================
*               Player Targets
* --------------------------------------------
*       Finds valid player targets. Should 
*   also implement future functionality for 
*   target switching.
*  ===========================================
*/
namespace Dragon_Stones.Game_Managers.Target
{
    public class Player_Targets : Target_System
    {
        #region Variables

        //References
        //Variables
        #endregion

        public void Start()
		{
            StartCoroutine(FindValidTargets());
		}
    }
}