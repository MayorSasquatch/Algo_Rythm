using UnityEngine;
using System.Collections;

public class Purchase : MonoBehaviour {
	public static int[] price;
	public static int playerGold;
	public static int playerHammerNum;
	// Use this for initialization
	void Start () {
		playerGold = PlayerPrefs.GetInt("Currency"); //change to player gold value
		playerHammerNum = PlayerPrefs.GetInt ("HammerType");
		price = new int[10];
		/*
		for(int a = 0; a < 10; ++a)
			price[a] = a * 100;
	*/
		price[0] = 0;
		price[1] = 200;
		price[2] = 400;
		price[3] = 600;
		price[4] = 800;
		price[5] = 1200;
		price[6] = 1600;
		price[7] = 2000;
		price[8] = 2500;
		price[9] = 3000;


	}
	void OnMouseDown(){
		if(this.name == "Purchase_Button")
		{
			print("Purchase");
			if(playerGold >= price[ChangeHammers.changeNum])
			{
				print ("Bought");
				//PlayerPrefs.SetInt("HammerType", ChangeHammers.changeNum);
				PlayerPrefs.SetInt("Axe_Values " + HammerPics.hammerNum, 1);
				Options.playerAxeValues[ChangeHammers.changeNum] = 1;
				playerGold -= price[ChangeHammers.changeNum];
				PlayerPrefs.SetInt("Currency", playerGold);
			}
		}
		if(this.name == "Equip_Button")
		{
		   print("Equip");
		   PlayerPrefs.SetInt("HammerType", ChangeHammers.changeNum);
		   playerHammerNum = ChangeHammers.changeNum;
		}
			/*
			 * set value of the hammer to 1 for unlock or 0 for lock;
			 * if(money == price)
			//PlayerPrefs.SetInt("Axe_Values " + HammerPics.hammerNum, 1); 
	*/
	}
	// Update is called once per frame

}
