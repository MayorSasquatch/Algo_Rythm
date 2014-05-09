using UnityEngine;
using System.Collections;

public class Lightning : MonoBehaviour {

	public float lifeSeconds;
	
	// Update is called once per frame
	void Update () {

		if(lifeSeconds <= 0) Destroy(gameObject);

		lifeSeconds -= Time.deltaTime;
	}
}
