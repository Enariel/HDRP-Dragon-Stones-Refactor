using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_Base_Charge_Effects : StateMachineBehaviour
{
	// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	//override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	//{
	//    
	//}
	public GameObject fireEffect;
	public GameObject caster;
	public Transform leftHand;
	public Transform rightHand;

	protected GameObject leftFireEffectClone;
	protected GameObject rightFireEffectClone;
	protected ParticleSystem rps;
	protected ParticleSystem lps;
	public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		caster = animator.gameObject;

		if (leftFireEffectClone == null && rightFireEffectClone == null)
		{
			leftHand = animator.GetBoneTransform(HumanBodyBones.LeftHand);
			rightHand = animator.GetBoneTransform(HumanBodyBones.RightHand);

			rightFireEffectClone = Instantiate(fireEffect, rightHand);
			leftFireEffectClone = Instantiate(fireEffect, leftHand);
		}

		lps = leftFireEffectClone.GetComponent<ParticleSystem>();
		rps = rightFireEffectClone.GetComponent<ParticleSystem>();

		lps.Play();
		rps.Play();
	}
	public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		rightFireEffectClone.transform.position = rightHand.position;
		leftFireEffectClone.transform.position = leftHand.position;
	}
	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	//override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	//{
	//    
	//}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	//override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	//{
	//    
	//}
	public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		lps.Stop(true);
		rps.Stop(true);
	}
	// OnStateMove is called right after Animator.OnAnimatorMove()
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	//{
	//    // Implement code that processes and affects root motion
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK()
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	//{
	//    // Implement code that sets up animation IK (inverse kinematics)
	//}
}
