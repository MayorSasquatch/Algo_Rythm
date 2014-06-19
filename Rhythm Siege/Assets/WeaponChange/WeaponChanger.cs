using UnityEngine;
using System.Collections;

public class WeaponChanger : MonoBehaviour {
	
	public Sprite[] hammerTypes;
	
	//public int hammerNum = ChangeHammers.changeNum;
	public int hammerNum;

	public Sprite testSprite;
	SpriteRenderer sr;
	// Use this for initialization
	void Start () {

		hammerNum  = PlayerPrefs.GetInt ("HammerType");
		print ("Weapon Change" + hammerNum);
		sr = this.GetComponent<SpriteRenderer>();
		sr.sprite = hammerTypes[hammerNum];
		//this.GetComponent<SpriteRenderer> ().sprite = testSprite;
	}
	
	// Update is called once per frame
	void Update () {
		//sr.sprite = hammerTypes[hammerNum];
		//this.GetComponent<SpriteRenderer> ().sprite = hammerTypes [hammerNum];
		//this.GetComponent<SpriteRenderer> ().sprite = testSprite;
	}
}