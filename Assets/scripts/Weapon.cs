using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
	public Transform LHpoint;
	public Transform RHpoint;
	public GameObject bulletPrefab;
	public GameObject gameParticle;
	public Transform firePosition;
	public float bulletForce;
	public float bulletLifespan;
	public float damageDone;
	public float particleLifespan;
	[Header("Spread")]
	public float spread;
	public float minSpread;
	public float maxSpread;
	public float deltaSpread;

	[Tooltip]
	public float fireDistance;
	// Use this for initialization
	void Start () {
		spread = minSpread;
	}
	
	// Update is called once per frame
	void Update () {
		//reduce spread every frame
		spread -= deltaSpread*Time.deltaTime;
		spread = Mathf.Clamp (spread, minSpread, maxSpread);
	}
	/// <summary>
	/// occurs when player picks up weapon
	/// </summary>
	public void OnEquip()
	{
		//instantiate weapon
	}

	/// <summary>
	/// when you shoot the weapon
	/// </summary>

	public void Fire()
	{
		//find the point "spread "units in front of the gun fire position
		Vector3 newPoint = firePosition.position+(firePosition.forward*fireDistance);
		//find random point within the sphere "spread"units in size
		Vector3 randomPoint= Random.insideUnitSphere;
		randomPoint = randomPoint * spread;
		//move the point over our "in front of us" point
		randomPoint=newPoint+randomPoint;

		//generate our bullet
		GameObject bullet = Instantiate (bulletPrefab, firePosition.position, firePosition.rotation)as GameObject;

		//point our bullet towards our random point
		bullet.transform.LookAt(randomPoint);
		//puch bullet forward
		Rigidbody bulletRB = bullet.GetComponent<Rigidbody> ();
		bulletRB.AddForce (bullet.transform.forward = bulletForce);
		//bullet life span
		Destroy (bullet, bulletLifespan);
		//add to spread
		spread+=deltaSpread;

	}

	public void altFire(){
		Ray fireRay;
		fireRay.origin = firePosition.position;
		fireRay.direction = firePosition.forward;

		RaycastHit hitData;
		if (Physics.Raycast (fireRay, out hitData, fireDistance)) {
			GameObject hitObject = hitData.collider.gameObject;
			Health hitObjectHealth = hitObject.GetComponent<Health> ();
			if (hitObjectHealth != null) {
				hitObjectHealth.TakeDamage (damageDone);
			}
			GameObject particles = Instantiate (gameParticle, hitData.point, Quaternion.identity)as GameObject;
			Destroy (particles, particleLifespan);
		}

	}
}
