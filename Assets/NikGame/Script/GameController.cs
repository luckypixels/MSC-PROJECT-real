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

private static GameController instance = null;  //its private-only this gets called by the class
public static GameController _instance { // the public version -actually should be _i is private but im not going thru all my scripts to change it now
get { return instance; }
}


GameObject player; //for references to the player object so as to access vars that for teh time being should be in that since they should vary by instance
//public GameObject sickFaces;


//Vars to store the state of whether a card has been unlocked
public bool taxiInfoCardUnlocked = false;
public bool batteryInfoCardUnlocked = false;
public bool highsInfoCardUnlocked = false;
public bool spikingInfoCardUnlocked = false;
public bool softDInfoCardUnlocked = false;
public bool eatInfoCardUnlocked = false;


public int score; //the player's score for this gameplay session

/* these vars are currently implemented in the player class, that means that as each new level = new instance of player 
the vars are reset to 0, that might be a fairer game 4 sickness and lives but is not acceptable 4 score! 
*/
public int sickness;
public int lives;
	

//commenting out the 
//public GameObject sickFaces2;

//vars to see if they can be accessed via other objects on other levels-actually cos the new ugui is being a pain im not (currently) using this
//public Text guiText;

///<remarks> 
/// player prefs could be implemented with strings key=levelOneUnlockedStatus value="true";
///that way the values for the above bools will essentially be same value that key's val has
/// as opposed to if(key's value==6666.777889){level2Unlocked=true;}.
/// yes i'd rather use 1 & 0 ints for both above and the playerprefs but remember it seemed to not understand binary for bools last time!!!
/// </remarks>



//could look at the state of the bools IN ANOTHER SCRIPT with an OnGui.label saying "TaxiInfoCard is"+ use the vars above


	void Awake(){

			if (instance != null && instance != this) { 
				Destroy(this.gameObject);
				return;
			} 
			else {
				instance = this;
			}
			
			DontDestroyOnLoad(this.gameObject); //make this instance persist



		//gameObject.GetComponent<sickFacesManager> ().ChangeSprite (1000);
		
		if (Application.loadedLevelName.Contains("Level")==false){     //ie if we are in menu or the info cards
			//set sickFaces2 to empty sprite
		}
		




		}//close awake


	void Start () {
		//setting the initial values for the variables
		lives = 3;
		sickness = 0;
		score = 0;
	}




	//if cardToCheck is unlocked return 'true' else return false.

	public bool isCardUnlocked (int cardToCheck){

	//public string isCardUnlocked (int cardToCheck){ //version of the method header where string is return value.

		switch (cardToCheck){
		case 1:
			if(spikingInfoCardUnlocked ==true)
				{return true;}
			else
				{return false;}
			break;
		
		case 2:

			if (softDInfoCardUnlocked == true)
				{return true;}
			else
				{return false;}
			break;
		
		case 3:
			if(batteryInfoCardUnlocked == true)
				{return true;}
			else
				{return false;}
			break;
			
		case 4:
			if (taxiInfoCardUnlocked == true)
				{return true;}
			else
				{return false;}
			break;
			
		case 5:
			if( eatInfoCardUnlocked == true)
				{return true;}
			else
				{return false;}
			break;
			

		case 6:
			if (highsInfoCardUnlocked == true)
				{return true;}
			else
				{return false;}
			break;
			

		default:
			print ("NOT sure what CARD called the ISCARDUNLOCKED method in comtroller");
			return false;
			break;

			}
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

		//SEE IF NEED TO ALTER THE AVATAR'S SPRITE-CUD HAVE SICKNESS BEING CHECKED HERE AND THEN IT KNOWS IF VALUE HAS ALTERED ENOUGH TO CALL CHANGE SPRITE
		//THAT MIGHT BE BEST AS IT REDUCES THE NEED TO CALL ACROSS OBJECTS O EACH COLLISION


		//.checkSicknessNeedChangeGraphic ();

	}


//----------------------------------MOVING THE IF DEAD CODE FROM THE PLAYER CLASS-----------------

	void playerDied(){

//		print ("YOU HAVE DIED OF DYSENTRY"); //wonder if any1 will read my code & if they'll get the game this is a reference to...
//		score=0;
//	 player = GameObject.FindGameObjectWithTag("Player");
//		player.GetComponent<Game10_Player> ().dead = true;;
//	
//		Debug.Log ("Game over-u puked");

	}


//SINCE MY GAME KINDLY DECIDED TO COMPLETELY BREAK WITH A WEEK TO GO IM COMMENTING ALL TO DO WITH SICKFACES OUT FOR NOW.
/*
//--------------------------------------UPDATING REFERENCE TO A SICKFACES MANAGER

	public void getRefToSickFaces(GameObject sickFaceForLevel){
		sickFaces2 = sickFaceForLevel;
		Debug.Log ("updated ref to sickfaces obj");
	}

*/

}//class close