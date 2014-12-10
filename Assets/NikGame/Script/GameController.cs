using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// Game controller.this is the class responsible throughout the game of maintaining the state of levels and info cards
/// to see if they are unlocked. obviously they all default to locked atm, tho this may well change when i implement the PlayerPrefs stuff!!!!
/// 
/// -at this exact second in time its a bit grotty as im just using debug.log to see state of things but 
/// a) i am so sick of trying to learn the poxy gui methods (new and old)
/// b)the logic and mechanic is here & the rest will build on this so thank god this crap here works!
/// 
/// -also note that the DontDestroyOnLoad() does NOT need to be called in the awake for this to work
/// </summary>


public class GameController : MonoBehaviour {

	GameObject player; //for references to the player object so as to access vars that for teh time being should be in that since they should vary by instance


public static GameController _instance; // this is lazy singleton method, just because its called lazy doesn't mean its cheating-its in packtpub books i paid good money for so its obviously legit!!!

//vars to see if they can be accessed via other objects on other levels-actually cos the new ugui is being a pain im not (currently) using this
public Text guiText;


//THE VARS to store the state of whether a card has been unlocked
public bool taxiInfoCardUnlocked = false;
public bool batteryInfoCardUnlocked = false;
public bool highsInfoCardUnlocked = false;
public bool spikingInfoCardUnlocked = false;
public bool softDInfoCardUnlocked = false;
public bool eatInfoCardUnlocked = false;

//the vars that store if the next level has been unlocked (will be used in the select level scene)
//these will be set when the timer==0, ie the plater survived & so has completed level (complete level and collect info card r mutually exclusive)
public bool level2Unlocked = false;
public bool level3Unlocked = false;
public bool level4Unlocked = false;
public bool level5Unlocked = false;
public bool level6Unlocked  = false;

// these vars are currently implemented in the player class, that means that as each new level = new instance of player the vars r reset to 0, that might be a fairer game 4 sickness and lives but is not acceptable 4 score! 
public int score;
public int sickness;
public int lives;


public bool SoundMuted; //theres a really weird bug in current sound stuff but i think its cos its not set in singleton & need a if(!null){don't allow new instance}



///<remarks> 
/// player prefs could be implemented with strings key=levelOneUnlockedStatus value="true";
///that way the values for the above bools will essentially be same value that key's val has
/// as opposed to if(key's value==6666.777889){level2Unlocked=true;}.
/// yes i'd rather use 1 & 0 ints for both above and the playerprefs but remember it seemed to not understand binary for bools last time!!!
/// </remarks>



//could look at the state of the bools IN ANOTHER SCRIPT with an OnGui.label saying "TaxiInfoCard is"+ use the vars above


	void Awake(){
				_instance = this;

				//Find out if there aren't already any other instances of the object

				if (_instance != null && _instance != this) {
						//Destroy other instances
						Destroy (gameObject);
				}
	
		//Save the current singleton instance

				else {
						DontDestroyOnLoad (gameObject);
				}  
				//DontDestroyOnLoad(gameObject);

				// THIS CODE REMOVES THE SPRITE COMPONENT FROM THE MENU SCREENS BUT AS ITS REMOVED IT MEANS ITS MISSING FROM LEVELS.IF I DID A CHECK FOR NULL REF CAN I (easily) ADD COMPONENT WITH ALL THE SETTINGS?
//		if (Application.loadedLevelName.Contains ("Level") == false) {
//			Debug.Log("I SHOULDNT B SEEING THE AVATAR");
//			//gameObject.
//			Destroy(gameObject.GetComponent("SpriteRenderer"));
//		}
//	

		//gameObject.GetComponent<sickFacesManager> ().ChangeSprite (1000);
		
		if (Application.loadedLevelName.Contains ("Level") == false) {
			print("shouldnt be seeing the avatar");
						//dirty hack for solving this wretched problem of multiple instances of the avatar in the menus
			//SpriteRenderer  spriteRenderer = GetComponent<SpriteRenderer>();
			//spriteRenderer.sprite=null; 
				}
}//close awake


	void Start () {
		//setting the initial values for the variables
		lives = 3;
		sickness = 0;
		score = 0;
// fuck knows how set this up again		gameObject.GetComponent<ChangeSprite>(1000);
	}


	//--------------------------THE METHOD FOR MANAGING THE UNLOCKING OF THE INFORMATION CARDS------------------

