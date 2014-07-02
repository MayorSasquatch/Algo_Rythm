using UnityEngine;
using System.Collections;

public class Deathbox : MonoBehaviour {
	Vector2 startPos;
	Vector2 direction;
	bool directionChosen;
	string gesture;
	public int score, multi, bestMulti;
	// Use this for initialization
	void Start () {
		score = 0;
		multi = 1;
		bestMulti = 1;
	}
	
	// Update is called once per frame
	void Update () {
		if (multi > bestMulti) {
			bestMulti = multi;}
		GameObject.Find("Score").GetComponent<TextMesh>().text =  (score.ToString().PadLeft(8,'0'));
		GameObject.Find("Multi").GetComponent<TextMesh>().text = (" x"+ multi.ToString());
		/*  // code for touch functionaltiy
		if (Input.touchCount > 0) {
			var touch = Input.GetTouch(0);
			
			// Handle finger movements based on touch phase.
			switch (touch.phase) {
				// Record initial touch position.
			case TouchPhase.Began:
				startPos = touch.position;
				directionChosen = false;
				break;
				
				// Determine direction by comparing the current touch
				// position with the initial one.
			case TouchPhase.Moved:
				direction = touch.position - startPos;
				break;
				
				// Report that a direction has been chosen when the finger is lifted.
			case TouchPhase.Ended:
				directionChosen = true;
				if(direction.x == 0 && direction.y == 0){gesture = "tap";}
				else if(direction.x > 10 && direction.y == 0){gesture = "right swipe";}
				else if(direction.x == 0 && direction.y < 10){gesture = "down swipe";}
				else {gesture = "none";}
				break;
			}
		}
	*/
		directionChosen = false;

		if(Input.GetMouseButtonDown(0)){
			startPos = (Vector2)Input.mousePosition;
			Debug.Log("Pressed left click.");
			directionChosen = false;
		}
		if(Input.GetMouseButton(0)){
			direction = (Vector2)Input.mousePosition - startPos; Debug.Log("held left click.");
			if(direction.x > Screen.width/4){gesture = "right swipe";directionChosen = true;startPos = (Vector2)Input.mousePosition;}
			else if(direction.y > Screen.height/3){gesture = "down swipe";directionChosen = true;startPos = (Vector2)Input.mousePosition;}}

		if (Input.GetMouseButtonUp(0)) {
			directionChosen = true;
			Debug.Log("lifted left click.");
			if(Mathf.Abs(direction.x) < Screen.width/20 && Mathf.Abs(direction.y) < Screen.height/20){gesture = "tap";}
			else if(direction.x > Screen.width/4){gesture = "right swipe";}
			else if(direction.y > Screen.height/3){gesture = "down swipe";}
			else {gesture = "tap";}
		}

	}

	void OnTriggerStay2D(Collider2D enemy){
		if ((directionChosen)&& (gesture == enemy.GetComponent<EnemyAI>().deathGesture) && enemy.rigidbody2D.velocity.x < 0) {
			
			if(enemy.name == "Wizard(Clone)"){
				score += 1000*multi;
				GameObject.Find ("Knight").GetComponent<Animator>().SetTrigger("mid");
				enemy.rigidbody2D.velocity = new Vector2(0,enemy.rigidbody2D.velocity.y);
				enemy.rigidbody2D.AddForce(new Vector2(300,0));
				enemy.GetComponent<EnemyAI>().state = 3;
				enemy.GetComponentInChildren<Animator>().SetTrigger("rest");
			}
			else{
				switch(enemy.name){
				case "Groundgrunt(Clone)":
					GameObject.Find ("Knight").GetComponent<Animator>().SetTrigger("low");
					break;
				case "Wyvern(Clone)":
					GameObject.Find ("Knight").GetComponent<Animator>().SetTrigger("mid");
					break;
				case "Ninja(Clone)":
					GameObject.Find ("Knight").GetComponent<Animator>().SetTrigger("top");
					break;
				}
				enemy.GetComponentInChildren<Animator>().SetTrigger("death");
				enemy.GetComponent<EnemyAI>().death();
			}
			multi++;
			score += 100*multi;
			if(multi%10 == 0) GameObject.Find("Knight").GetComponent<KnightHealth>().AdjustHealth(1f);
			
			enemy = null;
		}
		}

}
