﻿using UnityEngine;
using System.Collections;

public class Model_Rotation01 : MonoBehaviour {

	public float MaxRotation = 0f;
	public float MinRotation = 0f;
	public float RotationSpeed = 0f;
	public float RelativeRotation = 0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetAxis("Horizontal1")>0)
		{
			if(RelativeRotation < MaxRotation)
			{
				transform.Rotate(-RotationSpeed*Time.deltaTime,0,0);
				RelativeRotation = RelativeRotation + RotationSpeed*Time.deltaTime;
			}
		}
		else if (Input.GetAxis("Horizontal1")<0)
		{
			if(RelativeRotation > MinRotation)
			{
				transform.Rotate(RotationSpeed*Time.deltaTime,0,0);
				RelativeRotation = RelativeRotation - RotationSpeed*Time.deltaTime;
			}
		}
		else
		{
			if (RelativeRotation>0)
			{
				transform.Rotate(RotationSpeed*Time.deltaTime,0,0);
				RelativeRotation = RelativeRotation - RotationSpeed*Time.deltaTime;
			}
			if (RelativeRotation<0)
			{
				transform.Rotate(-RotationSpeed*Time.deltaTime,0,0);
				RelativeRotation = RelativeRotation + RotationSpeed*Time.deltaTime;
			}
		}
	}
}
