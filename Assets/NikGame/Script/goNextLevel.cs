using UnityEngine;
using System.Collections;

public class goNextLevel : MonoBehaviour {

	// Use this for jumping to the next level, will use as the start button in the main title screen
	public void goNextlevel () {
		GameController._instance.callToGameObject(); //this shows that the objects are calling the gameManager class.
		Application.LoadLevel ("LevelOne");
	}

	//note could build on this to make it into a coroutiene to have a delay, however i wont for now as ultimately 
	//i want there to be the 'delay' in the next level ie the wait is for the player to press begin in each level


}
