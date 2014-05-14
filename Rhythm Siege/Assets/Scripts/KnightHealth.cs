using UnityEngine;
using System.Collections;

public class KnightHealth : MonoBehaviour {


	public float curHealth;
	public float maxHealth;
	public float hitCooldown;

	private float hitTime;

	// Use this for initialization
	void Start () {
		hitTime = 0;

	}
	
	// Update is called once per frame
	void Update () {
		GameObject.Find ("Health").transform.localScale = new Vector3(1.812499f,3f*curHealth,1f);
	}

	void AdjustHealth(float adj){

		if(adj > 0) curHealth += adj;
		else {
			if(Time.time - hitTime > hitCooldown){
				curHealth += adj;
				hitTime = Time.time;
			}
		}

		if(curHealth > maxHealth) curHealth = maxHealth;
		if(curHealth < 0) curHealth = 0;
	}

	void OnTriggerEnter2D(Collider2D hit){
		//Debug.Log("Hit");
		if(hit.gameObject.tag == "Enemy") AdjustHealth(-1); // If the player is hit by an enemy, lose health
	}
}
