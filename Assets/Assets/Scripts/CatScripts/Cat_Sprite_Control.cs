using UnityEngine;
using System.Collections;

public class Cat_Sprite_Control : MonoBehaviour {

	public Animator animControl;
	public SpriteRenderer sprite;

	// Use this for initialization
	void Start () {
		animControl = GetComponent<Animator> ();
		sprite = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void idle () {
		animControl.Play ("idle",0);
	}
	public void walkLeft(){
		sprite.flipX = false;
		animControl.Play ("walk", 0);

	}
	public void walkRight(){
		sprite.flipX = true;
		animControl.Play ("walk", 0);
	}
	public void runLeft(){
		sprite.flipX = false;
		animControl.Play ("run", 0);
	}
	public void runRight(){
		sprite.flipX = true;
		animControl.Play ("run", 0);
	}
	public void sit(){
		animControl.Play("sit", 0);
	}
	public void rotateSprite(float angle){
		transform.eulerAngles = new Vector3(0f, 0f, angle);
	}
	public void offsetSprite(float x, float y){
		transform.localPosition = new Vector3(x, y, 0f);
	}
	public void overrideFlipX(bool X){
		sprite.flipX = X;
	}
	public void overrideFlipY(bool Y){
		sprite.flipX = Y;
	}
}







