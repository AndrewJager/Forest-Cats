using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Input_Script : MonoBehaviour {
	private UnityEngine.UI.Text input;
	public Manager_Script manager;
	private string value;
	public int valueToWriteTo;

	// Use this for initialization
	void Start () {
		input = GetComponent<UnityEngine.UI.Text>();
	}
	
	// Update is called once per frame
	void Update () {
		if (input.text != value){
			manager.values[valueToWriteTo] = input.text;
		}
	}
}
