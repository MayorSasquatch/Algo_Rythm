using UnityEngine;
using System.Collections;

public class FadeToBlack : MonoBehaviour {
	public static bool isFade;
	public Texture blackTexture;
	public float alphaFadeValue = 1f;
	bool t =  false;
	int num = 0;
	void Start(){
		isFade = false;
	}
	IEnumerator StopFade() {
		t = true;
		num++;
		yield return new WaitForSeconds(1);
		t = false;
	}
	void OnGUI(){
		if(isFade)
		{
		alphaFadeValue -= Mathf.Clamp01(Time.deltaTime / 3);
		
		GUI.color = new Color(0, 0, 0, alphaFadeValue);
		GUI.DrawTexture( new Rect(0, 0, Screen.width, Screen.height ), blackTexture );
		}
	}
	void Update() { 
		if(isFade)
		{
			if(num == 5) {
				this.enabled = false;
			}
			if(t == false) { 
				StartCoroutine(StopFade());
			}
		}
	}
}