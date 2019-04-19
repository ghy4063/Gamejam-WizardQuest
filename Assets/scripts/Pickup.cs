using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pickup : MonoBehaviour {

	[Tooltip("Seconds that the pickup exists. Negative value is infinite.")]
	public float lifespan;
	// Use this for initialization
	public virtual void Start () {
		if (lifespan > 0) { 
			Destroy (gameObject, lifespan);
		}
	}
	
	// Update is called once per frame
	public virtual void Update () {
		
	}

	public virtual void OnPickup(GameObject target){
		//destroy itself
		Destroy(gameObject);
	}


	public void OnTriggerEnter(Collider other){
		
	}
}
