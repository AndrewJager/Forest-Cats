using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager_Script : MonoBehaviour {
	
	public string PlayerName;
	
	// Update is called once per frame
	public void RunScene (int scene) {
		SceneManager.LoadScene(scene);
	}
}
