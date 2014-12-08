using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {

	bool player1_Arrived = false;
	bool player2_Arrived = false;
	bool EndLevel = false;
	float timer = 0f;
	public Timer_01 player1_timer;
	public Timer_02 player2_timer;
	public GUITexture texturePlayer1, texturePlayer2;
	public Texture[] textures = new Texture[3];
	public float timeEnd = 0f;
	public int nextLevel = 0;
	public float maxTimer = 0f;
	public GUIText globalTimer1, globalTimer2;
	public bool pause = true;
	private float TimerPlayer01;
	private float TimerPlayer02;

	[Header("Sounds parameters: ")]
	public AudioClip EndSound;


	
	// Use this for initialization
	void Start () {
		timer = maxTimer;
		texturePlayer1.texture = null;
		texturePlayer2.texture = null;
	}

	public void playerArrive_01(){
		player1_Arrived = true;
		TimerPlayer01 = player1_timer.timer;
		if(player2_Arrived && EndLevel == false)
			CheckWinner();
	}

	public void playerArrive_02(){
		player2_Arrived = true;
		TimerPlayer02 = player2_timer.timer;
		if(player1_Arrived && EndLevel == false)
			CheckWinner();
	}

	void CheckWinner(){

		EndLevel = true;
		audio.PlayOneShot(EndSound);
		if(player1_Arrived  && player2_Arrived){
			if(TimerPlayer01 < TimerPlayer02){
				texturePlayer1.texture = textures[0];
				texturePlayer2.texture = textures[1];
				StartCoroutine(endLevel(timeEnd));
			}
			else{
				texturePlayer1.texture = textures[1];
				texturePlayer2.texture = textures[0];
				StartCoroutine(endLevel(timeEnd));
			}
		}
		else{
			if(!player1_Arrived && !player2_Arrived){
				texturePlayer1.texture = textures[2];
				texturePlayer2.texture = textures[2];
				StartCoroutine(endLevel(timeEnd));
			}
			else{
				if(!player1_Arrived && player2_Arrived){
					texturePlayer1.texture = textures[1];
					texturePlayer2.texture = textures[0];
					StartCoroutine(endLevel(timeEnd));
				}
				else{
					texturePlayer1.texture = textures[0];
					texturePlayer2.texture = textures[1];
					StartCoroutine(endLevel(timeEnd));
				}
			}
		}
	}

	IEnumerator endLevel(float timeEndlevel){
		yield return new WaitForSeconds(timeEndlevel);
		Application.LoadLevel(nextLevel);
	}

	// Update is called once per frame
	void FixedUpdate () {
		if(!pause){
			if(timer>0)
				timer -= Time.deltaTime;
			if(timer <0)
				timer =0 ;
			globalTimer1.text = timer.ToString();
			globalTimer2.text = timer.ToString();
			if(timer <= 0 && EndLevel == false)
				CheckWinner();
		}

	}

}
