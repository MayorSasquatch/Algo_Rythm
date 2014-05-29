using UnityEngine;
using System.Collections;

public class ChangeHammers : MonoBehaviour {
	public TextMesh hammerNumber;
	public TextMesh hammerPrice;

	public static int changeNum;
	// Use this for initialization
	void Start () {
	
	}
	void OnMouseDown(){
		print("PRESSIN BUTTONZ BITCHEZZZ!");
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

		hammerNumber.text = "" + (HammerPics.hammerNum+1);

		if(Options.getAxeValue(HammerPics.hammerNum) == 0)
			hammerPrice.text = "" + Purchase.price[HammerPics.hammerNum];
		else
			hammerPrice.text = "";
	}
}
