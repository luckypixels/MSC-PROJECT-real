using UnityEngine;
using System.Collections;

public class unLockManager : MonoBehaviour {

	/*
USING THIS CLASS TO TEST A LOT OF SHIT OUT SO WONT JUST BE THE LEVEL INFO BUT PLAYER PREFS, THO THAT
IS A FOLLOW ON TO UNLOCKING LEVELS ANYWAY...
	 */

	//deleting saved data ie high scores and data of what levels etc have been unlocked.
	/*
	 * if(GUI.Button new Rect(10,10,10,10)"Delete All Settings"))
	 * {
	 * PlayerPrefs.DeleteAll(); //this deletes ALL data stored
	 * PlayerPrefs.DeleteKey("nameOfKey"); //this deletes only the data stored under a specified key.
	 *
	 * }
	 * 
	 * /

//check if there is a specified key in the player prefs:
//if(PlayerPrefs.HasKey("Foo")) //use this to see if there is data under this name & can assign its  value to a var
//{PlayerPrefs.GetString("TheKeyName")} -can also .GetInt & GetFloat to get a number like score etc.
//-when looking up a number obviously u still specify the string its saved under so GetInt("Highscore");


	//declare list to store the levels in the game (should this include non gameplay 1s ie title and menu?)
	public List <string> levelsInGame= new List<string>()
		levelsInGame.add("Taxi");
		levelsInGame.add("SoftDrinks");
		levelsInGame.add("Eat");
		levelsInGame.add("Spiking");
		levelsInGame.add("LegalHighs");
		levelsInGame.add("Battery");
	/*	
	 * If i'm including 'non gameplay' scenes as levels
	 * levelsInGame.add("MainMenu");
		levelsInGame.add("InfoCards");
	 	 */


	//create a series of buttons for the different levels, for quick mock up gonna use haggard onGui

		//Debug.Log("Clicked the button with text");


	//---------------------------------TESTING IF THE CARDS ARE UNLOCKED---------------------------
	public bool eatCardisUnlocked =false;
	public bool taxiCardisUnlocked =false;
	public bool highsCardisUnlocked =false;
	public bool softdrinksCardisUnlocked =false;
	public bool batteryCardisUnlocked =false;
	public bool spikingCardisUnlocked =false;


	////////////////////////////////////////////////////////////////////////
	///   IF ALL CARDS UNLOCKED AND ALL LEVELS COMPLETE=GAME COMPLETE///////
	/// -HAVE A CONGRATS MSSG/SCENE AND BUTTON 2 VIEW CARDS/      //////////
	////////////////////////////////////////////////////////////////////////


	//MAIN BODY-IE THE METHODS
	/// /////////////////////////////////////////////////////////////////////////////////////////////////////////

		// only want this menu 2 show if on the correct page:-
	void Awake(){
		DontDestroyOnLoad(transform.gameObject); //make sure this object is not destroyed when going to other levels

		if (Application.loadedLevelName == "menu") { //i have since renamed the scene so this never == true so every level has the gui-obviously got to change that but its a nice way to check that the DoNotDestroyOnLoad has worked!!!!
						
				} else {
			print ("no buttons since this isnt the main menu");		
		}
		}
	//this masssive laod of ifs doesnt look too pretty but a i dont knpw if theres a way around it & b, fuck it this is only a test b4 i use the UGUI

	//the if statements and the bools above are working so i can have the bools set on completition in the levels :)
	//the bools can be used with player prefs to save 1 if unlocked

	//going to redo this sort of workflow for the unlocked levels. just cos a level is unlocked doesnt mean got card and just cos got card pickup doesnt mean then cimpleted level!


	
	void OnGUI(){
		
				//if(GUI.Button(new Rect(10, 70, 50, 30), "Click"))
			if (GUI.Button (new Rect (10, 80, 80, 20), "Taxi")) {
						//have a test to see if the level has been unlocked - need to make a series of public bools 

						if (taxiCardisUnlocked != false) {
								Debug.Log ("LOOK AT TAXI CARD");
						} else {
								Debug.Log ("you need to unlock this card in the game!");
						}

				}

			if (GUI.Button (new Rect (90, 80, 80, 20), "Spiking")) {
			//have a test to see if the level has been unlocked - need to make a series of public bools 
						
						if (spikingCardisUnlocked != false) {
							Debug.Log ("LOOK AT Spiking CARD");
						} else {
							Debug.Log ("you need to unlock this card in the game!");
				}
		}

			if (GUI.Button (new Rect (90, 80, 80, 51), "Eating")) {
					//have a test to see if the level has been unlocked - need to make a series of public bools 
						
					if (eatCardisUnlocked != false) {
							Debug.Log ("LOOK AT Eating CARD");
						} else {
							Debug.Log ("you need to unlock this card in the game!");
					}}

			if (GUI.Button (new Rect (180, 80, 80, 51), "Battery")) {
				//have a test to see if the level has been unlocked - need to make a series of public bools 
				
						if (batteryCardisUnlocked != false) {
							Debug.Log ("LOOK AT battery CARD");
						} else {
							Debug.Log ("you need to unlock this card in the game!");
						}}


			if (GUI.Button (new Rect (250, 80, 80, 51), "soft drinks")) {
				//have a test to see if the level has been unlocked - need to make a series of public bools 
				
							if (softdrinksCardisUnlocked != false) {
								Debug.Log ("LOOK AT soft drinks CARD");
							} else {
								Debug.Log ("you need to unlock this card in the game!");
							}}


			if (GUI.Button (new Rect (330, 80, 80, 51), "Legal")) {
				//have a test to see if the level has been unlocked - need to make a series of public bools 
					
							if (highsCardisUnlocked != false) {
									Debug.Log ("LOOK AT LEGAL Highs CARD");
								} else {
									Debug.Log ("you need to unlock this card in the game!");
								}

				}

		//instead of the nasty nested if statements there must be a way to get a property of the button (name, btn text etc)
		//and use it as a string in the if varCardIsUnlocked....
	    

	}//clsoe the level selectGUI


				/*
 void OnGUI() {
        if (!btnTexture) {
            Debug.LogError("Please assign a texture on the inspector");
            return;
        }
        if (GUI.Button(new Rect(10, 10, 50, 50), btnTexture))
            Debug.Log("Clicked the button with an image");
        
        if (GUI.Button(new Rect(10, 70, 50, 30), "Click"))
            Debug.Log("Clicked the button with text");
        
    }


	 */




		





}//close the class