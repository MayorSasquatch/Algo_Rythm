using UnityEngine;
using System.Collections;

public class FadeOut : MonoBehaviour {
	Component[] fades;

	bool done;
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this);
		Application.LoadLevel("RS");
		done = false;
		//renderer.material.color = new Color(1,1,1,0f);
		fades = GetComponentsInChildren<Renderer>();
		foreach (Renderer r in fades){
			r.material.color = new Color(1,1,1,1f);
		}
	}
	void FadeOutTime()
	{
		fades = GetComponentsInChildren<Renderer>();
		foreach (Renderer r in fades){
			if(r.material.color.a > 0)
				r.material.color -= new Color(0,0,0,.02f);
			
			
		}

	}
	// Update is called once per frame
	void Update () {
		//renderer.material.color  += new Color (0, 0, 0, .009f);
		/*
		fades = GetComponentsInChildren<Renderer>();
		foreach (Renderer r in fades){
			if(r.material.color.a > 0)
				r.material.color -= new Color(0,0,0,.005f);

		
		}
			*/
		Invoke("FadeOutTime", 1f);
		//if(done == true)
			//Application.LoadLevel("RS");
	}
}
