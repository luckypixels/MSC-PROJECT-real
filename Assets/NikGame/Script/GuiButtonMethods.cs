using UnityEngine;
using System.Collections;

public class GuiButtonMethods : MonoBehaviour {
	
	// Use this for jumping to the next level, will use as the start button in the main title screen
	public void goNextlevel () {
		Application.LoadLevel ("LevelOne");
	}


	public void goToInfoCards () {
		Application.LoadLevel ("InfoCards");
	}
	

	public void goToMenu(){
		Application.LoadLevel ("MainMenu");
	}

	//note could build on this to make it into a coroutiene to have a delay, however i wont for now as ultimately  i want there to be the 'delay' in the next level ie the wait is for the player to press begin in each level


	//IT'D BE MUCH BETTER TO HAVE 1 function with name of the level to load as a param at call and then insde this 1 method have switch for what room to put in application.LoadLevel...

	
}