using UnityEngine;
using System.Collections;

public class munitions : MonoBehaviour {

	public GameObject EffectPrefab;
	public float DelayTime = 0f;
	GameObject NewEffectPrefab;

	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			StartCoroutine(DestroyBox(DelayTime));
		}
	}

	IEnumerator DestroyBox (float NewDelayTime)
	{
		NewEffectPrefab = Instantiate (EffectPrefab) as GameObject;
		NewEffectPrefab.transform.position = transform.position;
		yield return new WaitForSeconds(NewDelayTime);
		Destroy(gameObject);
	}
}
