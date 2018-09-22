using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Control : MonoBehaviour {
	private GameObject managerObject;
	private Manager_Script manager;
	public Cat_Control catControl;
	public Cat_Utilites utils;
	public string catName;
	public Globals.RANK rank;

	private int stepper;
	// Use this for initialization
	void Start (){
		managerObject = GameObject.FindGameObjectWithTag("Manager");
		manager = managerObject.GetComponent<Manager_Script>(); 
		catControl = GetComponent<Cat_Control>();
		utils = managerObject.GetComponent<Cat_Utilites>();
		string newName;
		rank = catControl.rank;
		if (rank == Globals.RANK.Kit){ 
			newName = utils.RandKitName();
		}
		else if (rank == Globals.RANK.Apprentice){
			newName = utils.RandApprenticeName();
		}
		else if ((rank == Globals.RANK.Warrior) || (rank == Globals.RANK.Deputy) || (rank == Globals.RANK.Healer)){
			newName = utils.RandWarriorName();
		}
		else if (rank == Globals.RANK.Leader){
			newName = utils.RandLeaderName();
		}
		else{
			newName = utils.RandFirstName();
		}
		catControl.catName = newName;
		utils.usedNames.Add(newName);
	}
	
	// Update is called once per frame
	void Update () {
		UpdateProperites(); // Should do this at a better time, like scene change;
		RandomMove(stepper, 45);
	}

	void FixedUpdate(){
		stepper++;
	}

	void UpdateProperites(){
		if (rank != catControl.rank){
			catControl.rank = rank;
		}
		if (catName != catControl.catName){
			catControl.catName = catName;
		}
	}

	void RandomMove(int step, int limit){
		if (step >= limit){
			int action = Random.Range(0, 3);
			stepper = 0;
			catControl.goCtrl = false;
			catControl.goDown = false;
			catControl.goLeft = false;
			catControl.goRight = false;
			catControl.goShift = false;
			catControl.goUp = false;
			if (action == 0){
				//walk right
				catControl.goRight = true;
			}
			else if (action == 1){
				//walk left
				catControl.goLeft = true;
			}
			else if (action == 2){
				//Run right
				catControl.goRight = true;
				catControl.goShift = true;
			}
			else if (action == 3){
				//Run left
				catControl.goLeft = true;
				catControl.goShift = true;
			}
			else {
				Debug.Log("invalid action");
			}
		}
	}
}
