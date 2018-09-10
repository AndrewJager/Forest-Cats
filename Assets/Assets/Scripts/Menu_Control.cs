using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Menu_Control : MonoBehaviour {
	private GameObject managerObject;
	private Manager_Script manager;

	public GameObject frontTrees;
	public GameObject middleTrees;
	public GameObject lightSprite;
	public GameObject backTrees;

	public UnityEngine.UI.Button saveButton;
	public UnityEngine.UI.Button loadButton;
	public UnityEngine.UI.Button colorButton;
	public UnityEngine.UI.Toggle saveA;
	public UnityEngine.UI.Toggle saveB;
	public UnityEngine.UI.Toggle saveC;
	public UnityEngine.UI.Slider volume;
	public UnityEngine.UI.Toggle mute;
	public UnityEngine.UI.Text playerNameEntry;
	public UnityEngine.UI.Text placeholder;
	public UnityEngine.UI.Text playerNameDisplay;
	public colorKey key;
	public Material indicator;
	public Color playerColor;

	public float speed;
	private float frontTreeSpeed;
	private float middleTreeSpeed;
	private float lightSpeed;
	private float backTreeSpeed;

	public float limit;
	private bool goingLeft;
	private int saveFile;

	// Use this for initialization
	void Start () {
		managerObject = GameObject.FindGameObjectWithTag("Manager");
		manager = managerObject.GetComponent<Manager_Script>(); 

		saveButton.onClick.AddListener(SaveClick);
		loadButton.onClick.AddListener(LoadClick);

		frontTreeSpeed = speed * 2.5f;
		middleTreeSpeed = speed * 2.0f;
		lightSpeed = speed * 1.15f;
		backTreeSpeed = speed * 1.0f;

		goingLeft = true;

		LoadClick();
		playerNameEntry.text = placeholder.text;
	}
	
	// Update is called once per frame
	void Update () {
		if (goingLeft){
			frontTrees.transform.Translate(new Vector2(frontTreeSpeed, 0f));
			middleTrees.transform.Translate(new Vector2(middleTreeSpeed, 0f));
			lightSprite.transform.Translate(new Vector2(lightSpeed, 0f));
			backTrees.transform.Translate(new Vector2(backTreeSpeed, 0f));
			if (backTrees.transform.position.x > limit){
				goingLeft = false;
			}
		}
		else{
			frontTrees.transform.Translate(new Vector2(-frontTreeSpeed, 0f));
			middleTrees.transform.Translate(new Vector2(-middleTreeSpeed, 0f));
			lightSprite.transform.Translate(new Vector2(-lightSpeed, 0f));
			backTrees.transform.Translate(new Vector2(-backTreeSpeed, 0f));
			if (backTrees.transform.position.x < -limit){
				goingLeft = true;
			}
		}
	}

	void SaveClick(){
		playerNameDisplay.text = playerNameEntry.text;
		// boolean settings
		manager.boolSettings[0] = mute.isOn; //music mute

		// number settings
		// numSettings[0] is the save file, set at the end of this function
		manager.numSettings[1] = volume.value; //music volume
		manager.numSettings[2] = playerColor.r; //player color
		manager.numSettings[3] = playerColor.g;
		manager.numSettings[4] = playerColor.b;

		// string settings
		manager.strSettings[0] = playerNameEntry.text; // Player selected name


		//toggle group ensures that only one of these will be selected
		if (saveA.isOn){
			saveFile = 1;
		}
		else if (saveB.isOn){
			saveFile = 2;
		}
		else if (saveC.isOn){
			saveFile = 3;
		}
		manager.numSettings[0] = saveFile;
		manager.WriteSaveFile(manager.numSettings[0]); //write to selected save file
		UnityEngine.Debug.Log("saved!");
	}

	void LoadClick(){
		if (saveA.isOn){
			saveFile = 1;
		}
		else if (saveB.isOn){
			saveFile = 2;
		}
		else if (saveC.isOn){
			saveFile = 3;
		}
		manager.LoadSaveFile(saveFile);

		mute.isOn= manager.boolSettings[0];

		//save file is checked
		volume.value = manager.numSettings[1];
		playerColor.r = manager.numSettings[2]; 
		playerColor.g = manager.numSettings[3];
		playerColor.b = manager.numSettings[4];

		playerNameDisplay.text = manager.strSettings[0];
		placeholder.text = manager.strSettings[0];

		playerColor.a = 255;
		indicator.color = playerColor;
		key.KeySprite();
		UnityEngine.Debug.Log("Loaded!");
	}

	public void SetColor(){
		playerColor = indicator.color;
	}
}