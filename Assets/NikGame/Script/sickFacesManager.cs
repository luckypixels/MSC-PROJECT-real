using UnityEngine;
using System.Collections;

public class sickFacesManager : MonoBehaviour {

//assigning vars to store to the different sprites-dont use the word sicknessSprite-keep it reusable!
public Sprite sprite1; 
public Sprite sprite2;  
public Sprite sprite3; 
public Sprite sprite4;
public Sprite sprite5; 
public Sprite sprite6;

public int sickness;


private SpriteRenderer spriteRenderer; //the var that refers to the gameObj's sprite renderer 

//tell it to keep this across levels
	void Awake(){
		DontDestroyOnLoad(gameObject);
	}



	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer>(); // get the SpriteRenderer of the Gameobject
		if (spriteRenderer.sprite == null) {
			spriteRenderer.sprite = sprite1; // set the sprite to sprite1
		}
}//close statr

	///<description>// In Start() I've put a check to make sure if there isnt already a sprite then set it to 
	/// sprite 1 by default. worth doing this sorta if(!null) check in all my scripts but especially here as 
	/// new sprite stuff in v.4 can be a little bugg</description>


//this public method can be called by the other classes, ie they monitor the state of a var and make apprpriate calls. 
//however, im keeping a commented out version of the original where all parts such as monitoring the range were done in same class, in case i need to tweak how it works etc.
	/*
	public void ChangeSprite (int sickness) //ok putting the if(sickness==foo) here works for this practice but since it'll be being called via the player/gamecontroller following a collision with object it needs a proper method since cant call events like update!
	{
		if (sickness <= 1 && sickness < 10) {    //the i'm not drunk yet part
			print ("sprite1");
			spriteRenderer.sprite = sprite1;
		} 


		else if (sickness>11 && sickness < 29){
			print ("larger sprite pls");
			spriteRenderer.sprite = sprite2;
		}
		
		else if (sickness>30 && sickness < 49){
			print ("larger sprite pls");
			spriteRenderer.sprite = sprite3;
		}


		else if (sickness>50 && sickness< 69){
			print ("larger sprite pls");
			spriteRenderer.sprite = sprite4;
		}

		
		else if (sickness>70 && sickness <90){
			print ("larger sprite pls");
			spriteRenderer.sprite = sprite5;
		}

		else if (sickness>=90){     //he's about to puke sprite
			print ("larger sprite pls");
			spriteRenderer.sprite = sprite6;
		}

	}//close changeSprite()
*/


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
		
	}//close changeSprite()

//so i was going to use switches because i thought i remembered using ranges in c ie case x >0 && x<20, but apparently 
//cant use < > && || in c# switches according to documentation...meh.	
	
	
		

}//close class
	///<description> THIS IS MY TODO IDEAS ON HOW TO IMPROVE THIS CLASS 
	//want to tell it that if sickness var == x then use sprite x, if sickness = y then use sprite y.

	//could have a varibale for sickness here and set as public just so i can test it in the inspector.
	//this would have the update function calling to teh player or gamecontroller to ask what sickness is.

	//that'd b so resource draining, instead this class should have a method thats public and called by the script with
	//the sickness var, here a switch statement would assess which graphic to se on the sprite renderer.
	//therefore each time sickness is updated have a call to the method in this class with new sickness value.
	//-cud evene limit the # of calls to here by telling the method to check when updating 'if sickness is in this range then call this method to ask for graphic update.' 
	//that could be a little complex to script as would need to do for sickness increase and decrease.
	//sickness+= amountToAlterSickness->after this ask if resulting value of sickness is between the range. so far peachy
	//but would then need to see if this is 'state' is the same state (no need for draw call) or new state so ask this class for new art.s
	///	</description>



/*



void ChangeTheDamnSprite ()
{
    if (spriteRenderer.sprite == sprite1) // if the spriteRenderer sprite = sprite1 then change to sprite2
    {
        spriteRenderer.sprite = sprite2;
    }
    else
    {
        spriteRenderer.sprite = sprite1; // otherwise change it back to sprite1
    }



 */