using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionControllerScript : MonoBehaviour {

	public Transform leftHand, rightHand;
	private Animator animator;
	// Use this for initialization
	void Start () {
		animator=GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnAnimatorIK(int layerIndex) {
        animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
        animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
        animator.SetIKPosition(AvatarIKGoal.LeftHand, leftHand.position);
        animator.SetIKPosition(AvatarIKGoal.RightHand, rightHand.position);
    }
}
