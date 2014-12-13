using UnityEngine;
using System.Collections;

public class sickFacesManager : MonoBehaviour {

/// <remarks>
//I found that whilst I had only 1 instance of the sickfaces object (instantiated in level 1 & persisting across the levels) if i play thru each level consistently,
//there would be multiple instances if i played level one and returned to the menu and then play again, the 1st instance persists to main menu and then 
//on returning to game there would be the original and a new so need a method to check if the script was instantiaiting a new 1, tell it to disregard the new 1. 	
//obviously this is all referring to the Awake function. Note this method is also relevant for the singleton class (GameController).
/// </remarks>
	

//assigning vars to store to the different sprites-dont use the word sicknessSprite-keep it reusable!
public Sprite sprite1; 
public Sprite sprite2;  
public Sprite sprite3; 
public Sprite sprite4;
public Sprite sprite5; 
public Sprite sprite6;
public Sprite sprite7;

public int sickness;

private bool dead;		//If the player has died (allows to generate 'restart' buttons etc)

private SpriteRenderer spriteRenderer; //the var that refers to the gameObj's sprite renderer


public static sickFacesManager Instance {
	get;
	private set;
	}



 

//tell it to keep this across levels
	void Awake(){
		spriteRenderer = gameObject.GetComponent<SpriteRenderer> ();
		spriteRenderer.sprite = sprite7;
		Debug.Log ("hidden sprite as its main menu");
		
		//spriteRenderer.sprite = null;

		Instance = this;

		//Find out if there are not any other instances of the object
		if (Instance != null && Instance != this) {
						//Destroy other instances
						Destroy (gameObject);
				}
//		
		//Save the current singleton instance

		else {
						DontDestroyOnLoad (gameObject);
				}  //want this gameObject to persist across the rooms 
	}
	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer>(); // get the SpriteRenderer of the Gameobject
		if (spriteRenderer.sprite == null) {
			spriteRenderer.sprite = sprite1; // set the sprite to sprite1
		}
}//close start

	///<description>// In Start() I've put a check to make sure if there isnt already a sprite then set it to 
	/// sprite 1 by default. worth doing this sorta if(!null) check in all my scripts but especially here as 
	/// new sprite stuff in v.4 can be a little bugg</description>


//this public method can be called by the other classes, ie they monitor the state of a var and make apprpriate calls. 
//however, im keeping a commented out version of the original where all parts such as monitoring the range were done in same class, in case i need to tweak how it works etc.


	public void ChangeSprite (int sickness) //ok putting the if(sickness==foo) here works for this practice but since it'll be being called via the player/gamecontroller following a collision with object it needs a proper method since cant call events like update!
	{
		if (sickness == 1) {    //the i'm not drunk yet part
			spriteRenderer.sprite = sprite1;
		} 
		
		
		else if (sickness ==2){
			spriteRenderer.sprite = sprite2;
		}
		
		else if (sickness ==3){
			print ("larger sprite pls");
			spriteRenderer.sprite = sprite3;
		}
		
		
		else if (sickness == 4){
			print ("larger sprite pls");
			spriteRenderer.sprite = sprite4;
		}
		
		
		else if (sickness == 5){
			print ("larger sprite pls");
			spriteRenderer.sprite = sprite5;
		}
		
		else if (sickness == 6){     //he's about to puke sprite
			print ("larger sprite pls");
			spriteRenderer.sprite = sprite6;
		}
//
	else if(sickness ==1000){   //this is a test for trying to get the sprite to be switched off in menu 
	//else{
			spriteRenderer.sprite = null;
		}

		}//close changeSprite()


}//close class
	
