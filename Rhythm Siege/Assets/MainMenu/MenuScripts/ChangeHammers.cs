﻿using UnityEngine;
using System.Collections;

public class ChangeHammers : MonoBehaviour {
	public TextMesh hammerNumber;
	public TextMesh hammerPrice;
	public TextMesh playerGold;

	public GameObject equipHold;
	public GameObject purchaseHold;
	public GameObject selectHold;
	public GameObject priceHoldStuff;


	public static int changeNum;
	// Use this for initialization
	void Start () {

	
	}
	void OnMouseDown(){
		print (Options.getAxeValue(HammerPics.hammerNum));
			if(this.gameObject.name == "Left_Button")
			{
				HammerPics.hammerNum--;
				if(HammerPics.hammerNum < 0)
					HammerPics.hammerNum = 0;
			}else if(this.gameObject.name == "Right_Button")
			{
				HammerPics.hammerNum++;
				if(HammerPics.hammerNum > 9)
					HammerPics.hammerNum = 9;
			}
		//hammerNumber.text = "" + HammerPics.hammerNum;
		changeNum = HammerPics.hammerNum;
		//print (HammerPics.hammerNum);

	}
	// Update is called once per frame
	void Update () {
		playerGold.text = "" + Purchase.playerGold;
		hammerNumber.text = "" + (HammerPics.hammerNum+1);

		if(Options.getAxeValue(HammerPics.hammerNum) == 0)
		{
			selectHold.SetActive(false);
			purchaseHold.SetActive(true);
			equipHold.SetActive(false);
			priceHoldStuff.SetActive(true);
			hammerPrice.text = "" + Purchase.price[HammerPics.hammerNum];

		}
		else
		{
			purchaseHold.SetActive(false);
			equipHold.SetActive(true);
			priceHoldStuff.SetActive(false);
			if(HammerPics.hammerNum == Purchase.playerHammerNum)
				selectHold.SetActive(true);
			else 
				selectHold.SetActive(false);
			hammerPrice.text = "" + (HammerPics.hammerNum + 1);

		}
	}
}
