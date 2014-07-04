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
		clock = 0f;

	}

	// Update is called once per frame
	void Update () {
		GameObject.Find ("Health").transform.localScale = new Vector3(1.812499f,3f*curHealth,1f);
		switch ((int)curHealth) {
		case 6:
		case 5:
			GameObject.Find ("Health").renderer.material.color = Color.green;
			GameObject.Find ("SkullImage").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite> ("Hard_Image");
			break;
		case 4:
		case 3:
			GameObject.Find ("Health").renderer.material.color = Color.yellow;
			GameObject.Find ("SkullImage").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite> ("Medium_Image");
			break;
		case 2:
		case 1:
			GameObject.Find ("Health").renderer.material.color = Color.red;
			GameObject.Find ("SkullImage").GetComponent<SpriteRenderer>().sprite = Resources.Load <Sprite>("Easy_Image");
			break;
		case 0:
			GameObject.Find ("SkullImage").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Dead_Image");
			break;
				}

		deltatime = Time.realtimeSinceStartup - time;
		time = Time.realtimeSinceStartup; 
		if(curHealth <= 0){
			if(clock == 0f){
				Destroy(GameObject.Find ("PauseButton"));
				this.GetComponent<Animator>().SetTrigger("dead");
				this.transform.parent.rigidbody2D.AddForce(new Vector2(-2100,0));
			}
		//	Debug.Log (clock);
			clock += deltatime;
			if(clock >= 3){
				GameObject.Find("BG_BG").GetComponent<NewBehaviourScript>().speedchange(0f);
				GameObject.Find("BG_FG").GetComponent<NewBehaviourScript>().speedchange(0f);
				string scorekey =(MainMenu.songName + "capitanamerica" + MainMenu.difficulty.ToString());
				string scorekeycombo = (MainMenu.songName + "capitanamericacombo"+MainMenu.difficulty.ToString());
				//Debug.Log(scorekey);
				GameObject.Find("Multi").SetActive(false);
				GameObject.Find("Score").SetActive(false);
				Instantiate(Resources.Load("SplashScreen"));
				Destroy(GameObject.Find("Knight"));
				Destroy(GameObject.Find ("Successs_Window"));
				Destroy(GameObject.Find ("Deathbox"));

				GameObject.Find ("Scoretext").GetComponent<TextMesh>().text =  GameObject.Find ("Deathbox").GetComponent<Deathbox>().score.ToString();
				GameObject.Find ("multitext").GetComponent<TextMesh>().text =  GameObject.Find ("Deathbox").GetComponent<Deathbox>().bestMulti.ToString();
				MainMenu.curency += (int)GameObject.Find ("Deathbox").GetComponent<Deathbox>().score/1000;
				GameObject.Find ("Goldtext").GetComponent<TextMesh>().text = (GameObject.Find ("Deathbox").GetComponent<Deathbox>().score/2000).ToString();
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
	if (curHealth < 0) {
		curHealth = 0;
		this.GetComponent<Animator>().SetBool("dead",true);
			//GameObject.Find("KnightWrap").rigidbody2D.AddForce(new Vector3(-1000,-200,0) );
	}
}

	void OnTriggerEnter2D(Collider2D hit){
		//Debug.Log("Hit");
		if(hit.gameObject.tag == "Enemy"){
			//play hit sound
			if(GameObject.Find("CombatSoundHold").GetComponent<CombatSounds>().playerHit.isPlaying == false)
			GameObject.Find("CombatSoundHold").GetComponent<CombatSounds>().playerHit.Play();
			AdjustHealth(-1); // If the player is hit by an enemy, lose health
			GameObject.Find ("Deathbox").GetComponent<Deathbox> ().multi = 1;
			hit.transform.GetComponentInChildren<Animator>().SetTrigger("Attack");

		}
	}

}
