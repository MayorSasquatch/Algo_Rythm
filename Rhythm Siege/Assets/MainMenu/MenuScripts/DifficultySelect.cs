
using UnityEngine;
using System.Collections;

public class DifficultySelect : MonoBehaviour {
	public  GameObject easySkull, mediumSkull, hardSkull;
	public static float difficulty;
	public static float diffNum;

	public AudioSource swoosh;
	// Use this for initialization
	void Start () {
		difficulty = MainMenu.difficulty - 1;

		if(difficulty == 0f)
		{
			easySkull.SetActive(true);
			mediumSkull.SetActive(false);
			hardSkull.SetActive(false);
			diffNum = 1.0f;
		}
		else if(difficulty == 1f)
		{
			easySkull.SetActive(false);
			mediumSkull.SetActive(true);
			hardSkull.SetActive(false);
			diffNum = 2.0f;
		}
		else if(difficulty == 2f)
		{
			easySkull.SetActive(false);
			mediumSkull.SetActive(false);
			hardSkull.SetActive(true);
			diffNum = 3.0f;
		}
		PlayerPrefs.SetFloat("Difficulty", diffNum);
	}
	void OnMouseDown(){
		if(this.gameObject.name == "Easy_Setting")
		{

			difficulty = 0f;
			diffNum = 1.0f;
		}
		if(this.gameObject.name == "Medium_Setting")
		{

			difficulty = 1f;
			diffNum = 2.0f;
		}
		if(this.gameObject.name == "Hard_Setting")
		{

			difficulty = 2f;
			diffNum = 3.0f;
		}
		PlayerPrefs.SetFloat("Difficulty", diffNum);
		if(difficulty == 0)
		{
			swoosh.Play();
			easySkull.SetActive(true);
			mediumSkull.SetActive(false);
			hardSkull.SetActive(false);
		}
		else if(difficulty == 1)
		{
			swoosh.Play();
			easySkull.SetActive(false);
			mediumSkull.SetActive(true);
			hardSkull.SetActive(false);
		}
		else if(difficulty == 2)
		{
			swoosh.Play();
			easySkull.SetActive(false);
			mediumSkull.SetActive(false);
			hardSkull.SetActive(true);
		}
	}
	// Update is called once per frame

}
