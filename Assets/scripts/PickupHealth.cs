using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupHealth : Pickup {
	public float healAmount;
	// Use this for initialization
	public override void Start () {
		//Run the parent version
		base.Start();
	}
	
	// Update is called once per frame
	public override void Update () {
		base.Update ();
	}


	//runs when pickup
	public override void OnPickup(GameObject target){
		Health tempHealth = target.GetComponent<Health> ();
		if (tempHealth != null) {
			//tempHealth.TakeDamage (-healAmount);
		}

		pawn tempPawn = target.GetComponent<pawn> ();
			if(tempPawn!=null){
		
		//run the parent version
			base.OnPickup (target);
			}
		}
	
}
