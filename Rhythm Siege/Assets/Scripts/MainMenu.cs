using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	public static int curency;
	public static bool boss;
	public static bool tutorial;
	public static AudioClip song;
	public static string songName;
	public static float difficulty;
	public int menu;
	public GameObject[] buttons;



	void Start(){
		boss = false;
		tutorial  = false;
		if (PlayerPrefs.HasKey ("Difficulty")) {
						difficulty = PlayerPrefs.GetFloat ("Difficulty");
				} else 
						difficulty = 2.0f;
		if (!PlayerPrefs.HasKey ("Currency")) {
						PlayerPrefs.SetInt ("Currency", 0);		
				} else {
			curency = PlayerPrefs.GetInt("Currency");
				}
	}
}
