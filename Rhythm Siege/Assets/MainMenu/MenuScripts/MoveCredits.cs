using UnityEngine;
using System.Collections;

public class MoveCredits : MonoBehaviour {
	public float creditsVelocity;
	// Use this for initialization

	// Update is called once per frame
	void Update () {
		transform.position += new Vector3(0, creditsVelocity , 0);
	}
}
