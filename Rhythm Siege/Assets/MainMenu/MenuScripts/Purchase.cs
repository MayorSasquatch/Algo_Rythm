using UnityEngine;
using System.Collections;

public class Purchase : MonoBehaviour {
	public static int[] price;
	public static int playerGold;
	public static int playerHammerNum;
	public AudioSource chaChing;
	public AudioSource chang;

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
		price[1] = 2000;
		price[2] = 4000;
		price[3] = 6000;
		price[4] = 8000;
		price[5] = 12000;
		price[6] = 16000;
		price[7] = 20000;
		price[8] = 25000;
		price[9] = 30000;


	}
	void OnMouseDown(){
		if(this.name == "Purchase_Button" && ChangeHammers.changeNum != 8)
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
				chaChing.Play ();
			}

		}
		if(this.name == "Equip_Button")
		{
		   print("Equip");
		   PlayerPrefs.SetInt("HammerType", ChangeHammers.changeNum);
		   playerHammerNum = ChangeHammers.changeNum;

		   chang.Play ();
		   
		}
			/*
			 * set value of the hammer to 1 for unlock or 0 for lock;
			 * if(money == price)
			//PlayerPrefs.SetInt("Axe_Values " + HammerPics.hammerNum, 1); 
	*/
	}
	// Update is called once per frame

}
