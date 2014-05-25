using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;


public class EnemySpawn : MonoBehaviour {
	 //name of text file to be read
	public float levelTime; //create a timer to track time across level
	float tempTime = 0;
	public GameObject[] enemies; //array of enemy prefabs
	GameObject[,] enemyCache = new GameObject[3,6];
	ArrayList spawnTimes = new ArrayList() ; //arraylists for dynamic storing of spawning data such at time to spawn
	ArrayList spawnTypes = new ArrayList(); // and what type of enemy to spawn
	int nextNote = 0;// incrimentor for the spawn check
	float[] Wiztimes = new float[]{10f, 20f, 40f, 60f, 90f, 120f};
	int wizIndex = 0;

	WWW www ;
	AudioClip myAudioClip;
	//analysis variables
	static int THRESHOLD_WINDOW_SIZE = 10;
	static float MULTIPLIER = 1.5f;
	//float[] samples = new float[1024];
	float[] spectrum = new float[1024];
	float[] lastSpectrum = new float[1024];
	ArrayList spectralFlux = new ArrayList( );
	ArrayList threshold = new ArrayList( );
	ArrayList prunnedSpectralFlux = new ArrayList();
	ArrayList peaks = new ArrayList();
	int fluxIndex, thresholdIndex, prunnedIndex, peaksIndex, timeIndex = 0;
	int lowCount, midCount = 0;
	// Use this for initialization
	void Start () {
		levelTime = 0f; 

		for(int b= 0; b<6;b++){
			enemyCache[0,b] = Instantiate(enemies[0], enemies[0].transform.position + new Vector3(30*b,0,0),transform.rotation) as GameObject;
			enemyCache[1,b] = Instantiate(enemies[1], enemies[1].transform.position + new Vector3(30*b,0,0),transform.rotation) as GameObject;
			enemyCache[2,b] = Instantiate(enemies[2], enemies[2].transform.position + new Vector3(30*b,0,0),transform.rotation) as GameObject;
		}
		if (MainMenu.boss) {Instantiate(Resources.Load("Wizard"));}
		if(MainMenu.tutorial){
			Instantiate(Resources.Load("TutorialText"));
			spawnTimes.Add(4f);
			spawnTypes.Add(0);

			spawnTimes.Add(8f);
			spawnTypes.Add(1);

			spawnTimes.Add(12f);
			spawnTypes.Add(2);
		}

		gameObject.GetComponent<AudioSource> ().audio.clip = MainMenu.song;
		this.audio.Play ();
	}

	// Update is called once per frame
	void Update () {
		levelTime += Time.deltaTime; //incriment timer to current time
		//start analysis code
		if (levelTime < this.audio.clip.length && Time.timeScale != 0 && !MainMenu.tutorial)
		{
			spectrum.CopyTo(lastSpectrum, 0);
			this.audio.GetSpectrumData (spectrum, 0, FFTWindow.Hamming);
			
			float[] flux = {0,0,0};
			for( int i = 0; i < 11; i++ )	
			{
				float value = (spectrum[i] - lastSpectrum[i]);
				flux[0] += value < 0? 0: value;
			}
			for( int i = 11; i < 93 ; i++ )	
			{
				float value = (spectrum[i] - lastSpectrum[i]);
				flux[1] += value < 0? 0: value;
			}
			for( int i = 93; i < 512; i++ )	
			{
				float value = (spectrum[i] - lastSpectrum[i]);
				flux[2] += value < 0? 0: value;
			}
			spectralFlux.Add(flux);

			if(spectralFlux.Count >= 21)
			{
				Threshold();

				PruneFlux();

				Peaks();

				WriteNotes();
			}
			//Debug.Log (spectralFlux.Count+" "+ threshold.Count+" "+prunnedSpectralFlux.Count+" "+peaks.Count);
			
		}
		// end analysis code
		//start spawn code
		if(levelTime >= 5 && GameObject.Find("PlayMenu") != null){ Destroy(GameObject.Find("PlayMenu"));}
		if(levelTime >= 5 && nextNote < spawnTimes.Count){
			//float temp = (float)spawnTimes[nextNote];//retrieve time to check agaisnt
			if(levelTime - 5 >= (float)spawnTimes[nextNote])//check for time passing
			{
				if(MainMenu.boss && levelTime - 5 >= Wiztimes[wizIndex]){
					GameObject.Find ("Wizard(Clone)").GetComponent<EnemyAI>().state  = 2;
					wizIndex++;
				}
				else {Spawn();}
				//GameObject clone;//if the time of the spawn has passed spawns an enemy from prefab
				//clone = Instantiate(enemies[(int)spawnTypes[nextNote]], enemies[(int)spawnTypes[nextNote]].transform.position ,transform.rotation) as GameObject;
				nextNote++;// incriment index for next spawn check
			}
			
		}
	}

