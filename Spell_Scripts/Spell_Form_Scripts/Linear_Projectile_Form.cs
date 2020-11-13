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
		[SerializeField] private GameObject projectile; //Projectile to fire
		[SerializeField] private Vector3 offset = new Vector3(1f, 1f, 1f); //Its offset. 
		[SerializeField] private float speed = 20f; //How fast it will move
		#endregion
		public override IEnumerator DoForm(Cast castInst, GameObject target, Vector3 targetPos)
		{
			//Get spell caster
			GameObject caster = castInst.Caster;
			_casterPos = caster.transform.position;
			var _casterRot = caster.transform.rotation;
			_targetPos = targetPos;

			//Instantiate a prefab by caster's projectile point.
			var ProjInst = Instantiate(projectile, caster.transform.position + offset, new Quaternion(_casterRot.x, _casterRot.y, _casterRot.z, _casterRot.w
				));
			Projectile linearInst = ProjInst.AddComponent<Projectile>();

			//Add data to the monobehaviour.
			linearInst.castInst = castInst;
			linearInst.targetPos = targetPos;

			//Wait for end of frame 
			yield return new WaitForEndOfFrame();
			//Start the enumeration
			yield return linearInst.FireProjectile(speed);
		}
	}
}