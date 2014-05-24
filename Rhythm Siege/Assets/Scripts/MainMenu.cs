using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	public static int curency;
	public static bool boss;
	public static bool tutorial;
	public int menu;
	public GameObject[] buttons;



	void Start(){
		boss = false;
		tutorial  = true;
		if (!PlayerPrefs.HasKey ("Currency")) {
						PlayerPrefs.SetInt ("Currency", 0);		
				} else {
			curency = PlayerPrefs.GetInt("Currency");
				}
	}
}
