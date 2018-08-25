using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music_Manager : MonoBehaviour {
	public bool mute;
	public enum MusicState {homeNormal, mainMenu, fight};
	public MusicState state;
	private MusicState playingState;
	public AudioClip [] home_normal;
	public AudioClip [] main_menu;
	AudioSource player;
	// Use this for initialization
	void Start () {
		player = GetComponent<AudioSource>();
		player.loop = false;
		PlaySong();
		playingState = state;
	}
	
	// Update is called once per frame
	void Update () {
		if (player.isPlaying == false){
			PlaySong();
		}
		if (playingState != state){
			PlaySong();
			playingState = state;
		}
	}

	void PlaySong (){
		if (!mute){
			if (state == MusicState.homeNormal){
				AudioClip song = home_normal[Random.Range(0,home_normal.Length)];
				player.clip = song;
				player.Play();
			}
			else if (state == MusicState.mainMenu){
				AudioClip song = main_menu[Random.Range(0, main_menu.Length)];
				player.clip = song;
				player.Play();
			}
			else if (state == MusicState.fight){

			}
			else{
				Debug.Log("music state not defined in code!");
			}
		}
	}
}
