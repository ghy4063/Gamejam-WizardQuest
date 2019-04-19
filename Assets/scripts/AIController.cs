using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AIController : MonoBehaviour {
	private NavMeshAgent agent;
	public pawn target;
	private Animator anim;
	//private Transform tf;
	private pawn pawn;
	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
		pawn = GetComponent<pawn> ();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		SeekPawn (target);

		if(Input.GetKeyDown(KeyCode.Space)){
			agent.isStopped = !agent.isStopped;
			}
	}

	void SeekPawn(pawn target){
		agent.SetDestination (target.tf.position);
		Vector3 desiredVelocity = agent.desiredVelocity;
		//desiredVelocity=Vector3.ClampMagnitude
		desiredVelocity = pawn.tf.InverseTransformDirection(desiredVelocity);
		pawn.Move (new Vector2 (desiredVelocity.x, desiredVelocity.z));
		//desiredVelocity = tf.InverseTransformDirection (desiredVelocity);
		anim.SetFloat ("Horizontal", desiredVelocity.x);
		anim.SetFloat ("Vertical", desiredVelocity.z);
	}

	public void OnAnimatorMove(){
		agent.velocity = anim.velocity;
	}
}
