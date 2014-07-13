using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Collections.Generic;

public class SongSelect : MonoBehaviour {
	public GameObject playMenuStuff;
	public GameObject SelectionScreenStuff;
	public GUISkin customSkin;
	static public string path;
	Vector2 startPos;
	Vector2 direction;
	public AudioSource buttonClang;
	FileBrowser songBrowser;

	protected Texture2D	directoryImage,
	fileImage;
	bool swtch = false;

	void OnMouseDown(){
		MainMenu.tutorial = false;
		MainMenu.boss = false;
		if(songBrowser == null)buttonClang.Play();
		swtch = true;
	}
	void OnGUI(){

		GUI.skin = customSkin;
		GUI.skin.verticalScrollbar.fixedWidth = (Screen.width * .05f);
		GUI.skin.button.fontSize = (int)(Screen.width/40);
		GUI.skin.label.fontSize = (int)(Screen.width/40);
		GUI.skin.customStyles[0].fontSize = (int)(Screen.width/15);
	
		if (songBrowser != null && swtch) {
				
				songBrowser.OnGUI ();
				
		} else if(swtch){
				OnGUImain();
		}
	}
	void OnGUImain()
	{

			songBrowser = new FileBrowser(
				new Rect(0, 0, Screen.width, Screen.height),
				"Choose mp3 File",
				FileSelectedCallback
				);
		

	}

	protected void FileSelectedCallback(string spath) {
		songBrowser = null;
		path = spath;
		swtch = false;
		buttonClang.Play();
	}

	void Update(){
		if(path != null){
			WWW www = new WWW ("file://" + SongSelect.path);
			MainMenu.songName =  Path.GetFileNameWithoutExtension(SongSelect.path);
			AudioClip myAudioClip= www.audioClip;
			while (!myAudioClip.isReadyToPlay)
				MainMenu.song = myAudioClip;
			playMenuStuff.SetActive(false);
			SelectionScreenStuff.SetActive(true);
			path = null;
		}

		if (Input.GetMouseButtonDown (0)) {
			startPos = (Vector2)Input.mousePosition;
		}
		if (Input.GetMouseButton (0)) {
			direction = (Vector2)Input.mousePosition - startPos; 
			direction.x = 0f;
			if (songBrowser != null)songBrowser.Scroll(direction.normalized*20f);

		}
	}
}


/*
	File browser for selecting files or folders at runtime.
 */

public enum FileBrowserType {
	File,
	Directory
}

public class FileBrowser {
	
	// Called when the user clicks cancel or select
	public delegate void FinishedCallback(string path);
	// Defaults to working directory

	protected string m_currentDirectory;
	// Optional pattern for filtering selectable files/folders. See:
	// http://msdn.microsoft.com/en-us/library/wz42302f(v=VS.90).aspx
	// and
	// http://msdn.microsoft.com/en-us/library/6ff71z1w(v=VS.90).aspx

	protected string m_filePattern;

	protected FileInfo[] fileinfo;
	protected string[] filenames;
	protected string[] filenameshort;
	protected bool loading;
	// Browser type. Defaults to File, but can be set to Folder

	protected FileBrowserType m_browserType;
	protected string m_newDirectory;
	protected string[] m_currentDirectoryParts;
	
	protected string[] m_files;
	protected GUIContent[] m_filesWithImages;
	protected int m_selectedFile;
	
	protected string[] m_nonMatchingFiles;
	protected GUIContent[] m_nonMatchingFilesWithImages;
	protected int m_selectedNonMatchingDirectory;
	
	protected string[] m_directories;
	protected GUIContent[] m_directoriesWithImages;
	protected int m_selectedDirectory;
	
	protected string[] m_nonMatchingDirectories;
	protected GUIContent[] m_nonMatchingDirectoriesWithImages;
	
	protected bool m_currentDirectoryMatches;
	
	protected GUIStyle CentredText {
		get {
			if (m_centredText == null) {
				m_centredText = new GUIStyle(GUI.skin.label);
				m_centredText.alignment = TextAnchor.MiddleLeft;
				m_centredText.fixedHeight = GUI.skin.button.fixedHeight;
			}
			return m_centredText;
		}
	}
	protected GUIStyle m_centredText;
	
	protected string m_name;
	protected Rect m_screenRect;
	
	protected Vector2 m_scrollPosition;
	
	protected FinishedCallback m_callback;
	
	// Browsers need at least a rect, name and callback
	public FileBrowser(Rect screenRect, string name, FinishedCallback callback) {

		m_name = name;
		m_screenRect = screenRect;
		//m_browserType = FileBrowserType.File;
		m_callback = callback;
	

		if (File.Exists (Application.persistentDataPath + "/library.txt")) {
						readlist ();
				} else {
			getsongs();
			makelist();
				}
	}

