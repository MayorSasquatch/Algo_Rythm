using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {


	float time, deltatime, clock;
	bool resume; 
	// Use this for initialization
	void Start () {
		time = Time.realtimeSinceStartup;
		resume = false;
	}

	void Update(){
		deltatime = Time.realtimeSinceStartup - time;
		time = Time.realtimeSinceStartup;
		if(resume){
			clock += deltatime;
			if(clock >= 3){
				GameObject.Find("audioanalyser").audio.Play();
				GameObject.Find("Floor").audio.Play();
				Time.timeScale = 1;
				Destroy(GameObject.Find ("MainMenuButton(Clone)"));
				Destroy(GameObject.Find ("Countdown(Clone)"));
				Destroy(GameObject.Find ("ResumeButton(Clone)"));

			}
			else if(clock > 2){}
			else if(clock > 1){}
		}

	}

	// Update is called once per frame
	void OnMouseDown(){
		if (this.name == "PauseButton") {
			Time.timeScale = 0;
			GameObject.Find("audioanalyser").audio.Pause();
			GameObject.Find("Floor").audio.Pause();
			Instantiate(Resources.Load("ResumeButton"));
			Instantiate(Resources.Load("MainMenuButton"));
		}
		else if(this.name == "MainMenuButton(Clone)"){
			SongSelect.path = null;
			Time.timeScale = 1;
			Application.LoadLevel("MainMenu");
		}
		else if(this.name == "ResumeButton(Clone)"){
			resume = true;
			clock = 0f;
			Instantiate(Resources.Load("Countdown"));

		}
	}

}
 