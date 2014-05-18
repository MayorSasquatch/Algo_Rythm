using UnityEngine;
using System.Collections;

public class ChangeHammers : MonoBehaviour {
	public TextMesh hammerNumber;
	public TextMesh hammerPrice;
	// Use this for initialization
	void Start () {
	
	}
	void OnMouseDown(){
			
			
			if(this.gameObject.name == "Left")
			{
				HammerPics.hammerNum--;
				if(HammerPics.hammerNum < 0)
					HammerPics.hammerNum = 0;
			}else if(this.gameObject.name == "Right")
			{
				HammerPics.hammerNum++;
				if(HammerPics.hammerNum > 9)
					HammerPics.hammerNum = 9;
			}
		//hammerNumber.text = "" + HammerPics.hammerNum;
		print (HammerPics.hammerNum);

	}
	// Update is called once per frame
	void Update () {

		hammerNumber.text = "" + (HammerPics.hammerNum+1);

		if(Options.getAxeValue(HammerPics.hammerNum) == 0)
			hammerPrice.text = "" + Purchase.price[HammerPics.hammerNum];
		else
			hammerPrice.text = "";
	}
}
