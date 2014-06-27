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
		this.audio.Play (); this.audio.Pause ();
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
					Instantiate(Resources.Load("SplashScreen"));
					Destroy(GameObject.Find("Knight"));
					GameObject.Find ("Scoretext").GetComponent<TextMesh>().text = "Score: "+ GameObject.Find ("Deathbox").GetComponent<Deathbox>().score;
					GameObject.Find ("multitext").GetComponent<TextMesh>().text = "Multiplier: "+ GameObject.Find ("Deathbox").GetComponent<Deathbox>().bestMulti;
					MainMenu.curency += (int)GameObject.Find ("Deathbox").GetComponent<Deathbox>().score/1000;
					PlayerPrefs.SetInt("Currency", MainMenu.curency);
					if(PlayerPrefs.HasKey(MainMenu.song.name + "capitanamerica")){
					if(PlayerPrefs.GetInt(MainMenu.song.name + "capitanamerica") < GameObject.Find ("Deathbox").GetComponent<Deathbox>().score){
						PlayerPrefs.SetInt(MainMenu.song.name + "capitanamerica",(int)GameObject.Find ("Deathbox").GetComponent<Deathbox>().score );
					}
					GameObject.Find ("ScoreHightext").GetComponent<TextMesh>().text = "High Score: "+ PlayerPrefs.GetInt(MainMenu.song.name + "capitanamerica");
					
					if(PlayerPrefs.GetInt(MainMenu.song.name + "capitanamericacombo") < GameObject.Find ("Deathbox").GetComponent<Deathbox>().bestMulti){
						PlayerPrefs.SetInt(MainMenu.song.name + "capitanamericacombo",(int)GameObject.Find ("Deathbox").GetComponent<Deathbox>().bestMulti);
					}
					GameObject.Find ("multihightext").GetComponent<TextMesh>().text = "Max Multi: "+ PlayerPrefs.GetInt(MainMenu.song.name + "capitanamericacombo");
					}
					PlayerPrefs.Save();
					Destroy(GameObject.Find("audioanalyser"));
				}
				else if(clock > 2){}
				else if(clock > 1){}
			}
		if(MainMenu.tutorial){Tutorial ();}
		}

	void Tutorial(){
		if(levelTime >= -4 && !tut[0]){GameObject.Find ("TutorialText(Clone)").guiText.text = "Enemies will run at you from the right"; tut[0]=true;}
		if(levelTime >= 1f && !tut[1]){
			GameObject hand = (GameObject)Instantiate(Resources.Load("Hand"));
			hand.GetComponentInChildren<Animator>().SetTrigger("tap");
			GameObject.Find ("TutorialText(Clone)").guiText.text = "Tap to defeat Hellhounds when they reach the white light";
			tut[1]=true;
		}
		if(levelTime >= 6f && !tut[2]){
			GameObject.Find("Hand(Clone)").GetComponentInChildren<Animator>().SetTrigger("rswipe");
			GameObject.Find ("TutorialText(Clone)").guiText.text = "Swipe right to defeat Orcs";
			tut[2]=true;
		}
		if(levelTime >= 11f && !tut[3]){
			GameObject.Find("Hand(Clone)").GetComponentInChildren<Animator>().SetTrigger("uswipe");
			GameObject.Find ("TutorialText(Clone)").guiText.text = "Swipe up to defeat Drakes";
			tut[3]=true;
		}
		if(levelTime >= 16f && !tut[4]){
			GameObject.Find ("TutorialText(Clone)").guiText.text = "When you miss an enemy they'll hit you";
			GameObject.Find("Hand(Clone)").GetComponentInChildren<Animator>().SetTrigger("point");
			GameObject.Find("Hand(Clone)").transform.position = new Vector3(-28.18708f,7.576175f,-23.84875f);
			tut[4]=true;
		}
		if(levelTime >= 21f && !tut[5]){
			GameObject.Find ("TutorialText(Clone)").guiText.text = "Five hits and your're done for";
			GameObject.Find("Hand(Clone)").transform.eulerAngles = new Vector3(0,0, -90.17902f);
			tut[5]=true;
		}
		if(levelTime >= 26f && !tut[6]){

			GameObject.Find ("TutorialText(Clone)").guiText.text = "Defeat 10 enemies in a row to get health back";
			tut[6]=true;
		}
		if(levelTime >= 31f && !tut[7]){
			
			GameObject.Find("Hand(Clone)").transform.eulerAngles = new Vector3(0,0,187.8691f);
			GameObject.Find ("TutorialText(Clone)").guiText.text = "Defeat enemies in a row to get a combo";
			tut[7]=true;
		}
		if(levelTime >= 36f && !tut[8]){
			GameObject.Find("Hand(Clone)").transform.position = new Vector3(-20.90291f,11.5765f,-23.84875f);
			GameObject.Find("Hand(Clone)").transform.eulerAngles = new Vector3(0,0,213.533f);
			GameObject.Find ("TutorialText(Clone)").guiText.text = "The higher your combo the more points you get!";
			tut[8]=true;
		}
	}
}
