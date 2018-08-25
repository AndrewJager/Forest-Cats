using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Input_Script : MonoBehaviour {
	private UnityEngine.UI.Text input;
	private UnityEngine.UI.Toggle boolInput;
	public Manager_Script manager;
	public bool isString;
	private string value;
	private bool boolValue;
	public int valueToWriteTo;

	// Use this for initialization
	void Start () {
		if (isString){
			input = GetComponent<UnityEngine.UI.Text>();
			value = manager.settings[valueToWriteTo];
		}
		else{
			boolInput = GetComponent<UnityEngine.UI.Toggle>();
			boolValue = manager.boolSettings[valueToWriteTo];
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (isString){
			if (input.text != value){
				manager.settings[valueToWriteTo] = input.text;
				value = input.text;
			}
		}
		else{
			if (boolInput.isOn != boolValue){
				manager.boolSettings[valueToWriteTo] = boolInput.isOn;
				boolValue = boolInput.isOn;
			}
		}
	}
}
