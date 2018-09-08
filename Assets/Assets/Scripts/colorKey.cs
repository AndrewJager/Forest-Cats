using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorKey : MonoBehaviour {
	SpriteRenderer sprite;
	Texture2D texture;
	public Color color;
	public Color currentColor;
	public Color eyeColor;
	public Color earColor;
	public Color legColor;
	public Material indicator;
	public int x;
	public int y;
	// Use this for initialization
	void Start () {
		sprite = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void KeySprite (){
		color = indicator.color;
		color.a = 255;
		texture = sprite.sprite.texture;
		currentColor = texture.GetPixel(5,94);
		earColor = texture.GetPixel(6, 96);
		eyeColor = texture.GetPixel(5, 92);
		legColor = texture.GetPixel(14, 73);
		for (int y = 0; y < texture.height; y++)
        {
            for (int x = 0; x < texture.width; x++)
            {
                if (texture.GetPixel(x, y) == currentColor){
					texture.SetPixel(x, y, color); 
				}
            }
        }
		texture.Apply();
	}
}
