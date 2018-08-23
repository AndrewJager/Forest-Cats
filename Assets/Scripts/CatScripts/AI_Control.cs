using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Control : MonoBehaviour {
	public Cat_Control catControl;
	public Cat_Utilites utils;
	// Use this for initialization
	void Start () {
		if (catControl.rank == "Apprentice"){

		}
		else if (catControl.rank == "Warrior"){
			//catControl.name = utils.RandWarriorName();
		}
		else if (catControl.rank == "Leader"){
			//catControl.name = utils.RandLeaderName();
		}
	}
	
	// Update is called once per frame
	void Update () {
		//catControl.sit = true;
		//catControl.goRight = true;
	}
}
