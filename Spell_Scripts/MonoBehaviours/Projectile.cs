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
		public Cast castInst;
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
			if (other.gameObject == castInst.Caster || other.gameObject.CompareTag("Ground"))
			{
				Debug.Log("Collided with" + other.name);
			}
			else
			{
				Cast newCastInst = new Cast(castInst.Data, castInst.Caster);
				newCastInst.OnProjectileHit(other.gameObject, newCastInst._EventDict[SpellEvent.OnProjectileHit.ToString()]);

				ParticleSystem ps = this.gameObject.GetComponent<ParticleSystem>();

				if (ps != null)
				{
					ps.Stop();
				}
				this.gameObject.SetActive(false);
			}
		}
		#endregion
		public IEnumerator FireProjectile(float speed)
		{
			//While distance between projectile and initial target point is shorter than a certain distance
			var distance = Vector3.Distance(transform.position, targetPos);
			while (distance > .075f)
			{
				//Move projectile at speed specified by form
				transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
				yield return new WaitForEndOfFrame();
			}
			yield return null;
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