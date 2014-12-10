using UnityEngine;
using System.Collections;

/// <summary>
/// This script comtrols the behaviour of infocard pickup (pick up like fruit in pac man, not the main information cards)
/// it appears and then starts falling after a short delay,this is because its not fair on the player if it generates and begins falling immeadiately so i have initially turned off gravity by enabling isKinematic
/// I did have the alpha of the object fade gradually but seeing as the duration of the fade was not to last longer than the pause from rendering to falling it had to be such a quick fade in that it seemed moot 
/// to do slowly so alpha jumps from 50%-100 in .5 secs and as its not noticible but helps performance i think this is fine.
/// 
/// had wanted to make it fall a little bit faster and that would have been simple enough with 2d rigid body and i could use add force on here but maybe its best to make it simple for the most casual of gamers, after all the whole point of the app is for them to be able to collect these cards to gain knowledge.
/// </summary>
public class InfoCardPickUp : MonoBehaviour {
	SpriteRenderer spriteRenderer;

//public SpriteRenderer spriteRenderer; //want to be able to alter the alpha 
	// Use this for initialization
	void Start () {
		//gameObject.rigidbody2D.isKinematic = true;
		spriteRenderer = GetComponent<SpriteRenderer>();
		spriteRenderer.color = new Color (1f, 1f, 1f, 0.5f);
		rigidbody.useGravity = false;
	//Debug.Log("hello from the pick up card");
	Invoke ("movePrefabAndIncreaseColour", 0.9f);
//		//try to find a way to add component and set the gravity to 1.3.it needs to appear static for .5 seconds and then get the rigidbody2d (2d allows 2 set level of gravity)
	}
//
	void movePrefabAndIncreaseColour(){
		spriteRenderer.color = new Color (1f, 1f, 1f, 1f);
		rigidbody.useGravity = true;
	}
	
	}//CLOSE THE CLASS


