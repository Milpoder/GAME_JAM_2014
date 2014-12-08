using UnityEngine;
using System.Collections;

public class ButtonController : MonoBehaviour {

	public Texture[] ButtonTextures = new Texture[3];
	public int levelToLoad;
	public float DelayTime = 0f;

	[Header("Sounds: ")]
	public AudioClip SelectSound;
	public AudioClip ActivateSound;

	// Use this for initialization

	void Start()
	{

	}

	public void ActivateButton()
	{
		StartCoroutine(DelayAndActivate(DelayTime));
	}

	public void Selection()
	{
		audio.PlayOneShot(SelectSound);
		guiTexture.texture = ButtonTextures[1];
	}

	public void Push()
	{
		audio.PlayOneShot(ActivateSound);
		guiTexture.texture = ButtonTextures[2];
	}

	public void Normal()
	{
		guiTexture.texture = ButtonTextures[0];
	}
	
	IEnumerator DelayAndActivate(float DelayTime)
	{
		yield return new WaitForSeconds(DelayTime);
		Application.LoadLevel(levelToLoad);
	}
}
