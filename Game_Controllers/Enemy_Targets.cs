//Copyright (c) FuchsFarbe

using UnityEngine;

/* ============================================
*               Enemy Target
* --------------------------------------------
*       Finds valid player target, there 
*   should only be one.
*  ===========================================
*/
namespace Dragon_Stones.Game_Managers.Target
{
    public class Enemy_Targets : Target_System
    {
        #region Variables

        //References
        public GameObject enemy;
        //Variables
        #endregion

        private void Start()
        {
            StartCoroutine(FindPlayerTarget(enemy, TargetRadius));
        }

        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(enemy.transform.position, TargetRadius);
        }
    }
}