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


///<code>
	/// THIS IS FOR SAVING IN THE PLAYERPREFS SO DATA OF PLAYER PROGRESS LASTS OVER PLAY SESSIONS
	/// 
	/// 
	/// 
	/// 
	/// 
	/// 
	/// 
	/// </code>





///<remarks> 
/// player prefs could be implemented with strings key=levelOneUnlockedStatus value="true";
///that way the values for the above bools will essentially be same value that key's val has
/// as opposed to if(key's value==6666.777889){level2Unlocked=true;}.
/// yes i'd rather use 1 & 0 ints for both above and the playerprefs but remember it seemed to not understand binary for bools last time!!!
	/// </remarks>



//could look at the state of the bools IN ANOTHER SCRIPT with an OnGui.label saying "TaxiInfoCard is"+ use the vars above




	void Awake(){
		_instance = this;
		//its static so i dont actually need dontdestroy... but just in case it goes weird its here
		//DontDestroyOnLoad(gameObject);
	}

	// Use this for initialization
	void Start () {
		//this is obviosuly not of any use in final game its just a proof on concept value can b set via external script and across scenes :)
		guiText.text = "the taxiscard unlocked is:"+ taxiInfoCardUnlocked.ToString(); //if u use the gui.Text object remember to set DoNotDestroy in awake() for it.

		//setting the initial values for the variables
		lives = 3;
		sickness = 0;
		score = 0;

	}

	/// <summary>
	/// So far i used accessing the text field however that was used in scene 1, 
	/// even if this object here is maintained across scenes, the textfield isnt 
	/// so rather than piss about with creating textfields with same tags in levels or donotdestroy on gameobject text, lets just se a debug!.
	/// </summary>
	public void callToGameObject(){
		// Debug.Log (Application.loadedLevelName); //commenting out since kno its working but keep for future use...
		taxiInfoCardUnlocked = true;
		Debug.Log ("Taxi Card is" +taxiInfoCardUnlocked);
	}


	//--------------------------THE METHOD FOR MANAGING THE UNLOCKING OF THE INFORMATION CARDS------------------

	//NOTE THAT I MIGHT TWEAK THE 

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
		//if levelThatCalled == ""; //oh bugger im using a string so does that mean i need to replace == with .Equals or something?
	}



}
