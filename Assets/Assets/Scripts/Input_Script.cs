using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Input_Script : MonoBehaviour {
	private UnityEngine.UI.Text strInput;
	private UnityEngine.UI.Toggle boolInput;
	private UnityEngine.UI.Slider scrollInput;
	private GameObject managerObject;
	private Manager_Script manager;
	public Globals.InputVariableType varType;
	private string strValue;
	private bool boolValue;
	private float numValue;
	public int valueToWriteTo;

	// Use this for initialization
	void Start () {
		managerObject = GameObject.FindGameObjectWithTag("Manager");
		manager = managerObject.GetComponent<Manager_Script>();
		if (varType == Globals.InputVariableType.String){
			strInput = GetComponent<UnityEngine.UI.Text>();
			strValue = manager.strSettings[valueToWriteTo];
		}
		else if (varType == Globals.InputVariableType.Boolean){
			boolInput = GetComponent<UnityEngine.UI.Toggle>();
			boolValue = manager.boolSettings[valueToWriteTo];
		}
		else if (varType == Globals.InputVariableType.Number){
			scrollInput = GetComponent<UnityEngine.UI.Slider>();
			numValue = manager.numSettings[valueToWriteTo];
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (varType == Globals.InputVariableType.String){
			if (strInput.text != strValue){
				manager.strSettings[valueToWriteTo] = strInput.text;
				strValue = strInput.text;
			}
		}
		else if (varType == Globals.InputVariableType.Boolean){
			if (boolInput.isOn != boolValue){
				manager.boolSettings[valueToWriteTo] = boolInput.isOn;
				boolValue = boolInput.isOn;
			}
		}
		else if (varType == Globals.InputVariableType.Number){
			if (scrollInput.value != numValue){
				manager.numSettings[valueToWriteTo] = scrollInput.value;
			}
		}
	}
}
