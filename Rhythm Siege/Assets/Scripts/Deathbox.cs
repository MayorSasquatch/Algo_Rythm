using UnityEngine;
using System.Collections;

public class Deathbox : MonoBehaviour {
	Vector2 startPos;
	Vector2 direction;
	bool directionChosen;
	string gesture;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
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
			if(direction.x == 0 && direction.y == 0){gesture = "tap";}
			else if(direction.x > 10 && direction.y == 0){gesture = "right swipe";}
			else if(direction.x == 0 && direction.y < 10){gesture = "down swipe";}
			else {gesture = "none";}
		}
	}
	void OnTriggerStay2D(Collider2D enemy){
		Debug.Log("collision!!!!!!!!!!!!!!");
		if ((directionChosen)&& (gesture == enemy.GetComponent<EnemyAI>().deathGesture)) {
			Destroy(enemy);
				}

		}
}
