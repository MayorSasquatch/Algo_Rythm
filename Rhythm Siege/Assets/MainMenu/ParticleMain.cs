using UnityEngine;
using System.Collections;

public class ParticleMain : MonoBehaviour {
	public Texture[] spriteTypes;
	public ParticleSystem pSys;
	
	int hammNum;
	
	Material mat;
	// Use this for initialization
	void Start () {
		hammNum = ChangeHammers.changeNum;
		mat = this.GetComponent<ParticleSystemRenderer>().material;
		
		mat.mainTexture = spriteTypes[hammNum];
		//pSys.Play();
	}
	
	// Update is called once per frame
	void Update () {
		hammNum = ChangeHammers.changeNum;
		mat.mainTexture = spriteTypes[hammNum];
		
	}
}
