using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour {
	
	[Header("Explosion Parameters: ")]
	public GameObject ExplosionPrefab;
	public float DelayOfExplosion = 0f;
	public Vector3 RelativePositionExplosion;
	public float GizmoRadioExplosion = 0.3f;
	GameObject NewExplosionPrefab;
	
	Vector3 AuxVector3 = new Vector3(0,0,0);
	
	
	void OnCollisionEnter(Collision CurrentCollision)
	{
		
		if (CurrentCollision.collider.tag == "Bullet")
		{
			Explosion();
		}
		
		if (CurrentCollision.collider.tag == "Player")
		{
			Explosion();
		}
		
		if (CurrentCollision.collider.tag == "Planet")
		{
			Explosion();
		}
		
	}
	
	void OnDrawGizmosSelected()
	{
		AuxVector3.x = transform.position.x +RelativePositionExplosion.x;
		AuxVector3.y = transform.position.y +RelativePositionExplosion.y;
		AuxVector3.z = transform.position.z +RelativePositionExplosion.z;
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(AuxVector3,GizmoRadioExplosion);
	}
	
	void Explosion ()
	{
		
		AuxVector3.x = transform.position.x + RelativePositionExplosion.x;
		AuxVector3.y = transform.position.y + RelativePositionExplosion.y;
		AuxVector3.z = transform.position.z + RelativePositionExplosion.z;
		NewExplosionPrefab = Instantiate(ExplosionPrefab) as GameObject;
		NewExplosionPrefab.transform.position = AuxVector3;
		StartCoroutine(TimeAndDestroy(DelayOfExplosion));
		
	}
	
	IEnumerator TimeAndDestroy (float time)
	{
		yield return new WaitForSeconds(time);
		Destroy (gameObject);
	}
	
	
}
