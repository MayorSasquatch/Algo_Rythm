﻿using UnityEngine;
using System.Collections;

public class Buttons : MonoBehaviour {

	private string colliderTag;
	public static bool state = false;
	public static string stateString = "";

	public GameObject optionsStuff;
	public GameObject creditsStuff;
	public GameObject titleStuff;
	public GameObject playStuff;
	public GameObject mainMenuStuff;
	public GameObject playMenuStuff;
	public GameObject SelectionScreenStuff;

	public GameObject camPos;

	public static string menuState;

	public AudioSource buttonSound;
	// Use this for initialization
	void Update () {
		if (MainMenu.song != null && this.name == "Back_Button") {
						GameObject.Find ("SongName").guiText.text = MainMenu.songName;
						if (PlayerPrefs.HasKey (MainMenu.song.name + "capitanamerica")) {
								GameObject.Find ("HighScoreText").guiText.text = PlayerPrefs.GetInt (MainMenu.song.name + "capitanamerica").ToString();
								GameObject.Find ("HighComboText").guiText.text = PlayerPrefs.GetInt (MainMenu.song.name + "capitanamericacombo").ToString();
						} else {
								GameObject.Find ("HighScoreText").guiText.text = " ";
								GameObject.Find ("HighComboText").guiText.text = " ";
						}
				}
	}

	void OnMouseDown() {
		colliderTag = collider2D.gameObject.tag;

		if(colliderTag == "PlayButton")
		{
			print ("PLAY");
			menuState = "PLAY";
			//state = true;
			stateString = "Play";
			titleStuff.SetActive(false);
			mainMenuStuff.SetActive(false);


			playStuff.SetActive(true);
			playMenuStuff.SetActive(true);

			buttonSound.Play();
		}
		else if(colliderTag == "OptionsButton")
		{
			print ("OPTIONS");
			menuState = "OPTIONS";
			state = true;
			stateString = "Options";
			mainMenuStuff.SetActive(false);


			optionsStuff.SetActive(true);
			buttonSound.Play();
		}
		else if(colliderTag == "CreditsButton")
		{
			print ("CREDITS");
			menuState = "CREDITS";
			state = true;
			stateString = "Credits";
			titleStuff.SetActive(false);


			creditsStuff.SetActive(true);
			buttonSound.Play();
		}
		else if(colliderTag == "Level1Button")
		{
			/*
			 * change text displayed in selection screen
			 * */
			print ("level1");
			playMenuStuff.SetActive(false);
			SelectionScreenStuff.SetActive(true);
		}
		else if(colliderTag == "Level2Button")
		{
			playMenuStuff.SetActive(false);
			SelectionScreenStuff.SetActive(true);
		}
		else if(colliderTag == "Level3Button")
		{
			playMenuStuff.SetActive(false);
			SelectionScreenStuff.SetActive(true);
		}
		else if(this.name == "Back_Button")
		{
			playMenuStuff.SetActive(true);
			SelectionScreenStuff.SetActive(false);
		}
		else if(this.name == "Start_Button")
		{
			//Debug.Log ("working");
			playMenuStuff.SetActive(true);
			GameObject temp = GameObject.Find ("PlayButtons");
			temp.SetActive(false);
			mainMenuStuff.SetActive(true);

			SelectionScreenStuff.SetActive(false);
			DontDestroyOnLoad( GameObject.Find("PlayMenu"));
			Application.LoadLevel("scene");
		}
		else if(colliderTag == "SaveCloseButton")
		{
			Application.LoadLevel("RS");
			menuState = "MainMenu";
			buttonSound.Play ();
			//optionsStuff.SetActive(false);
			//mainMenuStuff.SetActive(true);
			//print (camPos.transform.position.x);
			//Camera.current.transform.Translate(new Vector3(camPos.transform.position.x, camPos.transform.position.y, camPos.transform.position.z));

		}




	}

	// Update is called once per frame

}
