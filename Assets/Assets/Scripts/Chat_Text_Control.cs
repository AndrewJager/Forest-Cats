using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chat_Text_Control : MonoBehaviour {

	private UnityEngine.UI.Text textA;
	public UnityEngine.UI.Text textB;//the other two chat texts, from top to bottom
	public UnityEngine.UI.Text textC;
	// Use this for initialization
	void Start () {
		textA = GetComponent<UnityEngine.UI.Text>(); 
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void newMessage(string Message){
		textC.text = textB.text;
		textB.text = textA.text;
		textA.text = Message; 
	}
}
