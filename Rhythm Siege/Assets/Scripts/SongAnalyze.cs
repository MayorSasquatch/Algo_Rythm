using UnityEngine;
using System.Collections;
using System.IO;

public class SongAnalyze : MonoBehaviour {
	static int THRESHOLD_WINDOW_SIZE = 10;
	static float MULTIPLIER = 1.5f;

	bool done = false;
	//float[] samples = new float[1024];
	float[] spectrum = new float[1024];
	float[] lastSpectrum = new float[1024];
	ArrayList spectralFlux = new ArrayList( );
	ArrayList threshold = new ArrayList( );
	ArrayList prunnedSpectralFlux = new ArrayList();
	ArrayList peaks = new ArrayList();
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (this.audio.isPlaying)
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
			for( int i = 93; i < spectrum.Length; i++ )	
			{
				float value = (spectrum[i] - lastSpectrum[i]);
				flux[2] += value < 0? 0: value;
			}
			spectralFlux.Add(flux);

		}

		else if(done == false)
		{

			for( int i = 0; i < spectralFlux.Count; i++ )
			{
				float[] mean = {0,0,0};
				for(int a = 0; a<3; a++)
				{
					int start = Mathf.Max( 0, i - THRESHOLD_WINDOW_SIZE );
					int end = Mathf.Min( spectralFlux.Count - 1, i + THRESHOLD_WINDOW_SIZE );
					for( int j = start; j <= end; j++ ){
						float[]temp = (float[])spectralFlux[j];
						mean[a] +=  temp[a];}
					mean[a] /= (end - start);
					mean[a] *=  MULTIPLIER;
				}
				threshold.Add(mean);
			}


			for( int i = 0; i < threshold.Count; i++ )
			{
				float[] temp3 = {0,0,0};
				for(int a = 0; a<3; a++){
					float[] temp1 = (float[])threshold[i];
					float[] temp2 = (float[])spectralFlux[i];

					if( temp1[a] <=  temp2[a]){
						temp3[a] = ( temp2[a] - temp1[a] );
					}
					else{
						temp3[a] = ( (float)0 );
					}
				}
				prunnedSpectralFlux.Add(temp3);
			}
			threshold.Clear();

			for( int i = 0; i < prunnedSpectralFlux.Count - 1; i++ )
			{
				float[] temp3 = {0,0,0};
				for(int a = 0; a<3; a++){
					float[] temp1 = (float[])prunnedSpectralFlux[i];
					float[] temp2 = (float[])prunnedSpectralFlux[i+1];
					if( temp1[a] > temp2[a] ){
						temp3[a] = ( temp1[a]);}
					else {
						temp3[a]=( (float)0 );	}	
					}
				peaks.Add(temp3);
			}
			prunnedSpectralFlux.Clear();
			
			StreamWriter noteWriter = new StreamWriter(this.audio.clip.name);
			for( int i = 0; i < peaks.Count; i += 25 )
			{
				float rate = 1024f/44100f;
				float time = (float)i * rate;
				float[] temp = (float[])peaks[i];
				for(int a = 0; a<3;a++){

					if(temp[a] != 0 )
					{
						Debug.Log(time);
						noteWriter.WriteLine(time);
						//noteWriter.WriteLine((float)peaks[i]);
						noteWriter.WriteLine(a);
					}
				}
			}
			noteWriter.Close();
			done = true;
		}

	}
}
