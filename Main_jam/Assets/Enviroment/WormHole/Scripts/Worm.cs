using UnityEngine;
using System.Collections;

public class Worm : MonoBehaviour {

	public Transform[] LinkedWorms = new Transform[5];
	public GameObject WormEffect;
	GameObject NewWormEffect;

	// Use this for initialization
	void Start () {
	
	}
	
	void OnTriggerEnter(Collider Other)
	{
		if (Other.tag == "Player")
		{
			NewWormEffect = Instantiate(WormEffect) as GameObject;
			NewWormEffect.transform.position = transform.position;
		}
	}

	public Vector3 teletransport(int pos){
		return LinkedWorms[pos].position;
	}
}
