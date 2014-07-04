using UnityEngine;
using System.Collections;
using System.IO;

public class SongAnalyze : MonoBehaviour {
	public float levelTime ;
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
		clock = 0f;
		for(int i = 0; i<tut.Length; i++){tut[i] = false;}
	}
	
	// Update is called once per frame
	void Update () {
		if(levelTime >= 0f && go){this.audio.Play(); go = false; Destroy(GameObject.Find("MainMenuSong"));}
		levelTime += Time.deltaTime;
			deltatime = Time.realtimeSinceStartup - time;
			time = Time.realtimeSinceStartup;
			if(levelTime >= this.audio.clip.length && GameObject.Find("Knight") != null){
			if(clock == 0f){
				Destroy(GameObject.Find ("PauseButton"));
				}
				clock += deltatime;
				
				if(clock >= 3){
				if(MainMenu.songName == "Big Rock" && MainMenu.levelunlock < 2 ){ MainMenu.levelunlock = 2;}
				else if(MainMenu.songName == "Summon the Rawk" && MainMenu.levelunlock < 3 ){ MainMenu.levelunlock = 3;}
				PlayerPrefs.SetInt("levelunlock", MainMenu.levelunlock);
				string scorekey = (MainMenu.songName + "capitanamerica" + MainMenu.difficulty.ToString());
				//Debug.Log(scorekey);
				string scorekeycombo = (MainMenu.songName + "capitanamericacombo"+MainMenu.difficulty.ToString());
				GameObject.Find("Multi").SetActive(false);
				GameObject.Find("Score").SetActive(false);
				Instantiate(Resources.Load("SplashScreen"));
				Destroy(GameObject.Find ("Deathbox"));

				if(MainMenu.boss){GameObject.Find("SplashScreen(Clone)").transform.position += new Vector3(0,-300,0);
					Instantiate(Resources.Load("CutsceneWrap"));
					GameObject.Find ("Wizard(Clone)").GetComponentInChildren<Animator>().SetTrigger("tired");
					PlayerPrefs.SetInt("Axe_Values 8", 1);
					PlayerPrefs.Save();
					}
				Destroy(GameObject.Find("Knight"));
				Destroy(GameObject.Find ("Fail_Window"));
				GameObject.Find ("Scoretext").GetComponent<TextMesh>().text =  GameObject.Find ("Deathbox").GetComponent<Deathbox>().score.ToString();
				GameObject.Find ("multitext").GetComponent<TextMesh>().text =  GameObject.Find ("Deathbox").GetComponent<Deathbox>().bestMulti.ToString();
				MainMenu.curency += (int)GameObject.Find ("Deathbox").GetComponent<Deathbox>().score/1000;
				GameObject.Find ("Goldtext").GetComponent<TextMesh>().text = (GameObject.Find ("Deathbox").GetComponent<Deathbox>().score/1000).ToString();
				PlayerPrefs.SetInt("Currency", MainMenu.curency);
				if(PlayerPrefs.HasKey(scorekey)){
					if(PlayerPrefs.GetInt(scorekey) < GameObject.Find ("Deathbox").GetComponent<Deathbox>().score){
						PlayerPrefs.SetInt(scorekey,(int)GameObject.Find ("Deathbox").GetComponent<Deathbox>().score );
					}
					GameObject.Find ("ScoreHightext").GetComponent<TextMesh>().text =  PlayerPrefs.GetInt(scorekey).ToString();
					
					if(PlayerPrefs.GetInt(scorekeycombo) < GameObject.Find ("Deathbox").GetComponent<Deathbox>().bestMulti){
						PlayerPrefs.SetInt(scorekeycombo,(int)GameObject.Find ("Deathbox").GetComponent<Deathbox>().bestMulti);
					}
					GameObject.Find ("multihightext").GetComponent<TextMesh>().text =  PlayerPrefs.GetInt(scorekeycombo).ToString();
				}
				else{
					PlayerPrefs.SetInt(scorekey,(int)GameObject.Find ("Deathbox").GetComponent<Deathbox>().score );
					GameObject.Find ("ScoreHightext").GetComponent<TextMesh>().text =  PlayerPrefs.GetInt(scorekey).ToString();
					PlayerPrefs.SetInt(scorekeycombo,(int)GameObject.Find ("Deathbox").GetComponent<Deathbox>().bestMulti);
					GameObject.Find ("multihightext").GetComponent<TextMesh>().text =  PlayerPrefs.GetInt(scorekeycombo).ToString();
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
		if(levelTime >= -4 && !tut[0]){GameObject.Find ("TutorialText(Clone)").GetComponent<TextMesh>().text = "Enemies will run at \n you from the right"; tut[0]=true;}
		if(levelTime >= 1f && !tut[1]){
			GameObject hand = (GameObject)Instantiate(Resources.Load("Hand"));
			hand.GetComponentInChildren<Animator>().SetTrigger("tap");
			GameObject.Find ("TutorialText(Clone)").GetComponent<TextMesh>().text = "Tap to defeat Hellhounds\n when they reach the box";
			tut[1]=true;
		}
		if(levelTime >= 6f && !tut[2]){
			GameObject.Find("Hand(Clone)").GetComponentInChildren<Animator>().SetTrigger("rswipe");
			GameObject.Find ("TutorialText(Clone)").GetComponent<TextMesh>().text = "Swipe right to defeat Orcs";
			tut[2]=true;
		}
		if(levelTime >= 11f && !tut[3]){
			GameObject.Find("Hand(Clone)").GetComponentInChildren<Animator>().SetTrigger("uswipe");
			GameObject.Find ("TutorialText(Clone)").GetComponent<TextMesh>().text = "Swipe up to defeat Drakes";
			tut[3]=true;
		}
		if(levelTime >= 16f && !tut[4]){
			GameObject.Find ("TutorialText(Clone)").GetComponent<TextMesh>().text = "When you miss an enemy\n they'll hit you";
			GameObject.Find("Hand(Clone)").GetComponentInChildren<Animator>().SetTrigger("point");
			GameObject.Find("Hand(Clone)").transform.position = new Vector3(-28.18708f,7.576175f,-23.84875f);
			tut[4]=true;
		}
		if(levelTime >= 21f && !tut[5]){
			GameObject.Find ("TutorialText(Clone)").GetComponent<TextMesh>().text = "Five hits and your're\n done for";
			GameObject.Find("Hand(Clone)").transform.eulerAngles = new Vector3(0,0, -90.17902f);
			tut[5]=true;
		}
		if(levelTime >= 26f && !tut[6]){

			GameObject.Find ("TutorialText(Clone)").GetComponent<TextMesh>().text = "Defeat 10 enemies in a\n row to get health back";
			tut[6]=true;
		}
		if(levelTime >= 31f && !tut[7]){
			
			GameObject.Find("Hand(Clone)").transform.eulerAngles = new Vector3(0,0,187.8691f);
			GameObject.Find ("TutorialText(Clone)").GetComponent<TextMesh>().text = "Defeat enemies in a row\n to get a combo";
			tut[7]=true;
		}
		if(levelTime >= 36f && !tut[8]){
			GameObject.Find("Hand(Clone)").transform.position = new Vector3(-20.90291f,11.5765f,-23.84875f);
			GameObject.Find("Hand(Clone)").transform.eulerAngles = new Vector3(0,0,213.533f);
			GameObject.Find ("TutorialText(Clone)").GetComponent<TextMesh>().text = "The higher your combo\n the more points you get!";
			tut[8]=true;
		}
		if(levelTime >= 40f && !tut[9]){
			levelTime += 100000000000000;
			Destroy(GameObject.Find("Hand(Clone)"));
			GameObject.Find ("TutorialText(Clone)").GetComponent<TextMesh>().text = "";
			tut[9]=true;
		}
	}
}
