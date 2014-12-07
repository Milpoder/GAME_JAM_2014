﻿using UnityEngine;
using System.Collections;

public class PlayerController_01 : MonoBehaviour {

	[Header("Movement parameters: ")]
	public float moveSpeed = 0f;
	public float rotationSpeed = 0f;
	public bool Pause = true;

	[Header("Fire parameters: ")]
	public GameObject BulletPrefab;
	public float FireCooldown = 0f;
	public int NumBullets = 5;
	public Transform RelativePositionFire;
	public Transform Parent;

	[Header("Collision parameters: ")]
	public float AceleratorVelIncrement=5f;
	private bool block_axis = false; 
	public float time_block = 0f;
	public GameObject stunPrefab;
	GameObject NewStunPrefab;
	public Transform PositionStun;
	

	GameObject NewBulletPrefab;
	bool FireKey = true;
	Vector3 AuxVector3;
	

	// Use this for initialization
	void Start () {
		
	}

	void Update()
	{
		// Fire Controller ------------------------------------------------------------------------------------------------------------
		if (!Pause)
		{
			if (Input.GetKeyDown(KeyCode.Space)||Input.GetKeyDown(KeyCode.Joystick1Button0))
			{
				if (FireKey && NumBullets > 0) Fire();
			}
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {

			if (!Pause && !block_axis) {
				if (Input.GetKey (KeyCode.A)) {
					transform.Rotate (0, -rotationSpeed * Time.deltaTime, 0);
				}
				if (Input.GetKey (KeyCode.D)) {
					transform.Rotate (0, rotationSpeed * Time.deltaTime, 0);
				}

				transform.Translate (0, 0, moveSpeed * Time.deltaTime);
				transform.Rotate (0, rotationSpeed * Input.GetAxis ("Horizontal1") * Time.deltaTime, 0);
			}
			else if(block_axis) transform.Translate (0, 0, moveSpeed * Time.deltaTime);
	}

	IEnumerator resetBlock(float time_actu){

		yield return new WaitForSeconds(time_actu);
		block_axis = false;
	}


	void OnCollisionEnter(Collision currentCollision){

		if(currentCollision.collider.tag == "Bullet"){
			block_axis=true;
			NewStunPrefab = Instantiate(stunPrefab) as GameObject; 
			NewStunPrefab.transform.parent = transform;
			NewStunPrefab.transform.position = PositionStun.position;
			StartCoroutine(resetBlock(time_block));
		}

	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Acelerator")
		{
			if (other.GetComponentInParent<Acelerator>().IsActive) moveSpeed += AceleratorVelIncrement;
		}
		if (other.tag == "Box")
		{
			CollisionWithBox();
		}
	}


	void Fire ()
	{
		NumBullets --;
		FireKey = false;
		StartCoroutine(ResetFireCooldown(FireCooldown));

		NewBulletPrefab = Instantiate(BulletPrefab) as GameObject;
		NewBulletPrefab.transform.parent = transform;
		NewBulletPrefab.transform.position = RelativePositionFire.position;
		NewBulletPrefab.transform.rotation = Parent.rotation;
		NewBulletPrefab.transform.parent = null;

		
	}

	void CollisionWithBox ()
	{
		AddBullet(5);
	}

	void AddBullet(int Increment)
	{
		NumBullets += Increment;
	}

	IEnumerator ResetFireCooldown (float CooldownTime)
	{
		yield return new WaitForSeconds(CooldownTime);
		FireKey = true;
	}
}
