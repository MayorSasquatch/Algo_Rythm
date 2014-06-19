using UnityEngine;
using System.Collections;

public class StateMachine : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Buttons.state == true)
			this.renderer.enabled = false;
	}
}
