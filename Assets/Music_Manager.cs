using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music_Manager : MonoBehaviour {
	public enum MusicState {homeNormal, fight};
	public MusicState state;
	public AudioClip [] home_normal;
	AudioSource player;
	// Use this for initialization
	void Start () {
		player = GetComponent<AudioSource>();
		PlaySong();
	}
	
	// Update is called once per frame
	void Update () {
		if (player.isPlaying == false){
			PlaySong();
		}
	}

	void PlaySong (){
		if (state == MusicState.homeNormal){
			AudioClip song = home_normal[Random.Range(0,home_normal.Length)];
			player.clip = song;
			player.loop = false;
			player.Play();
			player.pitch = 4;
		}
		else if (state == MusicState.fight){

		}
		else{
			Debug.Log("music state not defined in code!");
		}
	}
}
