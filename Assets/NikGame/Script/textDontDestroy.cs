using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// this is for the text label on the screen that im using in the main menu as test to see about accessing data in the gameController class.
/// </summary>

public class textDontDestroy : MonoBehaviour {

	//var that refers to this text object
	public 	Text textLabel;

	void Awake(){
		//textLabel.text = "hello level 1"; //this was just to make sure it all linked up okay
		//textLabel.text ="score" + GameController._instance.score.ToString();
				
		DontDestroyOnLoad(textLabel); 

	}

	//seeing as the score isnt being updated it looks like i need to use the upadte()
	void Update() 
	{
		textLabel.text ="Score: " + GameController._instance.score.ToString();
	}



	}

