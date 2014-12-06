using UnityEngine;
using System.Collections;

public class Autodestruction : MonoBehaviour {

	public float LifeTime = 1f;

	// Use this for initialization
	void Start () {
		StartCoroutine(DelayAndDestroy(LifeTime));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator DelayAndDestroy(float DelayTime)
	{
		yield return new WaitForSeconds(DelayTime);
		Destroy(gameObject);
	}
}
