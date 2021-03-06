using UnityEngine;
using System.Collections;

public class HammerPics : MonoBehaviour {

	public Sprite[] hammerTypes;
	public Sprite qMark;
	public static int hammerNum;


	private int s;
	public GameObject selectHold;
	SpriteRenderer sr;
	// Use this for initialization
	void Start () {


		hammerNum  = PlayerPrefs.GetInt ("HammerType");

		if(hammerNum == Purchase.playerHammerNum)
			selectHold.SetActive(true);
		else 
			selectHold.SetActive(false);
		if(PlayerPrefs.GetInt("Started") == 0)
			//print ("=0haha");
		PlayerPrefs.SetInt("Started", 1);
	
		//hammerNum = 0;
		sr = gameObject.GetComponent<SpriteRenderer>();
		sr.sprite = hammerTypes[hammerNum];
	}
	
	// Update is called once per frame
	void Update () {
		if(hammerNum == Purchase.playerHammerNum)
			selectHold.SetActive(true);
		else 
			selectHold.SetActive(false);
		if(Options.getAxeValue(hammerNum) == 0)
		   	sr.sprite = qMark;
		else
			sr.sprite = hammerTypes[hammerNum];
	}
}