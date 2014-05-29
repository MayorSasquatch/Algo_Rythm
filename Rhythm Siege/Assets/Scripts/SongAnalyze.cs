using UnityEngine;
using System.Collections;
using System.IO;

public class SongAnalyze : MonoBehaviour {
	float levelTime ;
	float time, deltatime, clock;
	bool go;
	bool[] tut; 
	// Use this for initialization
	void Start () {
		levelTime = -5f - (5f - MainMenu.difficulty);
		time = Time.realtimeSinceStartup;

		gameObject.GetComponent<AudioSource> ().audio.clip = MainMenu.song;
		go = true;
		tut = new bool[10];
		for(int i = 0; i<tut.Length; i++){tut[i] = false;}
	}
	
	// Update is called once per frame
	void Update () {
		if(levelTime >= 0f && go){this.audio.Play(); go = false;}
		levelTime += Time.deltaTime;
			deltatime = Time.realtimeSinceStartup - time;
			time = Time.realtimeSinceStartup;
			if(levelTime >= this.audio.clip.length){
				clock += deltatime;
				if(clock >= 3){
					Time.timeScale = 0;
					GameObject.Find("audioanalyser").audio.Pause();
					GameObject.Find("Floor").audio.Pause();
					Instantiate(Resources.Load("Backdrop"));
					GameObject menu = (GameObject)Instantiate(Resources.Load("MainMenuButton"));
					menu.transform.position = new Vector3(-10.42073f,-1.591948f,-7.1f);
				    MainMenu.curency += (int)GameObject.Find ("Deathbox").GetComponent<Deathbox>().score/1000;
				    PlayerPrefs.SetInt("Currency", MainMenu.curency);
				    PlayerPrefs.Save();
					Destroy(GameObject.Find("audioanalyser"));
				}
				else if(clock > 2){}
				else if(clock > 1){}
			}
		if(MainMenu.tutorial){Tutorial ();}
		}

	void Tutorial(){
		if(!tut[0]){GameObject.Find ("TutorialText(Clone)").guiText.text = "Enemies will run at you from the right"; tut[0]=true;}
		if(levelTime >= 4f && !tut[1]){
			Time.timeScale = 0;
			GameObject.Find("audioanalyser").audio.Pause();
			GameObject.Find("Floor").audio.Pause();
			GameObject hand = (GameObject)Instantiate(Resources.Load("Hand"));
			GameObject.Find ("TutorialText(Clone)").guiText.text = "Tap to defeat Hellhounds when they reach the white light";
			tut[1]=true;
		}
		if(levelTime >= 8f && !tut[2]){
			Time.timeScale = 0;
			GameObject.Find("audioanalyser").audio.Pause();
			GameObject.Find("Floor").audio.Pause();
			GameObject hand = (GameObject)Instantiate(Resources.Load("Hand"));
			GameObject.Find ("TutorialText(Clone)").guiText.text = "Swipe right to defeat Orcs";
			tut[2]=true;
		}
		if(levelTime >= 12f && !tut[3]){
			Time.timeScale = 0;
			GameObject.Find("audioanalyser").audio.Pause();
			GameObject.Find("Floor").audio.Pause();
			GameObject hand = (GameObject)Instantiate(Resources.Load("Hand"));
			GameObject.Find ("TutorialText(Clone)").guiText.text = "Swipe up to defeat Drakes";
			tut[3]=true;
		}
		if(levelTime >= 16f && !tut[4]){


			GameObject.Find ("TutorialText(Clone)").guiText.text = "When you miss an enemy they'll hit you";
			tut[4]=true;
		}
		if(levelTime >= 20f && !tut[5]){


			GameObject.Find ("TutorialText(Clone)").guiText.text = "Five hits and your're done for";
			tut[5]=true;
		}
		if(levelTime >= 24f && !tut[6]){
			
		
			GameObject.Find ("TutorialText(Clone)").guiText.text = "Defeat 10 enemies in a row to get health back";
			tut[6]=true;
		}
		if(levelTime >= 28f && !tut[7]){
			
		
			GameObject.Find ("TutorialText(Clone)").guiText.text = "Defeat enemies in a row to get a combo";
			tut[7]=true;
		}
		if(levelTime >= 32f && !tut[8]){
			
			
			GameObject.Find ("TutorialText(Clone)").guiText.text = "The higher your combo the more points you get!";
			tut[8]=true;
		}
	}
}
