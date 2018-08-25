using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sky_Control : MonoBehaviour {
	public float rotateSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(0f,0f,rotateSpeed);
	}
}
