using UnityEngine;
using System.Collections;

public class SpawnLightning : MonoBehaviour {

	public int maxSpawnTime;
	public int minSpawnTime;
	bool isactive;
	int frequency;
	float time;
	void Start () {
		isactive = false;
		frequency = Random.Range (1, 5);
		time = 0;
	}

	void Update(){
		time += Time.deltaTime;
		if (time > frequency && isactive == false) {
			this.renderer.enabled = true;
			isactive = true;
			time = 0;
		}
		if (time > .1f && isactive == true) {
			this.renderer.enabled = false;
			isactive = false;
			time = 0;
				}
		}

	// Update is called once per frame


}
