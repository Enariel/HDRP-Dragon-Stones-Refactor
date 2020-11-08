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
		[SerializeField] private GameObject projectile;
		[SerializeField] private Vector3 offset = new Vector3(1f, 1f, 1f);
		[SerializeField] private float speed = 1f;
		#endregion
		public override IEnumerator DoForm(Cast_Spell casterSpell, GameObject target, Vector3 targetPos)
		{
			GameObject caster = casterSpell.Caster;
			Vector3 casterPos = caster.transform.position;

			var ProjInst = Instantiate(projectile, casterPos + offset, caster.transform.rotation);
			var linearInst = ProjInst.AddComponent<Projectile>();

			yield return new WaitForEndOfFrame();

			linearInst.castInst = casterSpell;
			linearInst.targetPos = targetPos;
			yield return linearInst.FireProjectile(speed);

			yield return null;
			Debug.Log("Returned null in Projectile Form");
		}
	}
}