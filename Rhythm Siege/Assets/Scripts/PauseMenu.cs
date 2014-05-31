using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {


	float time, deltatime, clock, delaytime;
	bool resume; 
	GameObject loading;
	// Use this for initialization
	void Start () {
		time = Time.realtimeSinceStartup;
		resume = false;
		delaytime = 0;
		loading = GameObject.Find ("PlayMenu");
	}

	void Update(){
	

		delaytime += Time.deltaTime;
		deltatime = Time.realtimeSinceStartup - time;
		time = Time.realtimeSinceStartup;
		if(resume && this.name == "ResumeButton(Clone)"){
			clock += deltatime;
			if(clock >= 3){

				if (Time.timeSinceLevelLoad >= 5f + (5f-MainMenu.difficulty)){GameObject.Find("audioanalyser").audio.Play();}

				GameObject.Find("Floor").audio.Play();
				Time.timeScale = 1;
				Destroy(GameObject.Find ("MainMenuButton(Clone)"));
				Destroy(GameObject.Find ("Countdown(Clone)"));
				Destroy(GameObject.Find ("ResumeButton(Clone)"));
				Destroy(GameObject.Find ("Retry(Clone)"));
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
			Instantiate(Resources.Load("Retry"));
		}
		else if(this.name == "MainMenuButton(Clone)"){
			SongSelect.path = null;
			Time.timeScale = 1;
			Application.LoadLevel("RS");
		}
		else if(this.name == "ResumeButton(Clone)"){
			resume = true;
			clock = 0f;
			Instantiate(Resources.Load("Countdown"));

		}
		else if(this.name == "Retry(Clone)"){
			Time.timeScale = 1;
			Application.LoadLevel("scene");
		}
	}

}
 