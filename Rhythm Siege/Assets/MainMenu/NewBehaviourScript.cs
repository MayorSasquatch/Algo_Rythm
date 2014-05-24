using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {
	public float speed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		renderer.material.mainTextureOffset += new Vector2(speed/2/2/2/2, 0f);
	}
}
