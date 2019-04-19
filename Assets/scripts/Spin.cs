using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour {
	private Transform tf;
	public float rotationSpeed;
	// Use this for initialization
	void Start () {
		tf = GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		tf.Rotate (0,rotationSpeed,0);
	}
}
