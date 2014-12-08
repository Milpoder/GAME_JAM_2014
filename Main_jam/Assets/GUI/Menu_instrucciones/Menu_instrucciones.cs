using UnityEngine;
using System.Collections;

public class Menu_instrucciones : MonoBehaviour {

	public ButtonController[] buttonControllers = new ButtonController[2];
	public float Cooldown = 0.5f;
	public int selected = 0;
	bool key = true;
	
	// Use this for initialization
	void Start () {
		buttonControllers[0].Normal();
		buttonControllers[1].Normal();
		buttonControllers[selected].Selection();
	}
	IEnumerator Resetkey (float TimeReset)
	{
		yield return new WaitForSeconds(TimeReset);
		key = true;
	}
	// Update is called once per frame
	void Update () {
		
		if ((Input.GetKey(KeyCode.UpArrow)||Input.GetAxis("Vertical1")>0||Input.GetAxis("Vertical2")>0) && key==true)
		{
			key = false;
			
			buttonControllers[selected].Normal();
			
			selected --;
			if (selected<0) selected = 1;
			
			buttonControllers[selected].Selection();
			StartCoroutine(Resetkey(Cooldown));
		}
		
		if ((Input.GetKey(KeyCode.DownArrow)||Input.GetAxis("Vertical1")<0||Input.GetAxis("Vertical2")<0) && key==true)
		{
			key = false;
			
			buttonControllers[selected].Normal();
			
			selected ++;
			if (selected>1) selected = 0;
			
			
			buttonControllers[selected].Selection();
			StartCoroutine(Resetkey(Cooldown));
			
		}
		
		if (Input.GetKeyDown(KeyCode.KeypadEnter)||Input.GetKeyDown(KeyCode.Joystick1Button0)||Input.GetKeyDown(KeyCode.Joystick2Button0))
		{
			
			buttonControllers[selected].Push();
			buttonControllers[selected].ActivateButton();
		}
		
	}
}
