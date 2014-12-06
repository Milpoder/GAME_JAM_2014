using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	public int Damage = 0;
	public float Speed = 0f;
	public float MaxTimeLife = 0f;


	// Use this for initialization
	void Start () {
		StartCoroutine(InitAutodestruction(MaxTimeLife));
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.Translate(0,0,Speed*Time.deltaTime);
	}

	void OnCollisionEnter(Collision CurrentCollision)
	{
		BulletCollision(CurrentCollision);
	}

	IEnumerator InitAutodestruction (float EndTime)
	{
		yield return new WaitForSeconds(EndTime);
		Destroy(gameObject);
	}

	void BulletCollision(Collision other)
	{
		Destroy(gameObject);
	}
}
