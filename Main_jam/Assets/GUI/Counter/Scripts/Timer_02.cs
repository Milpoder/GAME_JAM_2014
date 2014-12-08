using UnityEngine;
using System.Collections;

public class Timer_02 : MonoBehaviour {

	public PlayerController_02 Player02;
	public float timer = 0f;
	public float A = 1f, B=1f;
	
	// Use this for initialization
	void Start () {
		timer = 0f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(!Player02.Pause)
			timer += Time.deltaTime + incrementDeltaTime (Player02.moveSpeed, Player02.getGravity(), Time.deltaTime);
		guiText.text = "TIMER: " + timer.ToString();
	}
	
	float incrementDeltaTime(float v, float g, float delta){
		return ((v*v*A) + (g+1)*B)  * delta;
	}

}
