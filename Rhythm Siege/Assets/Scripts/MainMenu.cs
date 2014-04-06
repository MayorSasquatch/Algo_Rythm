using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public Texture backTex;
	public GUISkin skin;

	private Rect windowRect = new Rect(Screen.width/2-200, Screen.height/2-200, 400, 400);
	private bool toggle = false;

	void OnGUI () {

		GUI.skin = skin;

		GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height), backTex, ScaleMode.StretchToFill, true, 0);

		GUI.BeginGroup(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 150, 200, 300));
		if(GUI.Button (new Rect (0,0,200,80), "Start")) {
			print ("You clicked the button!");
		}

		toggle = GUI.Toggle (new Rect (0,100,200,80), toggle, "Options", "Button");

		if(GUI.Button (new Rect (0,200,200,80), "Credits")) {
			print ("You clicked the button!");
		}
		GUI.EndGroup();

		if(toggle) {
			windowRect = GUI.ModalWindow(0, windowRect, windowFunc, "Options");
		}
	}

	void windowFunc(int windowID){

		if(GUI.Button(new Rect(130,320,140,60), "Close")) toggle = false;
	}

}
