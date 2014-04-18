using UnityEngine;
using System.Collections;
using System.IO;

public class SongAnalyze : MonoBehaviour {

	// Use this for initialization
	void Start () {

		WWW www = new WWW ("file://" + SongSelect.path);
		
		AudioClip myAudioClip= www.audioClip;
		while (!myAudioClip.isReadyToPlay)
		gameObject.GetComponent<AudioSource> ().audio.clip = myAudioClip;

		this.audio.PlayDelayed(12.377057f);
	}
	
	// Update is called once per frame
	void Update () {
		}
	
}
