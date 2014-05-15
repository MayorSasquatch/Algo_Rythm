﻿using UnityEngine;
using System.Collections;

public class Deathbox : MonoBehaviour {
	Vector2 startPos;
	Vector2 direction;
	bool directionChosen;
	string gesture;
	public int score, multi;
	// Use this for initialization
	void Start () {
		score = 0;
		multi = 1;
	}
	
	// Update is called once per frame
	void Update () {
		GameObject.Find("Score").guiText.text = (score.ToString().PadLeft(8,'0')+" x"+ multi.ToString());
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
			direction = (Vector2)Input.mousePosition - startPos; Debug.Log("held left click.");}
		if (Input.GetMouseButtonUp(0)) {
			directionChosen = true;
			Debug.Log("lifted left click.");
			if(Mathf.Abs(direction.x) < Screen.width/20 && Mathf.Abs(direction.y) < Screen.height/20){gesture = "tap";}
			else if(direction.x > Screen.width/3){gesture = "right swipe";}
			else if(direction.y > Screen.height/3){gesture = "down swipe";}
			else {gesture = "none";}
		}
	}
	void OnTriggerStay2D(Collider2D enemy){

		if ((directionChosen)&& (gesture == enemy.GetComponent<EnemyAI>().deathGesture)) {
			enemy.rigidbody2D.velocity = new Vector2(0,0);
			enemy.transform.position = enemy.GetComponent<EnemyAI>().startPos;
			multi++;
			score += 100*multi;
			if(multi%10 == 0) GameObject.Find("Knight").GetComponent<KnightHealth>().AdjustHealth(1f);
				}

		}
}
