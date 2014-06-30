using UnityEngine;
using System.Collections;

public class BackButton : MonoBehaviour {
	public GameObject firstStuff;
	public GameObject creditStuff;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown (KeyCode.Escape))
		{
			creditStuff.SetActive(false);
			firstStuff.SetActive(true);

		}

	}
}
