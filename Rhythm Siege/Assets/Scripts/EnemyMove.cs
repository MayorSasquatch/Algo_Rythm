using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour {

	public float speed;

	private Transform myTransform;

	// Use this for initialization
	void Start () {
		//myTransform = transform;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position.Set(transform.position.x+speed, transform.position.y, transform.position.z);
	}
}
