using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pawn : MonoBehaviour {
	public Transform tf;
	void Awake () {
		tf.GetComponent<Transform> ();
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public virtual void Move (Vector2 moveVector)
	{
	}
	public virtual void Die (){
	}
	public virtual void RotateTowards (Vector3 target){
	}
}
