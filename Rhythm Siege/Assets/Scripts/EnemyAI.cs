using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {
	public int state; // 1: casting, 2: exhuasted, 3: recover
	public float moveSpeed;
	public string deathGesture;
	private Transform myTransform;
	public Vector3 startPos;
	void Awake(){
		myTransform = transform;
	}

	// Use this for initialization
	void Start () {
		state = 1;
		startPos = this.transform.position;
		//this.rigidbody2D.AddForce(new Vector2(-moveSpeed,0));
		if (this.name == "Wizard(Clone)") {
			this.rigidbody2D.AddForce(new Vector2(100,90));
				}
	}
	
	// Update is called once per frame
	void Update () {

		if (this.name == "Wizard(Clone)") {
			float vx = this.rigidbody2D.velocity.x;
			float vy = this.rigidbody2D.velocity.y;
			switch(state)
			{
			case 1:
				if(this.transform.position.x > 13){this.rigidbody2D.velocity = new Vector2(0,vy); this.rigidbody2D.AddForce(new Vector2(-100,0));}
				if(this.transform.position.x < 5){this.rigidbody2D.velocity = new Vector2(0,vy); this.rigidbody2D.AddForce(new Vector2(100,0));}
				if(this.transform.position.y > 8){this.rigidbody2D.velocity = new Vector2(vx,0); this.rigidbody2D.AddForce(new Vector2(0,-100));}
				if(this.transform.position.y < 0){this.rigidbody2D.velocity = new Vector2(vx,0); this.rigidbody2D.AddForce(new Vector2(0,100));}
				break;
			case 2:
				Vector2 a = (new Vector2(-22,2) - (Vector2)this.transform.position);
				a = a/.02f/3;
				a.y = 0;
				this.rigidbody2D.AddForce(a);
				state = 3;
				break;
			case 3:
				if(this.transform.position.y > 8){this.rigidbody2D.velocity = new Vector2(vx,0); this.rigidbody2D.AddForce(new Vector2(0,-100));}
				if(this.transform.position.y < 0){this.rigidbody2D.velocity = new Vector2(vx,0); this.rigidbody2D.AddForce(new Vector2(0,100));}
				if(this.transform.position.x <-22f){this.rigidbody2D.velocity = new Vector2(0,vy); this.rigidbody2D.AddForce(new Vector2(300,0));}
				if(this.transform.position.x > 13f){this.rigidbody2D.velocity = new Vector2(0,vy); state = 1;}
				break;
			}

			
		}


		// Move towards target
		//myTransform.position -= myTransform.right * moveSpeed * Time.deltaTime;


		//if(Input.GetMouseButtonUp(KeyCode.Mouse0))

		if (myTransform.position.x < -40) {
			this.rigidbody2D.velocity = new Vector2(0,0);
			this.transform.position = startPos;
				}; // Destroys the enemy after it goes beyond the screen to the left
	}
}
