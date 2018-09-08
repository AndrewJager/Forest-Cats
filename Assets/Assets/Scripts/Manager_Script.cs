﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager_Script : MonoBehaviour {
	private Music_Manager music;
	public Player_Control player;
	public List <GameObject> edges;
	public List <Edge_Script> exits;
	public int currentScene;
	private int lastScene;
	public string PlayerName;
	public List <string> strSettings;
	public List <bool> boolSettings;
	public List <float> numSettings;
	public GameObject[] locations;// Locations in scene
	public GameObject[] cats; // Cats in scene
	public GameObject[] otherManagers; //for removing other manager object in scene

	public void Start (){
		PlayerName = "Player Name";
		music = GetComponent<Music_Manager>();
		Scene scene = SceneManager.GetActiveScene();
		currentScene = scene.buildIndex;
		lastScene = scene.buildIndex;
		onSceneChange();
	}
	
	// Update is called once per frame
	public void Update(){
		Scene scene = SceneManager.GetActiveScene();
		currentScene = scene.buildIndex;
		if (currentScene != lastScene){
			onSceneChange();
			lastScene = scene.buildIndex;
		}
		if (exits.Count != 0){
			for (int i = 0; i < exits.Count; i++){
				if (exits[i].startNewLevel == true){
					RunScene(exits[i].newScene);
				}
			}
		}
		if (currentScene == 0){// Main menu
			music.state = Music_Manager.MusicState.mainMenu;
			music.UpdateSettings();
		}
		else if(currentScene == 1){// Camp
			music.state = Music_Manager.MusicState.homeNormal;
		}
		else if (currentScene == 2){// Credits
			music.state = Music_Manager.MusicState.credits;
		}

		cats = GameObject.FindGameObjectsWithTag("Cat"); 
	}

	void Awake(){
		DontDestroyOnLoad(this.gameObject);
	}
	public void RunScene (int scene) {
		SceneManager.LoadScene(scene);
	}

	public void onSceneChange(){
		cats = GameObject.FindGameObjectsWithTag("Cat"); 
		locations = GameObject.FindGameObjectsWithTag("Location");

		otherManagers = GameObject.FindGameObjectsWithTag("Manager");
		if (otherManagers.Length > 1){
			Destroy(otherManagers[1]); // THERE CAN ONLY BE ONE!
		}
		otherManagers = null;

		edges.Clear();
		exits.Clear();
		foreach(GameObject edge in GameObject.FindGameObjectsWithTag("Edge")) {
             edges.Add(edge);
			 exits.Add(edge.GetComponent<Edge_Script>());
         }
		Debug.Log("scene changed");
	}

	public void WriteSaveFile(float saveFile){ //really an int, but saved as a float
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath + "/PlayerData" + saveFile + ".dat");
		StoredData data = new StoredData();

		data.strings = strSettings;
		data.numbers = numSettings;
		data.bools = boolSettings;

		bf.Serialize(file, data);
		file.Close();
	}
	public void LoadSaveFile(float saveFile){
		if (File.Exists(Application.persistentDataPath + "/PlayerData" + saveFile + ".dat")){
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/PlayerData" + saveFile + ".dat", FileMode.Open);
			StoredData data = (StoredData)bf.Deserialize(file);
			file.Close();

			strSettings = data.strings;
			numSettings = data.numbers;
			boolSettings = data.bools;
			Debug.Log(Application.persistentDataPath);
		}
	}
}

[Serializable]
class StoredData{
	public List<string> strings; 
	public List<float> numbers;
	public List<bool> bools;
}
