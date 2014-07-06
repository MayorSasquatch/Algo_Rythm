using UnityEngine;
using System.Collections;

public class MoveCredits : MonoBehaviour {
	public float creditsVelocity;
	// Use this for initialization
	void OnEnable() 
	{
		//transform.position = new Vector3(7.29204f,-90f, -12.94136f);
		transform.position = transform.TransformDirection(0.29204f,-85f, -12.94136f);
	}
	// Update is called once per frame
	void Update () {
		transform.position += new Vector3(0, creditsVelocity , 0);
	}
}
