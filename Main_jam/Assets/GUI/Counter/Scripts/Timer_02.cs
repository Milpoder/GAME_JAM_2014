using UnityEngine;
using System.Collections;

public class Timer_02 : MonoBehaviour {

	public PlayerController_02 Player02;
	public float timer = 0f;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(!Player02.Pause)
			timer += Time.deltaTime + incrementDeltaTime (Player02.moveSpeed, Player02.getGravity(), Time.deltaTime);
		guiText.text = "TIMER: " + timer.ToString();
	}
	
	float incrementDeltaTime(float v, float g, float delta){
		return v * (g+1) * delta;
	}

}
