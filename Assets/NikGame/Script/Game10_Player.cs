using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Game10_Player : MonoBehaviour
{

	public GUISkin skin;	//GUI Skin->if i can successfully update all gui stuff to the new UGUI then this can be deleted
	public int score;		//Score
	public int lives;		//Lives
	//since these are going to be used in the singleton class its not quite the same as here where need to have local refs-so does that mean the if lives==0 -> game over should be in the gamecontroller?
	public int sickness; //the health
	private GameObject sickFaces; //the avatar graphic that sprite swaps depending on value of sickness var
	//private SickFacesManager sickFaceRenderer;//getting its script 	
	//int timeLeft=getComponent<Timer>.timeForLevel;
	//private SpriteRenderer sickFaceRenderer;
	private Vector3 pos;	//Position that touch input was registered
	public bool dead;		//If the player has died (allows to generate 'restart' buttons etc)
	private bool need2PressReady=true; //this decides if the player needs to confirm that they're redy to play thus timescale will =1;
//	public Text sicknessHUDText; //IF i make it so sickness level persists across levels then this can be altered since the var would be in the singleton not here and only with current instance scope


	//--------------------------------------INITILISATION-------------------------------------------------------------

	void Awake (){
		if (Application.loadedLevelName.Contains ("Level")) { //ignore the stuff below if this is a 'menu' scene rather than actual gameplay level.

			GameController._instance.checkSicknessNeedChangeGraphic();   //when player dies and hits restart the sickness var is reset to 0 but i forgot to update the avatar, hence calling the method now.

			//each level starts paused & requires the player to confirm they are ready to play 
			//this fixes the issue that if the player dies the timescale==0, press replay and it looks like app crashed since it was still in 0 timescale

			Time.timeScale=0 ;
			need2PressReady =true; 
			}
		if (Application.loadedLevelName.Contains ("Level") == false) {
						
				Debug.Log("I SHOULDNT B SEEING THE AVATAR");
//			GameController._instance.Destroy(gameObject.GetComponent("SpriteRenderer"));

				}

	}//close awake




	void Start ()
	{
		//find out from test users if they prefer to reset sickness in each level, or the sickness is persisitent across levels.
		sickness = GameController._instance.sickness;

		///<remarks>The screen orientation and sleep timeout code is taken from the Android game template</remarks>
		//Set screen orientation to landscape
		Screen.orientation = ScreenOrientation.Landscape;
		//Set sleep timeout to never ie dont let the screen go to sleep if inactive
		Screen.sleepTimeout = SleepTimeout.NeverSleep;


	}


	//------------------------------------------------------UPDATE-----------------------------------------------------

	void Update ()
	{

	//	Allow me to skip between levels, this is obviously just for development period since pressing space bar isnt much use on an ipad

		if (Input.GetKeyDown (KeyCode.Space)) {
			Debug.Log ("pressed level skip");
			goToNextLevel();
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


		//should i put the call to the sickFaces class here?

	}


	//-------------------------------------------THE COLLISONS------------------------------------------------------------//
	/// <summary>
	//This code is for collisions with the drinks and other objects. 
	// Sticking to beer will increase sickness a small amount but any other alcoholic drink will mean they mixed their drinks and thus get sick quickly.
	/// </summary>

	void OnTriggerEnter(Collider other)   
	{


//before executing the switch state of different objects, see if the collision was with the pick up item for the level.
				
		if (other.name == "infoCardPickup") { 
						Debug.Log ("got the pick up");
						score += 500;
			other.GetComponent<DrinkFoodCollision> ().Hit ();
			GameController._instance.unlockCard (Application.loadedLevelName);
				} 

		else {
			//If player hits a drink other than a beer, then they've mixed their drinks which increases sickness lots
			//if they have a softdrink or eat some food they decrease their sickness


			//WANT TO GET RID OF LOCAL SCORE AND SICKNESS BUT FOR NOW HAVE IN BOTH AND THEN AFTER IVE FINALLY GOT SOME SLEEP THEN I'LL FIX THIS...ITS COS THE SICKFACE STUFF REFERENCESS CURRENT VALS

						switch (other.tag) {

						case "badAlcohol":
								other.GetComponent<DrinkFoodCollision> ().Hit ();
								GameController._instance.setScore(-50);
								GameController._instance.setSickness(15);
								break;
		
						case "Beer":
								other.GetComponent<DrinkFoodCollision> ().Hit ();
								GameController._instance.setScore(10);
								GameController._instance.setSickness(2);
 								break;	


						case "SoftDrink":
								other.GetComponent<DrinkFoodCollision> ().Hit ();
								GameController._instance.setScore(50);
								GameController._instance.setSickness(-5);
								break;	

						case "Food":
								other.GetComponent<DrinkFoodCollision> ().Hit ();
								GameController._instance.setScore(100);
								GameController._instance.setSickness(-10);
								break;	

						case "Enemy":
								other.GetComponent<DrinkFoodCollision> ().Hit ();
								GameController._instance.setScore(-200);
								GameController._instance.setSickness(20);
								
								lives--; //i really think that the game is too hard if the lives are not reset across the levels (ie !=gameController but diff instane in each level's player obj), or is that cos i'm testing it on mouse and u always have a scren co-ord unlike touch where can lift finger away, thus with mouse can inadvertantly hit those poxy poison bottles?
								break;

						default:
								Debug.Log ("Default case");
								print ("UNKNOWN COLLISON OCCURED");
								break;
						}

						//after doing whichever of the relevant cases the code should check if the game object with sickness face needs to be updated 
						GameController._instance.checkSicknessNeedChangeGraphic ();
			if(GameController._instance.sickness>=100)
			{dead=true;
			Debug.Log("dead in PLAYER was set to tru");}
				} //close else

		}//close collsion method




//--------------------------------------------------------GUI MENU And HUD-----------------------------------//

	void OnGUI() //this is such a rubbish UI system, port it to UGUI (if i have time)
	{

		if (Application.loadedLevelName.Contains ("Level")) {   //no point in showuing the time left, score etc when ur in main menu etc!
						GUI.skin = skin;
		
						
						if (dead) { //update the display to lives =0 if the player has died, else show the number of lives left
								//Show "Lives: 0"

				GUI.Label (new Rect (10, Screen.height - 35, 300, 300), "Lives: 0");
								
						} else {
								//Show lives left
								GUI.Label (new Rect (10, Screen.height - 35, 300, 300), "Lives: " + lives.ToString ());
						}
		
		
						//Menu Button
						if (GUI.Button (new Rect (Screen.width - 120, 0, 120, 40), "Menu")) {
								//Load Menu scene
								Application.LoadLevel ("MainMenu");
				GameController._instance.sickness=0;
						}


						 //If have died show the play again or main menu options
						if (dead) {
								//Play Again Button
								if (GUI.Button (new Rect (Screen.width / 2 - 90, Screen.height / 2 - 60, 180, 50), "Play Again")) {
										Application.LoadLevel (Application.loadedLevel);
					GameController._instance.sickness=0;
								}

								//Menu Button
								if (GUI.Button (new Rect (Screen.width / 2 - 90, Screen.height / 2, 180, 50), "Menu")) {
										Application.LoadLevel ("MainMenu Real");
										GameController._instance.sickness=0;	
								}

								}	
								if(need2PressReady){
									if (GUI.Button (new Rect (Screen.width / 2 - 90, Screen.height / 2 - 60, 180, 50), "Ready?")) {
									need2PressReady=false;
									Time.timeScale=1; //on press, unpause the game

					

				}
						}	
				}//close the 'if(application.loadedlevelname contains the word level)
		}//close onGui


//------------------------------------Go to next Level-----------------------------------//

					void goToNextLevel(){
					if (Application.loadedLevel >= Application.levelCount) 
						{ 
								//if this is the last level then we wont be able to go a next level-ret to main menu-except this makes the script break so ignore it for now!!!
								Application.LoadLevel (Application.loadedLevel + 1);
						}
				}
}//close class
