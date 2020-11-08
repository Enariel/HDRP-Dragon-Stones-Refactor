//Copyright (c) FuchsFarbe

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* ============================================
*					Projectile
* --------------------------------------------
*		Projectiles are spawned at the casters
*	location and they spawn with speed.
*	Projectiles should all either explode
*	or dissappear on impact.
*  ===========================================
*/
namespace Dragon_Stones.Spell_System.Forms
{
	[RequireComponent(typeof(Rigidbody), typeof(SphereCollider))]
	public class Projectile : MonoBehaviour
	{
		#region Variables
		//Variables
		//References
		public Cast_Spell castInst;
		public Rigidbody rb;
		public SphereCollider col;
		public Vector3 targetPos;
		#endregion

		//Set velocity and it should be destoryed on impact

		#region Unity Methods
		private void Start()
		{
			Debug.Log("Projectile created.");
			SetBodies();
		}
		public void OnTriggerEnter(Collider other)
		{
			if (other.gameObject != castInst.Caster)
			{
				if (other.gameObject.CompareTag("Ground"))
				{
					StartCoroutine(castInst.OnProjHit(null));
				}
				else
				{
					StartCoroutine(castInst.OnProjHit(other.gameObject));
				}

				ParticleSystem ps = this.gameObject.GetComponent<ParticleSystem>();
				if (ps != null)
				{
					ps.Stop();
				}
			}
		}
		#endregion

		public IEnumerator FireProjectile(float speed)
		{
			while(this.transform.position != targetPos)
			{
				transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
				yield return null;
			}
		}

		//Creates references and sets proper variables of references
		private void SetBodies()
		{
			rb = this.GetComponent<Rigidbody>();
			col = this.GetComponent<SphereCollider>();

			rb.isKinematic = true;
			rb.useGravity = false;
			rb.constraints = RigidbodyConstraints.FreezeAll;

			col.isTrigger = true;
		}

		//Gizmos
		public void OnDrawGizmos()
		{
			Color color = Color.green;
			Gizmos.DrawWireCube(this.gameObject.transform.position, col.bounds.size);
		}
	}
}