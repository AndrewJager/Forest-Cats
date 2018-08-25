using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script for colliders used by player
public class Location_Control : MonoBehaviour {
	public GameObject player;
	public GameObject spawn;
	public Cat_Control player_script;
	public UnityEngine.UI.Text UIText;
	public string zoneName;
	public enum ZoneType {Den, Tree};
	public ZoneType zoneType;
	public float size;
	public float maxHeight;
	public float offset;
	[HideInInspector] public bool inZone;
	readonly public bool isTree;
	[HideInInspector] public bool isPlayerLeft;
	private float playerX;
	private float playerY;
	private float zoneX;
	private bool isReset;
	public float spawnX;
	public float spawnY;

	public Location_Control(){
	if (zoneType == ZoneType.Tree){
			isTree = true;
		}
	}
	void Start () {
		if (zoneType == ZoneType.Tree){
			zoneName = "Tree";
		}
		if (spawn != null){
			spawnX = spawn.transform.position.x;
			spawnY = spawn.transform.position.y;
		}
	}
	
	// Update is called once per frame
	void Update () {
		playerX = player.transform.position.x;
		playerY = player.transform.position.y;
		zoneX = transform.position.x + offset;
		if ((playerX > (zoneX - (size / 2)) + offset && (playerX < (zoneX + (size / 2))))){
			UIText.text = zoneName;
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
