using UnityEngine;
using System.Collections;

public class VelocityGUI : MonoBehaviour {
	
	public Texture[] GUIVelocityTextures = new Texture[13];
	public float SizeIntervalsToChange = 5f;
	public float PerfectSpeed1 = 25f;
	public float PerfectSpeed2 = 25f;
	public PlayerController_01 Player1;
	public PlayerController_02 Player2;
	public GUITexture TexturePlayer1;
	public GUITexture TexturePlayer2;
	public Timer_01 LocalTimer1;
	public Timer_02 LocalTimer2;

	int AuxIndex;

	// Use this for initialization
	void Start () {
		PerfectSpeed1 = Mathf.Sqrt((1+LocalTimer1.B)/LocalTimer1.A);
		PerfectSpeed2 = Mathf.Sqrt((1+LocalTimer2.B)/LocalTimer2.A);
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		AuxIndex = (int)((Player1.moveSpeed - PerfectSpeed1)/5 - (Player1.moveSpeed - PerfectSpeed1)%5) + 6;
		if (AuxIndex<0) AuxIndex = 0;
		if (AuxIndex>12) AuxIndex = 12;
		TexturePlayer1.texture = GUIVelocityTextures[AuxIndex];

		AuxIndex = (int)((Player2.moveSpeed - PerfectSpeed2)/5 - (Player2.moveSpeed - PerfectSpeed2)%5) + 6;
		if (AuxIndex<0) AuxIndex = 0;
		if (AuxIndex>12) AuxIndex = 12;
		TexturePlayer2.texture = GUIVelocityTextures[AuxIndex];

	}
}
