using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {
	
	public int moveSpeed;
	public string deathGesture;
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
		//myTransform.position -= myTransform.right * moveSpeed * Time.deltaTime;
		this.rigidbody2D.AddForce(new Vector2(-moveSpeed,0));

		//if(Input.GetMouseButtonUp(KeyCode.Mouse0))

		if(myTransform.position.x < -40) Destroy(gameObject); // Destroys the enemy after it goes beyond the screen to the left
	}
}
