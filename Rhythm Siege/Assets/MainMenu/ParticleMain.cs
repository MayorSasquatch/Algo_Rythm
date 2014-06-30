using UnityEngine;
using System.Collections;

public class ParticleMain : MonoBehaviour {
	public Texture[] spriteTypes;
	public Texture notOwned;
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
		hammNum = HammerPics.hammerNum;
		if(Options.getAxeValue(HammerPics.hammerNum) == 0)
			mat.mainTexture = notOwned;
		else 
			mat.mainTexture = spriteTypes[hammNum];
	}
}
