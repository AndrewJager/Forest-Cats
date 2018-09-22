using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Control : MonoBehaviour {
	public Cat_Control catControl;
	public Cat_Utilites utils;
	public Chat_Text_Control chat;
	public GameObject managerObject;
	private Manager_Script manager;
	
	private bool isRight;
	private bool isLeft;
	private bool isUp;
	private bool isDown;
	private bool isShift;
	private bool isCtrl;
	private float hAxis;
	private float vAxis;
	private float aAxis;
	private float rAxis;
	private int counter = 0;

	// Use this for initialization
	void Start () {
		managerObject = GameObject.FindGameObjectWithTag("Manager");
		manager = managerObject.GetComponent<Manager_Script>();
		utils = managerObject.GetComponent<Cat_Utilites>();
		catControl = GetComponent<Cat_Control>();
		utils.usedNames.Add(catControl.catName);
	}
	
	// Update is called once per frame
	void Update () {
		getInput();
		catControl.goRight = isRight;
		catControl.goLeft = isLeft;
		catControl.goUp = isUp;
		catControl.goDown = isDown;
		catControl.goShift = isShift;
		catControl.goCtrl = isCtrl;
	}
	
	void getInput(){
		isLeft = false;
		isRight = false;
		isUp = false;
		isDown = false;
		isShift = false;
		isCtrl = false;

		hAxis = Input.GetAxis ("Horizontal");
		vAxis = Input.GetAxis ("Vertical");
		aAxis = Input.GetAxis ("Ability");
		rAxis = Input.GetAxis ("Run");
		if (hAxis < 0) {
			isLeft = true;
		}
		if (hAxis > 0) {
			isRight = true;
		}
		if (vAxis > 0) {
			isUp = true;
		}
		if (vAxis < 0) {
			isDown = true;
		}
		if (rAxis > 0) {
			isShift = true;
		}
		if (aAxis > 0){
			isCtrl = true;
			counter++;
			if (counter >= 15){
				Speak();
				counter = 0;
			}
		}
	}

	void Speak(){
		//chat.newMessage(utils.RandWarriorName());
	}
}
