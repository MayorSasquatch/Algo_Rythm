using UnityEngine;
using System.Collections;

public class Buttons : MonoBehaviour {

	private string colliderTag;
	public static bool state = false;
	public static string stateString = "";

	public GameObject optionsStuff;
	public GameObject creditsStuff;
	public GameObject titleStuff;
	public GameObject playStuff;
	// Use this for initialization
	void Start () {

	}

	void OnMouseDown() {
		colliderTag = collider2D.gameObject.tag;

		if(colliderTag == "PlayButton")
		{
			print ("PLAY");
			//state = true;
			stateString = "Play";
			titleStuff.SetActive(false);

			playStuff.SetActive(true);
		}
		else if(colliderTag == "OptionsButton")
		{
			print ("OPTIONS");
			state = true;
			stateString = "Options";
			titleStuff.SetActive(false);


			optionsStuff.SetActive(true);

		}
		else if(colliderTag == "CreditsButton")
		{
			print ("CREDITS");
			state = true;
			stateString = "Credits";
			titleStuff.SetActive(false);


			creditsStuff.SetActive(true);
		}




	}
	// Update is called once per frame

}
