using UnityEngine;
using System.Collections;

public class cutscene : MonoBehaviour {
	Vector2 start, wstart;
	// Use this for initialization
	void Start () {
		start = GameObject.Find ("GUI Text").transform.position;
		//wstart = GameObject.Find ("Weapon_7").transform.position;
		//GameObject.Find ("GUI Text").rigidbody2D.AddForce (new Vector3(0,5,0));
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.Find ("GUI Text").rigidbody2D.velocity.y == 0) {
			GameObject.Find ("GUI Text").rigidbody2D.AddForce (new Vector3(0,5,0));
			GameObject.Find ("GUI Text").transform.position = start;
			GameObject.Find ("Weapon_7").rigidbody2D.AddForce (new Vector3(0,50,0));

			//GameObject.Find ("Weapon_7").transform.position = wstart;
				}
		if(GameObject.Find("Weapon_7").transform.position.y > 3.089731f){GameObject.Find ("Weapon_7").rigidbody2D.velocity = new Vector3(0,0,0);}
		Debug.Log (GameObject.Find("Weapon_7").transform.position.y);
	}
	void OnMouseDown(){
		Debug.Log ("bitch");

		if (Application.loadedLevelName == "RS") {
						GameObject.Find ("Level1_Button").GetComponent<Buttons> ().next ();
				} 
		if(Application.loadedLevelName == "scene"){
			GameObject.Find ("SplashScreen(Clone)").transform.position -= new Vector3 (0, -300, 0);
			Destroy(GameObject.Find("CutsceneWrap(Clone)"));
				}


	}
}
