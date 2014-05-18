using UnityEngine;
using System.Collections;

public class Options : MonoBehaviour {

	public static int[] playerAxeValues;
	// Use this for initialization
	void Start () {
		playerAxeValues = new int[10];

		print ("options spawn");
		if(PlayerPrefs.GetInt("Started") == 0)
		{
			PlayerPrefs.SetInt("Started", 0);
			for(int i = 0; i < 10; ++i)
			{
				PlayerPrefs.SetInt("Axe_Values " + i, 0);

			}
		}
	
		setAxeValues();
		playerAxeValues[0] = 1;
		print(playerAxeValues[6]);

	}

	public void setAxeValues() {
		for(int a = 0; a < 10; ++a)
		{
			playerAxeValues[a] = PlayerPrefs.GetInt("Axe_Values " + a);
		}
	}

	public static int getAxeValue(int index)
	{
		int b;
		b = playerAxeValues[index];
		return b;
	}
	// Update is called once per frame
}
