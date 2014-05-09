using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {
	
	public float moveSpeed;
	public string deathGesture;
	private Transform myTransform;
	public Vector3 startPos;
	void Awake(){
		myTransform = transform;
	}

	// Use this for initialization
	void Start () {
		startPos = this.transform.position;
		//this.rigidbody2D.AddForce(new Vector2(-moveSpeed,0));
	}
	
	// Update is called once per frame
	void Update () {

		// Move towards target
		//myTransform.position -= myTransform.right * moveSpeed * Time.deltaTime;


		//if(Input.GetMouseButtonUp(KeyCode.Mouse0))

		if (myTransform.position.x < -40) {
			this.rigidbody2D.velocity = new Vector2(0,0);
			this.transform.position = startPos;
				}; // Destroys the enemy after it goes beyond the screen to the left
	}
}
