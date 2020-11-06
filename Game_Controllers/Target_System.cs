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
        [SerializeField] private float targetRadius = 1f;
        [SerializeField] private float updateTime = .1f;

        public List<GameObject> targets;
        public GameObject mainTarget;
		#endregion

		#region Unity Methods

        #endregion

		public IEnumerator FindValidTargets(GameObject aCenter, float aTargetRadius, LayerMask aLayer)
		{
			while (true)
			{
                yield return new WaitForSeconds(updateTime);

                Collider[] targetColliders = Physics.OverlapSphere(FindCenter(aCenter), aTargetRadius, aLayer); ;
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

        public IEnumerator FindPlayerTarget(GameObject aCenter, float aTargetRadius)
		{
            while (true)
            {
                yield return new WaitForSeconds(updateTime);

                Collider[] targetColliders = Physics.OverlapSphere(FindCenter(aCenter), aTargetRadius); ;

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

        private Vector3 FindCenter(GameObject centerTarget)
		{
            return centerTarget.transform.position;
		}

        public float TargetRadius { get => targetRadius; }
        public float UpdateTime { get => updateTime; }
    }
}