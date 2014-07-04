using UnityEngine;
using System.Collections;

public class AlphaFader : MonoBehaviour {
	public static int hp = 12;
	SpriteRenderer sr;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown ("up"))
		{

			if(hp > 9 && this.gameObject.tag == "Green")
			{
				renderer.material.color -= new Color(1,1,1,.33f);
				--hp;
			}
			else if(hp > 6 && hp < 10 && this.gameObject.tag == "Yellow")
			{
				renderer.material.color -= new Color(1,1,1,.33f);
				--hp;
			}
			/*
			else if(hp > 3 && hp < 7 && this.gameObject.tag == "Red")
			{
				renderer.material.color -= new Color(1,1,1,.33f);
				--hp;
			}
*/

		}
		if(Input.GetKeyDown("down"))
		{
			hp = 12;
			renderer.material.color = new Color (1, 1, 1, 1);
		}
	}
}
