using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	public static int curency;
	public int menu;
	public GameObject[] buttons;

	void OnMouseDown(){

		for(int i = 0; i < buttons.Length; i++){
			Instantiate(buttons[i], buttons[i].transform.position, Quaternion.identity);
		}

		Destroy(gameObject);
	}

	void Start(){
		if (!PlayerPrefs.HasKey ("Currency")) {
						PlayerPrefs.SetInt ("Currency", 0);		
				} else {
			curency = PlayerPrefs.GetInt("Currency");
				}
	}
}
