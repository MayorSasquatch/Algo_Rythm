using UnityEngine;
using System.Collections;

public class BackButton : MonoBehaviour {
	public GameObject mainMenu;
	public GameObject firstStuff;
	public GameObject creditStuff;
	public GameObject playMenuStuff;
	public GameObject optionStuff;
	public GameObject selectionStuff;


	public GameObject cutsceneStuff;

	// Use this for initialization
	// Update is called once per frame
	void Update () {
		if(cutsceneStuff.activeSelf == false)
		{
			if(Input.GetKeyDown (KeyCode.Escape) && playMenuStuff.activeSelf == false && creditStuff.activeSelf == false && optionStuff.activeSelf == false && selectionStuff.activeSelf == false)
			{
				print ("QUIT");
				Application.Quit();
			}
			
			if(Input.GetKeyDown (KeyCode.Escape) && creditStuff.activeSelf == true)
			{
				creditStuff.SetActive(false);
				firstStuff.SetActive(true);
				//Buttons.menuState = "MAIN";
			}

			if(Input.GetKeyDown (KeyCode.Escape) && playMenuStuff.activeSelf == true)
			{
				mainMenu.SetActive(true);
				playMenuStuff.SetActive(false);
				firstStuff.SetActive(true);
				//Buttons.menuState = "MAIN";
			}
			if(Input.GetKeyDown (KeyCode.Escape) && optionStuff.activeSelf == true)
			{
				Application.LoadLevel("RS");
			}
		}

	}
}
