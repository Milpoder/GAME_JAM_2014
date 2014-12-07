using UnityEngine;
using System.Collections;

public class Timer_01 : MonoBehaviour {

	public PlayerController_01 Player01;
	public float timer = 0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(!Player01.Pause)
			timer += Time.deltaTime + incrementDeltaTime (Player01.moveSpeed, Player01.getGravity(), Time.deltaTime);
		guiText.text = "TIMER: " + timer.ToString();
	}

	float incrementDeltaTime(float v, float g, float delta){
		return v * (g+1)  * delta;
	}

}
