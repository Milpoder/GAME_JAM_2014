using UnityEngine;
using System.Collections;

public class ConstantMovement : MonoBehaviour {

	public Vector3 Velocity;
	public Vector3 Rotation;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.Translate(Velocity.x*Time.deltaTime,Velocity.y*Time.deltaTime,Velocity.z*Time.deltaTime);
		transform.Rotate(Rotation.x*Time.deltaTime,Rotation.y*Time.deltaTime,Rotation.z*Time.deltaTime);
	}
}