	public void getsongs(){
		m_newDirectory = Application.persistentDataPath;
		int index = m_newDirectory.IndexOf('/');  
		index = m_newDirectory.IndexOf('/', index +1);//firstslash
		index = m_newDirectory.IndexOf('/', index +1);//secondslash
		m_newDirectory = m_newDirectory.Substring(0, index);
		//Debug.Log(m_newDirectory);
		DirectoryInfo DR = new DirectoryInfo (m_newDirectory);
		fileinfo = DR.GetFiles("*mp3", SearchOption.AllDirectories);
		Array.Sort(fileinfo,(x, y) => StringComparer.OrdinalIgnoreCase.Compare(x.DirectoryName.Substring(x.DirectoryName.LastIndexOf("\\")+1)+"\\"+x.Name, y.DirectoryName.Substring(y.DirectoryName.LastIndexOf("\\")+1)+"\\"+y.Name));
		filenames = new string[fileinfo.Length];
		for (int i = 0; i<fileinfo.Length; i++) {
			filenames[i] = fileinfo[i].FullName;
		}
		filenameshort = new string[filenames.Length];
		for (int s = 0; s< filenames.Length; s++) {
			filenameshort[s] = filenames[s].Substring(filenames[s].LastIndexOf("/")+1);		
		}
	}
	public void makelist(){
		System.IO.File.WriteAllLines(Application.persistentDataPath + "/library.txt", filenames);

		}
	public void readlist(){
		filenames = System.IO.File.ReadAllLines(Application.persistentDataPath + "/library.txt");
		filenameshort = new string[filenames.Length];
		for (int s = 0; s< filenames.Length; s++) {
			filenameshort[s] = filenames[s].Substring(filenames[s].LastIndexOf("/")+1);		
		}
		}
	public void OnGUI() {

		GUILayout.BeginArea(
			m_screenRect,
			m_name,
			GUI.skin.window
			);

		m_scrollPosition = GUILayout.BeginScrollView(
			m_scrollPosition,
			false,
			true,
			GUI.skin.horizontalScrollbar,
			GUI.skin.verticalScrollbar,
			GUI.skin.box
			);

		m_selectedFile = GUILayoutx.SelectionList(
			m_selectedFile,
			filenameshort,
			FileDoubleClickCallback
			);

		GUILayout.EndScrollView();
		GUILayout.BeginHorizontal();
		GUILayout.FlexibleSpace();
		if (GUILayout.Button("Reload Songs", GUILayout.Width(Screen.width*.3f),GUILayout.Height(Screen.height*.1f))) {
			getsongs();
			makelist();

		}

		if (GUILayout.Button("Cancel", GUILayout.Width(Screen.width*.3f),GUILayout.Height(Screen.height*.1f))) {
			m_callback(null);
		}

		if (GUILayout.Button("Select", GUILayout.Width(Screen.width*.3f),GUILayout.Height(Screen.height*.1f))) {
			m_callback( filenames[m_selectedFile]);	
		}
		GUI.enabled = true;
		GUILayout.EndHorizontal();
		GUILayout.EndArea();

	}
	public void Scroll(Vector2 scroll ){
		m_scrollPosition += scroll;
	}


	protected void FileDoubleClickCallback(int i) {
		m_callback( filenames[m_selectedFile]);
	}

}



// selected list class
public class GUILayoutx {
	
	public delegate void DoubleClickCallback(int index);
	
	public static int SelectionList(int selected, GUIContent[] list) {
		return SelectionList(selected, list, "List Item", null);
	}
	
	public static int SelectionList(int selected, GUIContent[] list, GUIStyle elementStyle) {
		return SelectionList(selected, list, elementStyle, null);
	}
	
	public static int SelectionList(int selected, GUIContent[] list, DoubleClickCallback callback) {
		return SelectionList(selected, list, "List Item", callback);
	}
	
	public static int SelectionList(int selected, GUIContent[] list, GUIStyle elementStyle, DoubleClickCallback callback) {
		for (int i = 0; i < list.Length; ++i) {
			Rect elementRect = GUILayoutUtility.GetRect(list[i], elementStyle);
			bool hover = elementRect.Contains(Event.current.mousePosition);
			if (hover && Event.current.type == EventType.MouseDown && Event.current.clickCount == 1) // added " && Event.current.clickCount == 1"
			{
				selected = i;
				Event.current.Use();
			}
			else if (hover && callback != null && Event.current.type == EventType.MouseDown && Event.current.clickCount == 2) //Changed from MouseUp to MouseDown
			{
				callback(i);
				Event.current.Use();
			} else if (Event.current.type == EventType.repaint) {

				elementStyle.Draw(elementRect, list[i], hover, false, i == selected, false);
				//Debug.Log(i + "  "+ selected);
			}
		}
		return selected;
	}
	
	public static int SelectionList(int selected, string[] list) {
		return SelectionList(selected, list, "List Item", null);
	}
	
	public static int SelectionList(int selected, string[] list, GUIStyle elementStyle) {
		return SelectionList(selected, list, elementStyle, null);
	}
	
	public static int SelectionList(int selected, string[] list, DoubleClickCallback callback) {
		return SelectionList(selected, list, "List Item", callback);
	}
	
	public static int SelectionList(int selected, string[] list, GUIStyle elementStyle, DoubleClickCallback callback) {
		for (int i = 0; i < list.Length; ++i) {
			Rect elementRect;
			elementRect = GUILayoutUtility.GetRect(new GUIContent(list[i]), elementStyle);
			bool hover = elementRect.Contains(Event.current.mousePosition);
			if (hover && Event.current.type == EventType.MouseDown && Event.current.clickCount == 1) // added " && Event.current.clickCount == 1"
			{
				selected = i;
				Event.current.Use();
			
			}
			else if (hover && callback != null && Event.current.type == EventType.MouseDown && Event.current.clickCount == 2) //Changed from MouseUp to MouseDown
			{
				//Debug.Log("Works !");
				callback(i);
				Event.current.Use();
			} else if (Event.current.type == EventType.repaint) {

				elementStyle.Draw(elementRect, list[i], hover, true, i == selected, false);

			}
		}
		return selected;
	}
	
}