using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {
	
	public int moveSpeed;

	private Transform myTransform;

	void Awake(){
		myTransform = transform;
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		// Move towards target
		myTransform.position -= myTransform.right * moveSpeed * Time.deltaTime;

		//if(Input.GetMouseButtonUp(KeyCode.Mouse0))
	}
}
