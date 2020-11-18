//Copyright (c) FuchsFarbe

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* ============================================
*				Linear Projectiles
* --------------------------------------------
*		Linear projectiles follow the initial
*	path of origin and instantiate a 
*	projectile gameobject. They add a mono-
*	behaviour of projectile on the instance.
*  ===========================================
*/
namespace Dragon_Stones.Spell_System.Forms
{
	[CreateAssetMenu(fileName = "New Linear Projectile Form", menuName = "Form/LinearProj Form")]
	public class Linear_Projectile_Form : Form
	{
		#region Variables
		//References
		Vector3 _casterPos;
		Vector3 _targetPos;
		//Variables
		[SerializeField] protected GameObject projectile; //Projectile to instantiate
		private GameObject projectileClone;
		[SerializeField] private Vector3 offset = new Vector3(1f, 1f, 1f); //Its offset. 
		[SerializeField] private float speed = 20f; //How fast it will move
		[SerializeField] private float delay = 1f; //Delay for animations
		#endregion
		public override IEnumerator DoForm(Cast castInst, GameObject target, Vector3 targetPos)
		{
			yield return FireProjectileWithDelay(castInst, target, targetPos);
			yield break;
		}
		private IEnumerator FireProjectileWithDelay(Cast castInst, GameObject target, Vector3 targetPos)
		{
			
			yield return new WaitForSeconds(delay);
			//Get spell caster
			GameObject caster = castInst.Caster;
			Vector3 spawnPoint = caster.transform.TransformPoint(offset);

			//Instantiate a prefab by caster's projectile point.
			projectileClone = Instantiate(projectile, spawnPoint, caster.transform.rotation);
			Projectile linearInst = projectileClone.AddComponent<Projectile>();

			//Add data to the monobehaviour.
			linearInst.castInst = castInst;
			linearInst.targetPos = targetPos;
			linearInst.speed = speed;
			linearInst.hitForms = castInst._EventDict[SpellEvent.OnProjectileHit.ToString()];
		}
	}
}