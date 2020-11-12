//Copyright (c) FuchsFarbe

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* ============================================
*                   Name
* --------------------------------------------
*           - Summary of script - 
*  ===========================================
*/
namespace Dragon_Stones.Game_Managers.Target
{
    public abstract class Target_System : MonoBehaviour
    {
        #region Variables
        //Variables
        [SerializeField] private float targetRadius;
        [SerializeField] private float updateTime = .1f;
        [SerializeField] private LayerMask playerLayer;
        [SerializeField] private LayerMask enemyLayer;

        public List<GameObject> targets;
        public GameObject mainTarget;
        #endregion

        #region Unity Methods
        void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, targetRadius);
        }
        #endregion

        public IEnumerator FindValidTargets()
		{
			while (true)
			{
                yield return new WaitForSeconds(updateTime);

                Collider[] targetColliders = Physics.OverlapSphere(this.gameObject.transform.position, targetRadius, enemyLayer); ;
                targets = new List<GameObject>();

                foreach (Collider collider in targetColliders)
                {

                    targets.Add(collider.gameObject);
                    mainTarget = targets[0];
                }
                if (targets.Count <= 0)
				{
                    mainTarget = null;
				}
            }
        }

        public IEnumerator FindPlayerTarget()
		{
            while (true)
            {
                yield return new WaitForSeconds(updateTime);

                Collider[] targetColliders = Physics.OverlapSphere(this.gameObject.transform.position, targetRadius, playerLayer); ;

                targets = new List<GameObject>();

                foreach (Collider collider in targetColliders)
                {
                    if (collider.gameObject.CompareTag("Player"))
					{
                        targets.Add(collider.gameObject);
                        mainTarget = targets[0];
                    }
                }
                if (targets.Count <= 0)
                {
                    mainTarget = null;
                }
            }
        }
    }
}