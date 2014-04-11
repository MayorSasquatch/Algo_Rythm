using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public int menu;

	void OnMouseDown(){
		Application.LoadLevel(menu);
	}

}
