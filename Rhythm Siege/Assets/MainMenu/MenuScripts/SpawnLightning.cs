using UnityEngine;
using System.Collections;

public class SpawnLightning : MonoBehaviour {

	public int maxSpawnTime;
	public int minSpawnTime;
	void Start () {
		InvokeRepeating ("ShowLightning", Random.Range(1,5), Random.Range(minSpawnTime,maxSpawnTime));
	}
	IEnumerator Hide(){
		yield return new WaitForSeconds(.1f);
		this.renderer.enabled = false;
	}
	void ShowLightning(){

		this.renderer.enabled = true;
		StartCoroutine(Hide ());
	}
	// Update is called once per frame
	
}
