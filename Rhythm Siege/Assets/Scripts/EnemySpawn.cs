using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;


public class EnemySpawn : MonoBehaviour {
	public string fileName; //name of text file to be read
	public float levelTime; //create a timer to track time across level
	public GameObject[] enemies; //array of enemy prefabs
	ArrayList spawnTimes; //arraylists for dynamic storing of spawning data such at time to spawn
	ArrayList spawnTypes; // and what type of enemy to spawn
	int nextNote = 0;// incrimentor for the spawn check


	// Use this for initialization
	void Start () {
		levelTime = 0f; 
		//string fileName = "level1.txt";

		spawnTimes = new ArrayList(); // create list to store spawn values
		spawnTypes = new ArrayList();

		string line; // begin reading in text file to parse
		StreamReader noteReader = new StreamReader(fileName, Encoding.Default);
		using (noteReader)
		{
			// While there's lines left in the text file, do this:
			do
			{
				line = noteReader.ReadLine();// read next text line
				
				if (line != null)
				{
					spawnTimes.Add(float.Parse (line));//parse line to float and store in array
					line = noteReader.ReadLine(); //read next line to get enemy type value
					spawnTypes.Add(int.Parse(line));//parse enemy type to int and store 
				}
			}
			while(line!= null);
			// Done reading, close the reader and return true to broadcast success    
			noteReader.Close();// end file io
		}
	}
	
	// Update is called once per frame
	void Update () {
		levelTime += Time.deltaTime; //incriment timer to current time
		float temp = (float)spawnTimes[nextNote];//retrieve time to check agaisnt
		if(levelTime > temp)//check for time passing
		{
			GameObject clone;//if the time of the spawn has passed spawns an enemy from prefab
			clone = Instantiate(enemies[(int)spawnTypes[nextNote]], new Vector3(-19.06279f,-6.54228f,0), transform.rotation) as GameObject;
			nextNote++;// incriment index for next spawn check
		}
	
	}
}