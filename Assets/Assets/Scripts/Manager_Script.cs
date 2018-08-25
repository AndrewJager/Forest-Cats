using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager_Script : MonoBehaviour {
	public List <Edge_Script> exits;
	public int currentScene;
	public string PlayerName;
	public List <string> values;
	public Dictionary<int, string> test = new Dictionary <int, string>();

	public void Start (){
		PlayerName = "Player Name";
		Scene scene = SceneManager.GetActiveScene();
		currentScene = scene.buildIndex;
	}
	
	// Update is called once per frame
	public void Update(){
		//Debug.Log("update start");
		for (int i = 0; i < exits.Count; i++){
			if (exits[i].startNewLevel == true){
				RunScene(exits[i].newScene);
			}
		}
		
	}

	void Awake(){
		DontDestroyOnLoad(this.gameObject);
	}
	public void RunScene (int scene) {
		SceneManager.LoadScene(scene);
	}
}
