using UnityEngine;
using System.Collections;

public class MenuWeather : MonoBehaviour {

	public GameObject cloudPrefab;
	public GameObject lightningPrefab;
	float lTimer;	// Timer to determine when to spawn next lightning
	float cTimer;	// Timer to determine when to spawn the next cloud

	// Use this for initialization
	void Start () {
		lTimer = Random.Range(5.0F, 11.0F);
		cTimer = 1.0F;
	}
	
	// Update is called once per frame
	void Update () {

		// Spawns a cloud when the timer reaches 0
		if(cTimer <= 0){
			Instantiate(cloudPrefab, new Vector3(13.0F, 2.2F, 250.0F), Quaternion.identity);
			cTimer = Random.Range(10.0F, 20.0F);
		}

		// Spawns a lightning bolt when the timer reaches 0
		if(lTimer <= 0){
			Instantiate(lightningPrefab, new Vector3(Random.Range(-0.5F, 8.0F),1.8F, 275.0F), Quaternion.identity);
			lTimer = Random.Range(8.0F, 13.0F);
		}

		lTimer -= Time.deltaTime;
		cTimer -= Time.deltaTime;
	}
}
