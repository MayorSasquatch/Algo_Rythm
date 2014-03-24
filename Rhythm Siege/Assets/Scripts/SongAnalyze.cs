using UnityEngine;
using System.Collections;
using System.IO;

public class SongAnalyze : MonoBehaviour {
	static int THRESHOLD_WINDOW_SIZE = 10;
	static float MULTIPLIER = 1.5f;

	bool done = false;
	float[] samples = new float[1024];
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
			this.audio.GetSpectrumData (samples, 0, FFTWindow.Hamming);
			spectrum.CopyTo(lastSpectrum, 0);
			samples.CopyTo(spectrum, 0);

			float flux = 0;
			for( int i = 0; i < spectrum.Length; i++ )	
			{
				float value = (spectrum[i] - lastSpectrum[i]);
				flux += value < 0? 0: value;
			}
			spectralFlux.Add(flux);
		}

		else if(done == false)
		{
			for( int i = 0; i < spectralFlux.Count; i++ )
			{
				int start = Mathf.Max( 0, i - THRESHOLD_WINDOW_SIZE );
				int end = Mathf.Min( spectralFlux.Count - 1, i + THRESHOLD_WINDOW_SIZE );
				float mean = 0;
				for( int j = start; j <= end; j++ )
				mean +=  (float)spectralFlux[j];
				mean /= (end - start);
				threshold.Add( mean * MULTIPLIER );
			}

			for( int i = 0; i < threshold.Count; i++ )
			{
				if( (float)threshold[i] <=  (float)spectralFlux[i]){
					prunnedSpectralFlux.Add( (float)spectralFlux[i] - (float)threshold[i] );
				}
				else{
					prunnedSpectralFlux.Add( (float)0 );
				}
			}
			threshold.Clear();
			for( int i = 0; i < prunnedSpectralFlux.Count - 1; i++ )
			{
				if( (float)prunnedSpectralFlux[i] > (float)prunnedSpectralFlux[i+1] ){
					peaks.Add( (float)prunnedSpectralFlux[i]);}
				else {
					peaks.Add( (float)0 );	}			
			}
			prunnedSpectralFlux.Clear();

			StreamWriter noteWriter = new StreamWriter(this.audio.clip.name);
			for( int i = 0; i < peaks.Count; i += 5 )
			{
				float rate = 1024f/44100f;
				float time = (float)i * rate;
				if((float)peaks[i] != 0 )
				{
					Debug.Log(time);
					noteWriter.WriteLine(time);
					//noteWriter.WriteLine((float)peaks[i]);
					noteWriter.WriteLine("0");
				}
			}
			noteWriter.Close();
			done = true;
		}

	}
}
