using UnityEngine;
using System.Collections;

public class ParticleScript : MonoBehaviour {
	public Texture[] spriteTypes;
	public ParticleSystem pSys;

	int hammNum;

	Deathbox d;
	Material mat;
	// Use this for initialization
	void Start () {
		d = GameObject.Find("Deathbox").GetComponent<Deathbox>();


		hammNum = PlayerPrefs.GetInt("HammerType");
		mat = this.GetComponent<ParticleSystemRenderer>().material;

		mat.mainTexture = spriteTypes[hammNum];
		//pSys.Play();
	}
	
	// Update is called once per frame
	void Update () {

		if(d.getMulti() == 10)
			pSys.Play ();
		if(d.getMulti() < 10)
			pSys.Stop();
			

	}
}