	public void unlockCard(string LevelThatCalled){ //this will take a param of what level called the function

		switch (LevelThatCalled){
		case "LevelOne":
			print ("i will unlokc taxi info card");
			taxiInfoCardUnlocked = true;
			break;
		case "LevelTwo":
			print ("i will unlock battery info card");
			batteryInfoCardUnlocked = true;
			break;
		case "LevelThree":
			print ("i will unlokc eating info card");
			eatInfoCardUnlocked = true;
			break;
		case "LevelFour":
			print ("i will unlokc spiking drinking card");
			spikingInfoCardUnlocked = true;
			break;
		case "LevelFive":
			print ("i will unlokc soft drinks");
			softDInfoCardUnlocked = true;
			break;
		case "LevelSix":
			print ("i will unlock the kegal high card");
			highsInfoCardUnlocked = true;
			break;
		default:
			print ("not sure what level called the unlockLevel method in comtroller");
			break;
		}
}

	//---------------------------THE METHOD FOR UNLOCKING THE NEXT LEVEL-Means that the variable here will be updated can be used in a level select screen if i want to include 1 

	public void unlockLevel(string levelThatCalled){ //takes a param of what level called the function then change bool for what is application.loadedLevelName+1

		Debug.Log ("unlock level was called!!!");
		switch (levelThatCalled){
				case "LevelOne":
					print ("i will unlokc level 2");
					level2Unlocked = true;
					break;
				case "LevelTwo":
					print ("i will unlokc level 3");
					level3Unlocked = true;		
					break;
				case "LevelThree":
					print ("i will unlokc level 4");
					level4Unlocked = true;
					break;
				case "LevelFour":
					print ("i will unlokc level 5");
					level5Unlocked = true;
					break;
				case "LevelFive":
					print ("i will unlokc level 6");
					level6Unlocked = true;
					break;
				case "LevelSix":
					print ("Game completed!");
					//um nothing to do really since the levels complete, how congrats art and then return to menu
					break;
				default:
					print ("not sure what level called the unlockLevel method in comtroller");
					break;

		}
	}


//--------------------------Altering the score------------------------------


	public void setScore(int amountToAlterBy){
		score += amountToAlterBy;

		
		if (score  <= 0) 
			score =0;

	
	}


//--------------------------Altering the sickness------------------------------
	
	
	public void setSickness(int amountToAlterBy){

	

		sickness += amountToAlterBy;

		if (sickness <= 0) {
			sickness=0;

		}
		if (sickness>=100){
			sickness=100;
			//this would mean that the player has died so call a relevant function
			//playerDied();

		}
	}


//--------------------------------CHECKING IF THE SPRITE OF SICKFACES NEEDS TO BE ALTERED-------

	public void checkSicknessNeedChangeGraphic(){
		
	//	GameController._instance.GetComponent<sickFacesManager>(); 
		gameObject.GetComponent<sickFacesManager>();  //referencing this class as it has the sprites loaded into it. 
		int sprite=0; //have to set up an init value 

		if (sickness <= 1 && sickness < 10) {    
			sprite=1;
		} 
		
		
		else if (sickness>11 && sickness < 29){
			sprite=2;
		}
		
		else if (sickness>30 && sickness < 49){
			sprite=3;
		}
		
		
		else if (sickness>50 && sickness< 69){
			sprite=4;
		}
		
		
		else if (sickness>70 && sickness <90){
			sprite = 5;
		}
		
		else if (sickness>=90){   
			sprite = 6;
		}
		//GameController._instance.GetComponent<sickFacesManager>().ChangeSprite(sprite);
		gameObject.GetComponent<sickFacesManager>().ChangeSprite(sprite);
	} 
	
//----------------------------------MOVING THE IF DEAD CODE FROM THE PLAYER CLASS-----------------

	void playerDied(){

//		print ("YOU HAVE DIED OF DYSENTRY");
//		score=0;
//	 player = GameObject.FindGameObjectWithTag("Player");
//		player.GetComponent<Game10_Player> ().dead = true;;
//	
//
//
//		Time.timeScale=0; //this pauses the game. YES AND THEN IT MAKES IT LOOK LIKE THE GAMES CRASHED AFTER U PRESS REPLAY!!!!!!!!!
//
//
//			Debug.Log ("Game over-u puked");

	}






}//class close