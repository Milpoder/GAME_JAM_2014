using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {

	bool player1_Arrived = false;
	bool player2_Arrived = false;
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

	
	// Use this for initialization
	void Start () {
		timer = maxTimer;
		texturePlayer1.texture = null;
		texturePlayer2.texture = null;
	}

	public void playerArrive_01(){
		player1_Arrived = true;
		if(player2_Arrived)
			CheckWinner();
	}

	public void playerArrive_02(){
		player2_Arrived = true;
		if(player1_Arrived)
			CheckWinner();
	}

	void CheckWinner(){
		if(player1_Arrived  && player2_Arrived){
			if(player1_timer.timer < player2_timer.timer){
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
			if(timer <= 0)
				CheckWinner();
		}

	}
}
