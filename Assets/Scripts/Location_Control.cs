using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script for colliders used by player
public class Location_Control : MonoBehaviour {
	public string zone;
	public GameObject player;
	public Cat_Control player_script;
	public UnityEngine.UI.Text UIText;
	public float size;
	public float maxHeight;
	[HideInInspector] public bool inZone;
	public bool isTree;
	[HideInInspector] public bool isPlayerLeft;
	private float playerX;
	private float playerY;
	private float zoneX;
	private bool isReset;
	void Start () {
		if (isTree){
			zone = "Tree";
		}
	}
	
	// Update is called once per frame
	void Update () {
		playerX = player.transform.position.x;
		playerY = player.transform.position.y;
		zoneX = transform.position.x;
		if ((playerX > (zoneX - (size / 2)) && (playerX < (zoneX + (size / 2))))){
			UIText.text = zone;
			isReset = false;

			if (playerX > zoneX){
				isPlayerLeft = false;
			}
			else{
				isPlayerLeft = true;
			}
			player_script.leftOfTree = isPlayerLeft;

			if (isTree){
				if (playerY < maxHeight){
					player_script.onTree = true;
				}
				else{
					player_script.onTree = false;
				}
			}
		}
		else {
			inZone = false;
			if (!isReset){ //Only set text to empty string once, to prevent from overwriting other zone scripts.
				UIText.text = "";
				isReset = true;
				if (isTree){
					player_script.onTree = false;
				}
			}
		}

	}
}
