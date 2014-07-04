using UnityEngine;
using System.Collections;

public class MoveCredits : MonoBehaviour {
	public float creditsVelocity;
	// Use this for initialization
	void OnEnable() 
	{
		this.transform.position = new Vector2(0,-97.9449f);
	}
	// Update is called once per frame
	void Update () {
		transform.position += new Vector3(0, creditsVelocity , 0);
	}
}
