using UnityEngine;
using System.Collections;

public class Purchase : MonoBehaviour {
	public static int[] price;
	// Use this for initialization
	void Start () {
		price = new int[10];
		for(int a = 0; a < 10; ++a)
			price[a] = a * 100;
	}
	void OnMouseDown(){
		print ("BUY");
		PlayerPrefs.SetInt("HammerType", ChangeHammers.changeNum);
			/*
			 * set value of the hammer to 1 for unlock or 0 for lock;
			 * if(money == price)
			//PlayerPrefs.SetInt("Axe_Values " + HammerPics.hammerNum, 1); 
	*/
	}
	// Update is called once per frame

}
