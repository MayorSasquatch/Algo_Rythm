using UnityEngine;
using System.Collections;

public class ParticleScript : MonoBehaviour {
	public Texture[] spriteTypes;
	public ParticleSystem pSys;

	int hammNum;

	Material mat;
	// Use this for initialization
	void Start () {
		hammNum = PlayerPrefs.GetInt("HammerType");
		mat = this.GetComponent<ParticleSystemRenderer>().material;

		mat.mainTexture = spriteTypes[hammNum];
		//pSys.Play();
	}
	
	// Update is called once per frame
	void Update () {


			

	}
}
