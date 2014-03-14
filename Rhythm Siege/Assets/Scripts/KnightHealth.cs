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
}
