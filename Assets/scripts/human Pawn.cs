using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class humanPawn : pawn {
	public Animator anim;
	[Header("Weapon info")]
	public Weapon currentWeapon;
	public List<Weapon> weaponInventory;
	public Transform weaponPosition;
	// Use this for initialization
	public float turnspeed;
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Equip(Weapon weaponToEquip){
		//Instantiate weapon passed to it
		currentWeapon=Instantiate(weaponToEquip,weaponPosition) as Weapon;
		//TODO: other things when equiping a weapon
	}

	public override void Move(Vector2 moveVector){
		//anim.SetFloat ("horizontal", controllerposition.x);
		//anim.SetFloat ("vertical", controllerposition.y);

		anim.SetFloat ("horizontal", moveVector.x);
		anim.SetFloat ("vertical", moveVector.y);
	}

	public override void RotateTowards(Vector3 target){
		//find the vector to target
		Vector3 vectorToTarget=target-tf.position;
		//find the rotation that would dawn that vector
		Quaternion targetRotation=Quaternion.LookRotation(vectorToTarget);
		//change 

		tf.rotation= Quaternion.RotateTowards(tf.rotation,targetRotation,turnspeed);
	}

	void OnAnimatorIK(){
		//set IK right hand
		if (currentWeapon != null) {
			anim.SetIKPosition (AvatarIKGoal.RightHand, currentWeapon.RHpoint);
			anim.SetIKHintPositionWeight (AvatarIKGoal.RightHand, 1.0f);
			//anim.SetIKRotation(AvatarIKGoal.RightHand)
			anim.SetIKPosition (AvatarIKGoal.LeftHand, currentWeapon.LHpoint);
			anim.SetIKHintPositionWeight (AvatarIKGoal.LeftHand, 1.0f);
			//anim.SetIKPosition (AvatarIKGoal.LeftHand, currentWeapon.LHpoint);
		} else {
			//
			anim.SetIKHintPositionWeight (AvatarIKGoal.RightHand, 0.0f);

		}
	}
}
