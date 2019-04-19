using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {
	public pawn pawn;

	public Plane groundPlane;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (pawn != null) {
			//get position of the controller
			Vector3 controllerposition = new Vector3 (Input.GetAxis ("Horizontal"),0.0f, Input.GetAxis ("Vertical"));
			//limit the diagonals
			controllerposition = Vector3.ClampMagnitude (controllerposition, 1.0f);
			//convert so forward on controller is forward in world (based on rotation of the player)
			controllerposition=pawn.GetComponent<Transform> ().InverseTransformDirection (controllerposition);
			//telling pawn to move in that direction
			pawn.Move (new Vector2(controllerposition.x, controllerposition.z));
		}
		if (Input.GetKeyDown (KeyCode.Q)) {
			pawn.Die ();


		}
		RotatetoMouse ();
	}

	public void RotatetoMouse(){
		//define ground Plane
		groundPlane=new Plane(Vector3.up,pawn.tf.position);
		//raycast through the mouse position to the ground plane
		float distanceToPlane;
		Ray mouseRay=Camera.main.ScreenPointToRay(Input.mousePosition);
		groundPlane.Raycast (mouseRay, out distanceToPlane);
		//find a point on the plane
		Vector3 PointonPlane=mouseRay.GetPoint(distanceToPlane);
		//rotate towards that point

		//temp:change this to use"rotate towards"
		pawn.tf.LookAt(PointonPlane);
	}
}
