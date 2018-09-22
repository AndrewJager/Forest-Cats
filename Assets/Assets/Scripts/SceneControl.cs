using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneControl : MonoBehaviour {
	public string sceneName;
	public Globals.SCENE_TYPE sceneType;
	public GameObject catPrefab;
	public GameObject leftSpawn;
	public GameObject rightSpawn;
	public int targetCats;

	private GameObject managerObject;
	private Manager_Script manager;
	private Cat_Utilites utils;

	// Use this for initialization
	void Start () {
		managerObject = GameObject.FindGameObjectWithTag("Manager");
		manager = managerObject.GetComponent<Manager_Script>();
		utils = managerObject.GetComponent<Cat_Utilites>();

		int cats;
		cats = targetCats + Random.Range(-3, 3);		

		if (sceneType == Globals.SCENE_TYPE.Camp){
			//create leader
			AddCat(Globals.RANK.Leader);

			//Create warriors
			for (int i = 0; i < cats/0.8; i++){
				AddCat(Globals.RANK.Warrior);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void AddCat(Globals.RANK rank) { // add a cat to scene
		GameObject temp;
		AI_Control AI;
		temp = Instantiate(catPrefab);
		AI = temp.GetComponent<AI_Control>();
		AI.rank = rank;
		AI.catName = utils.RandName(rank);
	}
}
