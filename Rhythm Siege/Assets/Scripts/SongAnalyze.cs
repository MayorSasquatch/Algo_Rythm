using UnityEngine;
using System.Collections;
using System.IO;

public class SongAnalyze : MonoBehaviour {
	float levelTime;
	float time, deltatime, clock;

	// Use this for initialization
	void Start () {
		levelTime = -8f;
		time = Time.realtimeSinceStartup;
		WWW www = new WWW ("file://" + SongSelect.path);
		
		AudioClip myAudioClip= www.audioClip;
		while (!myAudioClip.isReadyToPlay)
		gameObject.GetComponent<AudioSource> ().audio.clip = myAudioClip;

		this.audio.PlayDelayed(8f);
	}
	
	// Update is called once per frame
	void Update () {
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
		}
}
