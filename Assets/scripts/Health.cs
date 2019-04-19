using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
	public float health;
	public float maxHealth;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void TakeDamage(float amountOfDamage,pawn source,pawn instigator)
	{
		health -= amountOfDamage;
		if (health < 0) {
			Die ();
		}
		if (health > maxHealth) {
			health = maxHealth;
		}
	}
	public void Die(){
		//TODO Die
	}
}
