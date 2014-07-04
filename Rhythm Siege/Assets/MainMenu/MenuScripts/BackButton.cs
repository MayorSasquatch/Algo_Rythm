using UnityEngine;
using System.Collections;

public class BackButton : MonoBehaviour {
	public GameObject mainMenu;
	public GameObject firstStuff;
	public GameObject creditStuff;
	public GameObject playMenuStuff;
	public GameObject optionStuff;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown (KeyCode.Escape) && creditStuff.activeSelf == true)
		{

			creditStuff.SetActive(false);
			firstStuff.SetActive(true);
		}

		if(Input.GetKeyDown (KeyCode.Escape) && playMenuStuff.activeSelf == true)
		{
			mainMenu.SetActive(true);
			playMenuStuff.SetActive(false);
			firstStuff.SetActive(true);
		}
		if(Input.GetKeyDown (KeyCode.Escape) && optionStuff.activeSelf == true)
		{
			Application.LoadLevel("RS");
		}

	}
}
