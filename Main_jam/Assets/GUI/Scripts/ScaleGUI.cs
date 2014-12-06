using UnityEngine;
using System.Collections;
[ExecuteInEditMode]
[RequireComponent (typeof(GUITexture))]

public class ScaleGUI : MonoBehaviour {



	public float HeightFactor = 0f;
	public float widthtRatio = 0f;
	public float ProportionalY = 0f;
	public float ProportionalX = 0f;
	
	Rect AuxRect;

	// Use this for initialization
	void Start () {

		guiTexture.transform.localScale = Vector3.zero;
		guiTexture.transform.position = Vector3.zero;
		guiTexture.transform.rotation = Quaternion.identity;
		AuxRect.height = Screen.height*HeightFactor;
		AuxRect.width = AuxRect.height*widthtRatio;
		AuxRect.x = Screen.width*ProportionalX-(AuxRect.width)/2;
		AuxRect.y = Screen.height*ProportionalY-(AuxRect.height)/2;
		guiTexture.pixelInset = AuxRect;

	}

#if UNITY_EDITOR
	// Update is called once per frame
	void Update ()
	{

		AuxRect.height = Screen.height*HeightFactor;
		AuxRect.width = AuxRect.height*widthtRatio;
		AuxRect.x = Screen.width*ProportionalX-(AuxRect.width)/2;
		AuxRect.y = Screen.height*ProportionalY-(AuxRect.height)/2;
		guiTexture.pixelInset = AuxRect;
	
	}
#endif
}