	void Threshold(){
		for( ; fluxIndex < 11; fluxIndex++ )
		{
			float[] mean = {0,0,0};
			for(int a = 0; a<3; a++)
			{
				int start = Mathf.Max( 0, fluxIndex - THRESHOLD_WINDOW_SIZE );
				int end = Mathf.Min( spectralFlux.Count - 1, fluxIndex + THRESHOLD_WINDOW_SIZE );
				for( int j = start; j <= end; j++ ){
					float[]temp = (float[])spectralFlux[j];
					mean[a] +=  temp[a];}
				mean[a] /= (end - start);
				mean[a] *=  MULTIPLIER;
			}
			threshold.Add(mean);
		}
		fluxIndex--;
	}

	void PruneFlux(){
		for( ; thresholdIndex < threshold.Count; thresholdIndex++ )
		{
			float[] temp3 = {0,0,0};
			for(int a = 0; a<3; a++){
				float[] temp1 = (float[])threshold[thresholdIndex];
				float[] temp2 = (float[])spectralFlux[thresholdIndex];
				
				if( temp1[a] <=  temp2[a]){
					temp3[a] = ( temp2[a] - temp1[a] );
				}
				else{
					temp3[a] = ( (float)0 );
				}
			}
			prunnedSpectralFlux.Add(temp3);
		}
		thresholdIndex--;
		threshold.RemoveAt(0);
		spectralFlux.RemoveAt(0);
	}
	void Peaks(){
		for( ; prunnedIndex < prunnedSpectralFlux.Count - 1; prunnedIndex++ )
		{
			float[] temp3 = {0,0,0};
			for(int a = 0; a<3; a++){
				float[] temp1 = (float[])prunnedSpectralFlux[prunnedIndex];
				float[] temp2 = (float[])prunnedSpectralFlux[prunnedIndex+1];
				if( temp1[a] > temp2[a] ){
					temp3[a] = ( temp1[a]);}
				else {
					temp3[a]=( (float)0 );	}	
			}
			peaks.Add(temp3);
		}
		prunnedIndex--;
		prunnedSpectralFlux.RemoveAt (0);
	}
	void WriteNotes(){
		for( ; peaksIndex < peaks.Count; peaksIndex ++)
		{
			float rate = 1024f/AudioSettings.outputSampleRate;
			float time = (float)timeIndex * rate;
			float[] temp = (float[])peaks[peaksIndex];
			
			if((temp[0] != 0 || temp[1] != 0 || temp[2] != 0) && (time - tempTime > 1f) && time <= audio.clip.length)
			{
				spawnTimes.Add(time);
				//noteWriter.WriteLine((float)peaks[i]);
				if((temp[2]>= temp[1] && temp[2]>= temp[0])&& lowCount < 4 ){spawnTypes.Add (2); lowCount++; midCount =  0;}
				else if((temp[1]>= temp[0])&& midCount < 4 ){spawnTypes.Add (1); midCount++; lowCount =  0;}
				else {spawnTypes.Add (0); lowCount = midCount = 0;}
				tempTime = time;
			}
			timeIndex++;
		}
		peaksIndex--;
		peaks.RemoveAt(0);
	}

	void Spawn(){
		for (int a = 0; a<6; a++) {
			if(enemyCache[(int)spawnTypes[nextNote],a].rigidbody2D.velocity.x == 0f){
				enemyCache[(int)spawnTypes[nextNote],a].transform.position = enemies[(int)spawnTypes[nextNote]].transform.position;
				enemyCache[(int)spawnTypes[nextNote],a].rigidbody2D.AddForce(new Vector2(-708.3333f,0));
				return;
			}
		}
	}

}