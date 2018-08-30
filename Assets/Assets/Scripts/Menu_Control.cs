using System.Collections;
using System.Collections.Generic;
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

	public float speed;
	private float frontTreeSpeed;
	private float middleTreeSpeed;
	private float lightSpeed;
	private float backTreeSpeed;

	public float limit;
	private bool goingLeft;

	// Use this for initialization
	void Start () {
		managerObject = GameObject.FindGameObjectWithTag("Manager");
		manager = managerObject.GetComponent<Manager_Script>(); 

		saveButton.onClick.AddListener(SaveClick);

		frontTreeSpeed = speed * 2.5f;
		middleTreeSpeed = speed * 2.0f;
		lightSpeed = speed * 1.15f;
		backTreeSpeed = speed * 1.0f;

		goingLeft = true;
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
		manager.WriteSaveFile(manager.numSettings[1]);
	}
}
