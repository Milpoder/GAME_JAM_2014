using UnityEngine;
using System.Collections;

public class StartCount : MonoBehaviour {

	[Header("Player Parameters: ")]
	public PlayerController_01 Player1;
	public PlayerController_02 Player2;
	public  Goal globalTimer;

	[Header("Count Parameters: ")]
	public GameObject Start_Object_1;
	public GameObject Start_Object_2;
	public AnimationClip[] Start_Clips = new AnimationClip[3];
	public Texture[] Num_Textures = new Texture[6];
	public float HeightFactor = 0f;
	public float widthtRatio = 0f;
	public float ProportionalY = 0f;
	public float ProportionalX = 0f;

	[Header("Sound Parameters: ")]
	public AudioSource AudioSourceCount;
	public AudioClip AudioCount;

	Rect AuxRect;

	// Use this for initialization
	void Start () {

		Start_Object_1.animation.clip = Start_Clips[0];
		Start_Object_1.animation.Play();

		Start_Object_2.animation.clip = Start_Clips[0];
		Start_Object_2.animation.Play();

		guiTexture.transform.localScale = Vector3.zero;
		guiTexture.transform.rotation = Quaternion.identity;

		Player1.Pause = true;
		Player2.Pause = true;
		globalTimer.pause = true;

		StartCoroutine(Count());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator Count()
	{
		AudioSourceCount.PlayOneShot(AudioCount);
		guiTexture.texture = Num_Textures[0];
		AutoScale();
		yield return new WaitForSeconds(1f);

		AudioSourceCount.PlayOneShot(AudioCount);
		guiTexture.texture = Num_Textures[1];
		AutoScale();
		yield return new WaitForSeconds(1f);

		AudioSourceCount.PlayOneShot(AudioCount);
		guiTexture.texture = Num_Textures[2];
		AutoScale();
		yield return new WaitForSeconds(1f);

		AudioSourceCount.PlayOneShot(AudioCount);
		guiTexture.texture = Num_Textures[3];
		AutoScale();
		yield return new WaitForSeconds(1f);

		AudioSourceCount.PlayOneShot(AudioCount);
		guiTexture.texture = Num_Textures[4];
		AutoScale();
		yield return new WaitForSeconds(1f);

		AudioSourceCount.PlayOneShot(AudioCount);
		guiTexture.texture = Num_Textures[5];
		AutoScale();
		Start_Object_1.animation.clip = Start_Clips[1];
		Start_Object_1.animation.Play();
		Start_Object_2.animation.clip = Start_Clips[1];
		Start_Object_2.animation.Play();
		yield return new WaitForSeconds(1f);

		guiTexture.texture = null;
		Player1.Pause = false;
		Player2.Pause = false;
		globalTimer.pause = false;

		Start_Object_1.animation.clip = Start_Clips[2];
		Start_Object_1.animation.Play();
		Start_Object_2.animation.clip = Start_Clips[2];
		Start_Object_2.animation.Play();

	}

	void AutoScale ()
	{

		AuxRect.height = Screen.height*HeightFactor;
		AuxRect.width = AuxRect.height*widthtRatio;
		AuxRect.x = Screen.width*ProportionalX-(AuxRect.width)/2;
		AuxRect.y = Screen.height*ProportionalY-(AuxRect.height)/2;
		guiTexture.pixelInset = AuxRect;

	}
}
