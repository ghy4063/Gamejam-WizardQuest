using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseTheplayer : MonoBehaviour {
	[RequireComponent(NavMeshAgent)]
	public NavMeshAgent Agent;
	public Transform Player;
	public float updateDelay;
	float timer;
	// Use this for initialization
	void Start () {
		Agent = GetComponent<NavMeshAgent> ();
		Player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform> ();
		timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if(timer>updateDelay){
		Vector3 targetPosition = new Vector3 (Player.position.x, 0, Player.position.z);
		Agent.SetDestination = targetPosition;
			timer = 0;
		}
	}
}
