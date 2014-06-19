using UnityEngine;
using System.Collections;

public class Back : MonoBehaviour {
	public GameObject titleStuff;
	// Use this for initialization

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			print("ESC");
			Application.LoadLevel("RS");
			titleStuff.SetActive(true);

		}
	}
}
