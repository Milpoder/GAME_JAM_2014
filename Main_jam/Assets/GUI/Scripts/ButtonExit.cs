using UnityEngine;
using System.Collections;

public class ButtonExit : MonoBehaviour {

	public Texture[] ButtonTextures = new Texture[3];
	public float DelayTime = 0f;
	
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
		guiTexture.texture = ButtonTextures[1];
	}
	
	public void Push()
	{
		guiTexture.texture = ButtonTextures[2];
	}
	
	public void Normal()
	{
		guiTexture.texture = ButtonTextures[0];
	}
	
	IEnumerator DelayAndActivate(float DelayTime)
	{
		yield return new WaitForSeconds(DelayTime);
		Application.Quit();
	}
}
