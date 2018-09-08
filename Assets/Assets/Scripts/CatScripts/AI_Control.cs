using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Control : MonoBehaviour {
	private GameObject managerObject;
	private Manager_Script manager;
	public Cat_Control catControl;
	public Cat_Utilites utils;
	public Globals.Rank rank;
	// Use this for initialization
	void Start (){
		managerObject = GameObject.FindGameObjectWithTag("Manager");
		manager = managerObject.GetComponent<Manager_Script>(); 
		catControl = GetComponent<Cat_Control>();
		utils = managerObject.GetComponent<Cat_Utilites>();
		string newName;
		rank = catControl.rank;
		if (rank == Globals.Rank.Kit){ 
			newName = utils.RandKitName();
		}
		else if (rank == Globals.Rank.Apprentice){
			newName = utils.RandApprenticeName();
		}
		else if ((rank == Globals.Rank.Warrior) || (rank == Globals.Rank.Deputy) || (rank == Globals.Rank.Healer)){
			newName = utils.RandWarriorName();
		}
		else if (rank == Globals.Rank.Leader){
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
		if (rank != catControl.rank){
			catControl.rank = rank;
		}
	}
}
