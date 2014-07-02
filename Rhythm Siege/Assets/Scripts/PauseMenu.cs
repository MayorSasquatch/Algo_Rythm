using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	public AudioSource buttonClang;
	GameObject t_Pause;
	PauseMenu pm;

	float time, deltatime, clock, delaytime;
	bool resume; 
	GameObject loading;
	// Use this for initialization
	void Start () {
		t_Pause = GameObject.Find("PauseButton");
		pm = t_Pause.GetComponent<PauseMenu>();
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
				GameObject.Find("PauseButton").transform.position -= new Vector3(0,200, 0);

			}
			else if(clock > 2){GameObject.Find ("Countdown(Clone)").guiText.text = "1";}
			else if(clock > 1){GameObject.Find ("Countdown(Clone)").guiText.text = "2";}
		}

	}

	// Update is called once per frame
	void OnMouseDown(){
		if (this.name == "PauseButton") {
			MusicScript.player = true;
			pm.buttonClang.Play ();
			Time.timeScale = 0;
			GameObject.Find("audioanalyser").audio.Pause();
			GameObject.Find("Floor").audio.Pause();
			Instantiate(Resources.Load("ResumeButton"));
			Instantiate(Resources.Load("MainMenuButton"));
			Instantiate(Resources.Load("Retry"));
			GameObject.Find("PauseButton").transform.position += new Vector3(0,200, 0);
		}
		else if(this.name == "MainMenuButton(Clone)" || this.name == "MainMenuButton" ){
			pm.buttonClang.Play ();
			SongSelect.path = null;
			Time.timeScale = 1;
			Application.LoadLevel("RS");
		}
		else if(this.name == "ResumeButton(Clone)" || this.name == "ResumeButton"){
			MusicScript.player = false;
			pm.buttonClang.Play ();
			resume = true;
			clock = 0f;
			Instantiate(Resources.Load("Countdown"));
			GameObject.Find ("MainMenuButton(Clone)").transform.position += new Vector3(0,0, 200);
			GameObject.Find ("ResumeButton(Clone)").transform.position += new Vector3(0,0, 200);
			GameObject.Find ("Retry(Clone)").transform.position += new Vector3(0,0, 200);

		}
		else if(this.name == "Retry(Clone)" || this.name == "Retry"){
			pm.buttonClang.Play ();
			Time.timeScale = 1;
			Application.LoadLevel("scene");
		}
	}

}
 