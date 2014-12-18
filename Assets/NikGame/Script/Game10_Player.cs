using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Game10_Player : MonoBehaviour
{

	public GUISkin skin;	//GUI Skin->if i can successfully update all gui stuff to the new UGUI then this can be deleted
	public int score;		//Score
	public int lives;		//Lives
	
	//since these are going to be used in the singleton class its not quite the same as here where need to have local refs-so does that mean the if lives==0 -> game over should be in the gamecontroller?
	public int sickness; //the health LOCAL REFERENCE TO THE SICKNESS IN THE GAMECONTROLLER
	
	//private SickFacesManager sickFaceRenderer;//getting its script 	
	//int timeLeft=getComponent<Timer>.timeForLevel;
	//private SpriteRenderer sickFaceRenderer;
	private Vector3 pos;	//Position that touch input was registered
	public bool dead;		//If the player has died (allows to generate 'restart' buttons etc)
	private bool need2PressReady=true; //this decides if the player needs to confirm that they're redy to play thus timescale will =1;
	//	public Text sicknessHUDText; //IF i make it so sickness level persists across levels then this can be altered since the var would be in the singleton not here and only with current instance scope
	
	public GameObject sickFaces; 
	//--------------------------------------INITILISATION-------------------------------------------------------------
	
	void Awake (){
		if (Application.loadedLevelName.Contains ("Level")) { //ignore the stuff below if this is a 'menu' scene rather than actual gameplay level.
			
			//facesManager2 sickFaces = sickFacesObj.GetComponent<facesManager2>();

			//sickFaces.checkSicknessNeedChangeGraphic();

			Time.timeScale=0 ;
			need2PressReady =true; 
		}
		if (Application.loadedLevelName.Contains ("Level") == false) {
			
//				Debug.Log("I SHOULDNT B SEEING THE AVATAR");
			//	GameController._instance.Destroy(gameObject.GetComponent("SpriteRenderer"));


		}

		
	}//close awake


	
	
//TRYING TO FIX THE BUG FROM HERE
	
	void Start ()
	{
		//find out from test users if they prefer to reset sickness in each level, or the sickness is persisitent across levels.
		//sickness = GameController._instance.sickness;
		
		///<remarks>The screen orientation and sleep timeout code is taken from the Android game template</remarks>
		//Set screen orientation to landscape
		Screen.orientation = ScreenOrientation.Landscape;
		//Set sleep timeout to never ie dont let the screen go to sleep if inactive
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
		
		
	}
	
	
	//------------------------------------------------------UPDATE-----------------------------------------------------
	
	void Update (){
		
		//	Allow me to skip between levels, this is obviously just for development period since pressing space bar isnt much use on an ipad
		
				if (Input.GetKeyDown (KeyCode.Space)) {
					Application.LoadLevel(Application.loadedLevel+1);
				}
		
				if (Input.GetKeyDown (KeyCode.S)) {
					Debug.Log ("sickness is: "+GameController._instance.sickness);
				}





		//If the player has died then they shouldn't be able to interact with the objects (check this isnt going to conflict with gui ie restart button)
		if (dead)
		{
			GameController._instance.score=0;
			collider.enabled = false;
			return;
		}
		//If the player has got game over (they either lost all their lives or sickness == max)
		if (lives < 1||sickness>=100)
		{			
			Time.timeScale=0; //this pauses the game. YES AND THEN IT MAKES IT LOOK LIKE THE GAMES CRASHED AFTER U PRESS REPLAY!!!!!!!!!
			dead = true;
			//Set collider to false-why have i repeated the code since its in the if(dead)-try commenting out to make sure its not used and so can safely delete
			collider.enabled = false;
			if(sickness>=100){ //just to see what was the reason of the player getting game over.
				Debug.Log ("Game over-u puked");
				GameController._instance.sickness=0;
			}
			else if(lives<1){
				Debug.Log ("Game over-u drank spiked drinks");}
			
			
		}
		
		//-----------------------------------------------------------USING TOUCH INPUT-----------------------------------
		
		//This code for touch repsonse is taken from the Android template, however its nothing that isnt in any tutorial. obviosy i ahd to chanf platfrom from droid to iOS
		//If the game is running on a touch device
		if (Application.platform == RuntimePlatform.IPhonePlayer) 
		{
			//If  the palyer touches the screen
			if (Input.touchCount == 1)
			{
				//Find screen touch position
				pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 1));
				//Set position
				transform.position = new Vector3(pos.x,pos.y,0);
				//Set collider to true
				collider.enabled = true;
				return;
			}
			//Set collider to false
			collider.enabled = false;
		}
		//code for quickly testing the game on macbook rather a touch device (which is worth doing since running unity remote is soooo slow)
		else
		{
			//Find mouse position
			pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
			//Set position
			transform.position = new Vector3(pos.x,pos.y,0);
		}
		
		
	}//close update
	
	
	//-------------------------------------------THE COLLISONS------------------------------------------------------------//
	/// <summary>
	//This code is for collisions with the drinks and other objects. 
	// Sticking to beer will increase sickness a small amount but any other alcoholic drink will mean they mixed their drinks and thus get sick quickly.
	/// </summary>
	
	void OnTriggerEnter(Collider other)   
	{
			//If player hits a drink other than a beer, then they've mixed their drinks which increases sickness lots
			//if they have a softdrink or eat some food they decrease their sickness
			
			switch (other.tag) {
				
			case "badAlcohol":
				other.GetComponent<DrinkFoodCollision> ().Hit ();
				GameController._instance.setScore(-50);
				GameController._instance.setSickness(15);
			SoundEffectsManager.Instance.BadDrinkSound();
				break;
				
			case "Beer":
				other.GetComponent<DrinkFoodCollision> ().Hit ();
				GameController._instance.setScore(10);
				GameController._instance.setSickness(2);
			SoundEffectsManager.Instance.GoodDrinkSound();	
			break;	
				
				
			case "SoftDrink":
				other.GetComponent<DrinkFoodCollision> ().Hit ();
				GameController._instance.setScore(50);
				GameController._instance.setSickness(-5);
			SoundEffectsManager.Instance.OpenCanSound();

			break;	
				
			case "Food":
				other.GetComponent<DrinkFoodCollision> ().Hit ();
				GameController._instance.setScore(100);
				GameController._instance.setSickness(-10);
			SoundEffectsManager.Instance.FoodSound();	
			break;	
				
			case "Enemy":
				other.GetComponent<DrinkFoodCollision> ().Hit ();
				GameController._instance.setScore(-200);
				GameController._instance.setSickness(20);
			SoundEffectsManager.Instance.SpikedDrinkSound();
				lives--; 
		//from user tests thers a question if sickness or #oflives should be reset across levels.
		//game tradition = lives =global and health = level specific 
				break;
				
			case "infoCardPickup":
			other.GetComponent<DrinkFoodCollision> ().Hit ();
			GameController._instance.unlockCard (Application.loadedLevelName); //tel the gamecontroller to set the bool for this card to be unlocked
			GameController._instance.setScore(100);
			SoundEffectsManager.Instance.PickUpSound();
			break;


			default:
				Debug.Log ("Default case");
				print ("UNKNOWN COLLISON OCCURED");
				break;
	
		
			}
			
			
///NIK LOOK HERE
			
	//after doing whichever of the relevant cases the code should check if the game object with sickness face needs to be updated 
///	checkSicknessNeedChangeGraphic ();

//sickness was added from collision-now check if that has killed the palyer
			if(GameController._instance.sickness>=100)
				{dead=true;  //think this doesnt really do much here since i moved all functionality to gamecontroller, so hre it simpley allows ongui to be called
				Debug.Log("player shoudl be dead now SICKNESS =100 CALLED DIE");
			Time.timeScale=0;
				}
//			Debug.Log("dead in PLAYER was set to tru");}
//	
		checkSicknessNeedChangeGraphic();


	}//close collsion method
	
	
	#region GuiStuffs
	//--------------------------------------------------------GUI MENU And HUD-----------------------------------//
	
	void OnGUI() //this is such a rubbish UI system, port it to UGUI (if i have time)
	{
		
		if (Application.loadedLevelName.Contains ("Level")) {   //no point in showuing the time left, score etc when ur in main menu etc!
			GUI.skin = skin;
			
			if (dead) { //update the display to lives =0 if the player has died, else show the number of lives left
				GUI.Label (new Rect (10, Screen.height - 35, 300, 300), "Lives: 0");
				
			} else {
				//Show lives left
				GUI.Label (new Rect (10, Screen.height - 35, 300, 300), "Lives: " + lives.ToString ());
			}


			//Menu Button
			if (GUI.Button (new Rect (Screen.width - 120, 0, 120, 40), "Menu")) {
				//Load Menu scene
				GameController._instance.sickness=0;
				GameController._instance.score=0;
				Application.LoadLevel ("MainMenu");
			}


			//GameController._instance.sickness=1000; //this was being used to 'trick' the class into having a value that is empty.commented out cos its just an invite for bugs!
			//gameObject.GetComponent<sickFacesManager>().ChangeSprite(7);
			//checkSicknessNeedChangeGraphic();
			
			
			
			////
			
			if (dead) {   //If have died show the play again or main menu options
				//Play Again Button
				if (GUI.Button (new Rect (Screen.width / 2 - 90, Screen.height / 2 - 60, 180, 50), "Play Again")) {
					Application.LoadLevel ("LevelOne");  //return to the 1st level
					GameController._instance.sickness=0;
				}
				

				
			}//close if dead
			
			if(need2PressReady){   //if the level has just begun and plater needs to press ready to start level
				if (GUI.Button (new Rect (Screen.width / 2 - 90, Screen.height / 2 - 60, 180, 50), "Ready?")) 
				{
					need2PressReady=false;
					Time.timeScale=1; //on press, unpause the game
				}	
			}	
		}//close the 'if(application.loadedlevelname contains the word level)
		
	}//close onGui
	#endregion
	

