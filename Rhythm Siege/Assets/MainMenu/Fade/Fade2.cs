using UnityEngine;
using System.Collections;

public class Fade2 : MonoBehaviour {
	Component[] fades;
	// Use this for initialization
	void Start () {
		//renderer.material.color = new Color(1,1,1,0f);
		fades = GetComponentsInChildren<Renderer>();
		foreach (Renderer r in fades){
			r.material.color = new Color(1,1,1,0f);
		}
	}
	
	// Update is called once per frame
	void Update () {
			//renderer.material.color  += new Color (0, 0, 0, .009f);
		fades = GetComponentsInChildren<Renderer>();
		foreach (Renderer r in fades){
			if(r.material.color.a < 1)
			r.material.color += new Color(0,0,0,.009f);
		}
	}
}
