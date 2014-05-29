using UnityEngine;
using System.Collections;

public class KnightHealth : MonoBehaviour {
    float time, deltatime, clock;

	public float curHealth;
	public float maxHealth;
	public float hitCooldown;

	private float hitTime;

	// Use this for initialization
	void Start () {
		hitTime = 0;
		time = Time.realtimeSinceStartup;

	}

	// Update is called once per frame
	void Update () {
		GameObject.Find ("Health").transform.localScale = new Vector3(1.812499f,3f*curHealth,1f);

		deltatime = Time.realtimeSinceStartup - time;
		time = Time.realtimeSinceStartup; 
		if(curHealth <= 0){
			clock += deltatime;
			if(clock >= 3){
				Time.timeScale = 0;
				GameObject.Find("audioanalyser").audio.Pause();
				GameObject.Find("Floor").audio.Pause();
				Instantiate(Resources.Load("Backdrop"));
				GameObject menu = (GameObject)Instantiate(Resources.Load("MainMenuButton"));
				menu.transform.position = new Vector3(-10.42073f,-1.591948f,-7.1f);
				Destroy(GameObject.Find("Knight"));
				MainMenu.curency += (int)GameObject.Find ("Deathbox").GetComponent<Deathbox>().score/1000;
				PlayerPrefs.SetInt("Currency", MainMenu.curency);
				PlayerPrefs.SetInt(MainMenu.song.name + "capitanamerica",(int)GameObject.Find ("Deathbox").GetComponent<Deathbox>().score );
				PlayerPrefs.SetInt(MainMenu.song.name + "capitanamericacombo",(int)GameObject.Find ("Deathbox").GetComponent<Deathbox>().bestMulti );
				PlayerPrefs.Save();
			}
			else if(clock > 2){}
			else if(clock > 1){}
		}
	}

	public void AdjustHealth(float adj){

		if(adj > 0) curHealth += adj;
		else {
			if(Time.time - hitTime > hitCooldown){
				curHealth += adj;
				hitTime = Time.time;
			}
		}

		if(curHealth > maxHealth) curHealth = maxHealth;
		if(curHealth < 0) curHealth = 0;
	}

	void OnTriggerEnter2D(Collider2D hit){
		//Debug.Log("Hit");
		if(hit.gameObject.tag == "Enemy"){ 
			AdjustHealth(-1); // If the player is hit by an enemy, lose health
			GameObject.Find ("Deathbox").GetComponent<Deathbox> ().multi = 1;
			hit.transform.GetComponentInChildren<Animator>().SetTrigger("Attack");
		}
	}

}
