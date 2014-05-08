using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {
	
	public float moveSpeed;
	public string deathGesture;
	private Transform myTransform;

	void Awake(){
		myTransform = transform;
	}

	// Use this for initialization
	void Start () {
		this.rigidbody2D.AddForce(new Vector2(-moveSpeed,0));
	}
	
	// Update is called once per frame
	void Update () {

		// Move towards target
		//myTransform.position -= myTransform.right * moveSpeed * Time.deltaTime;


		//if(Input.GetMouseButtonUp(KeyCode.Mouse0))

		if(myTransform.position.x < -40) Destroy(gameObject); // Destroys the enemy after it goes beyond the screen to the left
	}
}
