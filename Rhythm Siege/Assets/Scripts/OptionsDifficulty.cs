using UnityEngine;
using System.Collections;

public class OptionsDifficulty : MonoBehaviour {

	public float difficulty;
	public Texture[] tex;
	static float curDiff = PlayerPrefs.GetFloat("Difficulty");

	void OnMouseDown(){
		PlayerPrefs.SetFloat("Difficulty", difficulty);
		curDiff = difficulty;
		Debug.Log("Set difficulty to " + difficulty);
	}

	void Update(){
		if(curDiff == difficulty)
			renderer.material.SetTexture("_MainTex", tex[1]);
		else renderer.material.SetTexture("_MainTex", tex[0]);
	}
}
