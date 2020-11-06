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
        public GameObject player;
        //Variables
        [SerializeField] private LayerMask layer;
        #endregion

        private void Start()
		{
            layer = LayerMask.GetMask("Enemy");
            StartCoroutine(FindValidTargets(player, TargetRadius, layer));
		}

        void OnDrawGizmosSelected()
		{
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(player.transform.position, TargetRadius);
		}
    }
}