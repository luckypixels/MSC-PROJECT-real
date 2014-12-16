using UnityEngine;
using System.Collections;

/// <summary>
/// This script comtrols the behaviour of infocard pickup (a pick up like fruit in pac man, not the main information cards)
/// it appears and then starts falling after a short delay,this is because its not fair on the player if it generates and begins falling immeadiately 
/// so i have initially turned off gravity.
/// I did have the alpha of the object fade gradually but seeing as the duration of the fade was not to last longer than the pause from rendering to falling it had to be such a quick fade in that it seemed moot 
/// to do slowly, so alpha jumps from 50%-100 in .5 secs and as its not noticible but helps performance.
/// </summary>
/// 
/// 
/// The information card pick up gets instantiated in the infoCardPickUpSpawner class which has an instantiate method, that method gets called by the timer class. 
/// could say that the relationship between timer and this can be set up direct w/out need for the spawner but this allows me to set up the  spawner class and the 
/// instances it creates (ie this class) will take the spawnwers rotation and position vars, thus i can see in scene mode where the object is positioned. 
/// seeing as Timer class is on a text object which is a part of the ugui canvas im not sure i trust using thats co-ordintaes since the canvas is this whole seperate entity designed by madmen.

public class InfoCardPickUp : MonoBehaviour {
	SpriteRenderer spriteRenderer;
	
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer>();
		spriteRenderer.color = new Color (1f, 1f, 1f, 0.0f); //makes the aplha 0.
		rigidbody.useGravity = false;
		collider.enabled = false;
		Invoke ("movePrefabAndIncreaseColour", 1.0f);
	}
//
	public void movePrefabAndIncreaseColour(){
		spriteRenderer.color = new Color (1f, 1f, 1f, 1f);
		collider.enabled = true;
		rigidbody.useGravity = true;
	}
	
	}//CLOSE THE CLASS


