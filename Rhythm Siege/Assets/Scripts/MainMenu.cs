using UnityEngine;
using System.Collections;
using Chartboost;


public class MainMenu : MonoBehaviour {
	public static int curency;
	public static bool boss;
	public static bool tutorial;
	public static AudioClip song;
	public static string songName;
	public static float difficulty;
	public static string rootfolder;
	public int menu;
	public GameObject[] buttons;
	public static int levelunlock;
	public static int deaths;


	void Start(){
		CBBinding.init("53b5f04589b0bb7ee6ad564d", "4c9e683e37ae859d14c1596efc2a0b3e93eb27e8");
		deaths = 0;
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

		if (!PlayerPrefs.HasKey ("rootfolder")) {
			PlayerPrefs.SetString ("rootfolder", "");		
		} else {
			rootfolder = PlayerPrefs.GetString("rootfolder");
		}

		if (!PlayerPrefs.HasKey ("levelunlock")) {
			PlayerPrefs.SetInt ("levelunlock", 1);		
		} else {
			levelunlock = PlayerPrefs.GetInt("levelunlock");
		}
		if (!PlayerPrefs.HasKey ("warning")) {
			PlayerPrefs.SetInt ("warning", 0);}	
	}
}
