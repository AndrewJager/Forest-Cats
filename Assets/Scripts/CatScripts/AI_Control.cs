using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Control : MonoBehaviour {
	public Cat_Control catControl;
	public Cat_Utilites utils;
	public Cat_Control.Rank rank;
	// Use this for initialization
	void Start (){
		string newName;
		rank = catControl.rank;
		if (rank == Cat_Control.Rank.Kit){
			newName = utils.RandKitName();
		}
		else if (rank == Cat_Control.Rank.Apprentice){
			newName = utils.RandApprenticeName();
		}
		else if ((rank == Cat_Control.Rank.Warrior) || (rank == Cat_Control.Rank.Deputy) || (rank == Cat_Control.Rank.Healer)){
			newName = utils.RandWarriorName();
		}
		else if (rank == Cat_Control.Rank.Leader){
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

	}
}
