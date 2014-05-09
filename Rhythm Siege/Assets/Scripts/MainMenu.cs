using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public int menu;
	public GameObject[] buttons;

	void OnMouseDown(){

		for(int i = 0; i < buttons.Length; i++){
			Instantiate(buttons[i], buttons[i].transform.position, Quaternion.identity);
		}

		Destroy(gameObject);
	}

}
