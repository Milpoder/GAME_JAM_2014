using UnityEngine;
using System.Collections;

public class VelocityGUI : MonoBehaviour {
	
	public Texture[] GUIVelocityTextures = new Texture[13];
	public float SizeIntervalsToChange = 5f;
	public float PerfectSpeed = 25f;
	public PlayerController_01 Player1;
	public PlayerController_02 Player2;
	public GUITexture TexturePlayer1;
	public GUITexture TexturePlayer2;

	int AuxIndex;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		AuxIndex = (int)((Player1.moveSpeed - PerfectSpeed)/5 - (Player1.moveSpeed - PerfectSpeed)%5) + 6;
		if (AuxIndex<0) AuxIndex = 0;
		if (AuxIndex>13) AuxIndex = 13;
		TexturePlayer1.texture = GUIVelocityTextures[AuxIndex];

		AuxIndex = (int)((Player2.moveSpeed - PerfectSpeed)/5 - (Player2.moveSpeed - PerfectSpeed)%5) + 6;
		if (AuxIndex<0) AuxIndex = 0;
		if (AuxIndex>13) AuxIndex = 13;
		TexturePlayer2.texture = GUIVelocityTextures[AuxIndex];

	}
}
