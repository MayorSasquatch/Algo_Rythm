using UnityEngine;
using System.Collections;

public class ChartBoostKeeper : MonoBehaviour {
	public static bool player;
	
	private static ChartBoostKeeper instance = null;
	void Start()
	{
		player = true;
	}
	public static ChartBoostKeeper Instance {
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
}
