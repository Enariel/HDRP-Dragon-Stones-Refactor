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
		public float speed;
		public Vector3 targetPos;
		public List<Form> hitForms = new List<Form>();
		private GameObject caster;
		private Vector3 casterPos;
		private float maxDist;
		#endregion

		//Set velocity and it should be destoryed on impact

		#region Unity Methods
		private void Start()
		{
			Debug.Log("Projectile created.");
			StartCoroutine(FireProjectile(speed));
			SetBodies();
		}
		public void Update()
		{
			Vector3 thisPos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
			float distanceFromCast = Vector3.Distance(thisPos, casterPos);
			if (distanceFromCast >= maxDist)
			{
				ParticleSystem ps = this.gameObject.GetComponent<ParticleSystem>();

				if (ps != null)
				{
					ps.Stop();
				}
				this.gameObject.SetActive(false);
			}
		}
		public void OnTriggerEnter(Collider other)
		{
			ParticleSystem ps = this.gameObject.GetComponent<ParticleSystem>();

			if (caster.CompareTag("Player") && other.CompareTag("Enemy"))
			{
				castInst.OnProjectileHit(castInst, other.gameObject, hitForms);
				if (ps != null)
				{
					ps.Stop();
				}
			}
			else if (caster.CompareTag("Enemy") && other.CompareTag("Player"))
			{
				castInst.OnProjectileHit(castInst, other.gameObject, hitForms);
				if (ps != null)
				{
					ps.Stop();
				}
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
			yield break;
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
			caster = castInst.Caster;
			casterPos = caster.transform.position;
			maxDist = castInst.Data.maxRange;
		}

		//Gizmos
		public void OnDrawGizmos()
		{
			Color color = Color.green;
			Gizmos.DrawWireCube(this.gameObject.transform.position, col.bounds.size);
		}
	}
}