using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Script for changeing levels when at edge of map
public class Edge_Script : MonoBehaviour {
	public bool goToNewLevel;
	public bool startNewLevel;
	public int newScene;
	[HideInInspector] public Collider2D hitBox;

	void Start (){
		hitBox = GetComponent<Collider2D> ();
		if (goToNewLevel){
			hitBox.isTrigger = true;
		}
		startNewLevel = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D other){
		if (goToNewLevel && other.name == "Player"){
			startNewLevel = true;
		}	
	}
}
