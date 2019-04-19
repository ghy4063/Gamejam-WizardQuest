using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdollcontroller : MonoBehaviour {
	[Header("on when controlled")]
	public Animator anim;
	public Collider mainCollider;
	public Rigidbody mainRigidbody;
	public AIController aicontroller;

	public List<Collider> ragdollColliders;
	public List<Rigidbody> ragdollRigidbodies;
	// Use this for initialization
	void Start () {
		anim.GetComponent<Animator> ();
		mainCollider.GetComponent<Collider> ();
		mainRigidbody.GetComponent<Rigidbody> ();
		aicontroller.GetComponent<AIController> ();
		Collider[] tempcol = GetComponentInChildren<Collider> ();
		ragdollColliders =new List<Collider> (tempcol);
		ragdollColliders.Remove (mainCollider);
		Rigidbody[] tempRb = GetComponentInChildren<Rigidbody> ();
		ragdollRigidbodies = new List<Rigidbody> (tempRb);
		ragdollRigidbodies.Remove (mainRigidbody);
		RagdollOff ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void RagdollOn(){
		foreach (Collider col in ragdollColliders) {
			col.enabled = true;
		}
		foreach (Rigidbody rb in ragdollRigidbodies) {
			rb.isKinematic = false;
		}
		mainCollider.enabled = false;
		mainRigidbody.isKinematic = true;
		anim.enabled = false;
		aicontroller.enabled = false;

	}

	public void RagdollOff(){
		foreach (Collider col in ragdollColliders) {
			col.enabled = false;
		}
		foreach (Rigidbody rb in ragdollRigidbodies) {
			rb.isKinematic = true;
		}
		mainCollider.enabled = true;
		mainRigidbody.isKinematic = false;
		anim.enabled = true;
		aicontroller.enabled = true;
	}
}
