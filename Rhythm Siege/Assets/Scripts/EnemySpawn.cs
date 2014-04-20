using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;


public class EnemySpawn : MonoBehaviour {
	 //name of text file to be read
	public float levelTime; //create a timer to track time across level
	float tempTime = 0;
	public GameObject[] enemies; //array of enemy prefabs
	ArrayList spawnTimes = new ArrayList() ; //arraylists for dynamic storing of spawning data such at time to spawn
	ArrayList spawnTypes = new ArrayList(); // and what type of enemy to spawn
	int nextNote = 0;// incrimentor for the spawn check


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
	int fluxIndex, thresholdIndex, prunnedIndex, peaksIndex = 0;
	int fluxindexlast = 0;
	// Use this for initialization
	void Start () {
		levelTime = 0f; 

		www = new WWW ("file://" + SongSelect.path);
		myAudioClip= www.audioClip;
		while (!myAudioClip.isReadyToPlay)

		gameObject.GetComponent<AudioSource> ().audio.clip = myAudioClip;
		this.audio.Play ();
	}

	// Update is called once per frame
	void Update () {
		levelTime += Time.deltaTime; //incriment timer to current time
		//start analysis code
		if (levelTime < this.audio.clip.length)
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

			if(spectralFlux.Count - fluxindexlast >= 10)
			{
				fluxindexlast = spectralFlux.Count;
				for( ; fluxIndex < spectralFlux.Count; fluxIndex++ )
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
				for( ; peaksIndex < peaks.Count; peaksIndex ++)
				{
					float rate = 1024f/AudioSettings.outputSampleRate;
					float time = (float)peaksIndex * rate;
					float[] temp = (float[])peaks[peaksIndex];

					if((temp[0] != 0 || temp[1] != 0 || temp[2] != 0) && (time - tempTime > 1) && time <= audio.clip.length)
					{
						spawnTimes.Add(time);
						Debug.Log (peaksIndex);
						Debug.Log (time);
						//noteWriter.WriteLine((float)peaks[i]);
						if(temp[0]>= temp[1] && temp[0]>= temp[2] ){spawnTypes.Add (0);}
						else if(temp[1]>= temp[0] && temp[1]>= temp[2] ){spawnTypes.Add (1);}
						else if(temp[2]>= temp[1] && temp[2]>= temp[0] ){spawnTypes.Add (2);}
						tempTime = time;
					}
				
				}
			}
			
		}
		// end analysis code
		//start spawn code
		if(levelTime >= 5){

			//float temp = (float)spawnTimes[nextNote];//retrieve time to check agaisnt

			if(levelTime - 5 >= (float)spawnTimes[nextNote])//check for time passing
			{
				GameObject clone;//if the time of the spawn has passed spawns an enemy from prefab
				clone = Instantiate(enemies[(int)spawnTypes[nextNote]], enemies[(int)spawnTypes[nextNote]].transform.position ,transform.rotation) as GameObject;
				nextNote++;// incriment index for next spawn check
			}
			
		}
	}
}