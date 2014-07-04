using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {
	public float speed;
	Vector2 offsetNum = new Vector2(1f,0);
	// Use this for initialization
	void Start () {
		//InvokeRepeating("resetOffset", 0f, 3f);
	}
	void resetOffset()
	{
		renderer.material.mainTextureOffset = new Vector2(0, 0f);
	}
	// Update is called once per frame
	void Update () {
		if(renderer.material.mainTextureOffset.x > 1)
			renderer.material.mainTextureOffset = new Vector2(0, 0f);
		renderer.material.mainTextureOffset += new Vector2(speed*Time.deltaTime, 0f);
	}
	public void speedchange(float s){speed = s;}
}
