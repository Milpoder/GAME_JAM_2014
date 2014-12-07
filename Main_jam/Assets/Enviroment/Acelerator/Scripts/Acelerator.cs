using UnityEngine;
using System.Collections;

public class Acelerator : MonoBehaviour {

	public GameObject VisualEffectActive;
	public float DelayDestroyActive = 0f;
	public float DelayRestartActive = 0f;
	GameObject NewVisualEffectActive;
	public GameObject VisualEffectExplosion;
	GameObject NewVisualEffectExplosion;

	public bool IsActive = true;

	// Use this for initialization
	void Start () {

		NewVisualEffectActive = Instantiate(VisualEffectActive) as GameObject;
		NewVisualEffectActive.transform.position = transform.position;

	}

	void OnTriggerEnter(Collider other)
	{

		if (other.tag == "Player")
		{
			if (IsActive) ExplosionEffect();
		}
	}

	void ExplosionEffect()
	{
		NewVisualEffectExplosion = Instantiate(VisualEffectExplosion) as GameObject;
		NewVisualEffectExplosion.transform.position = transform.position;
		IsActive = false;
		StartCoroutine(DestroyActiveEffect(DelayDestroyActive,DelayRestartActive));

	}

	IEnumerator DestroyActiveEffect(float TimeEndActive, float TimeRestart)
	{
		yield return new WaitForSeconds(TimeEndActive);
		Destroy(NewVisualEffectActive);
		yield return new WaitForSeconds(TimeRestart);
		IsActive = true;
		NewVisualEffectActive = Instantiate(VisualEffectActive) as GameObject;
		NewVisualEffectActive.transform.position = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