//TO HERE
//------------------------------------Go to next Level-----------------------------------//

	void goToNextLevel(){
		if (Application.loadedLevel >= Application.levelCount) 
		{ 
		//if this is the last level then we wont be able to go a next level-ret to main menu-except this makes the script break so ignore it for now!!!
		Application.LoadLevel (Application.loadedLevel + 1);
		}
	}


	
	/////////////////NIK LOOK HERE////
	//COMMENTING OUT ALL REFENCES TO THE SICKFACES COS UNITY SO KIDLY DECDED TO BREAK MY GAME WITH THEM IN

	/// 


public void checkSicknessNeedChangeGraphic(){


	int spriteToRequest=0; //have to set up an init value 

	if (sickness <= 1 && sickness < 10) {    
		spriteToRequest=1;
	} 


	else if (sickness>11 && sickness < 29){
		spriteToRequest=2;
	}

	else if (sickness>30 && sickness < 49){
		spriteToRequest=3;
	}


	else if (sickness>50 && sickness< 69){
		spriteToRequest=4;
	}


	else if (sickness>70 && sickness <90){
		spriteToRequest= 5;
	}

	else if (sickness>=90&&sickness <990){   
		spriteToRequest= 6;
	}

	//		else if (sickness>=1000){   
	//			spriteToRequest = 7;
	//		}


	sickFaces.GetComponent<facesManager2>().ChangeSprite(spriteToRequest);
		Debug.Log ("player called change sprite");
} 

	


}//close class
