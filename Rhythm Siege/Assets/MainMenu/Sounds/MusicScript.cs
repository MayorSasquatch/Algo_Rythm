using UnityEngine;
using System.Collections;

public class MusicScript : MonoBehaviour {
	public static bool player;

	private static MusicScript instance = null;
	void Start()
	{
		player = true;
	}
	public static MusicScript Instance {
		get { return instance; }
	}
	void Awake() {
		if (instance != null && instance != this) {
			Destroy(this.gameObject);
			return;
		} else {
			instance = this;
		}
		DontDestroyOnLoad(this.gameObject);
	}
	void Update()
	{
		//if(!player)
			//Destroy (this.gameObject);
		if(!player)
		this.audio.volume = 0;
		if(player)
			this.audio.volume = 100;
	}
	// any other methods you need
}