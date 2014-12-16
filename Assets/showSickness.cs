using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class showSickness : MonoBehaviour {
	
	//var that refers to this text object
	public 	Text textLabel;
	
	void Awake(){
		textLabel.text ="im meant to show the sickness";  //this shows when i test the game without having gone thru the mainmenu where the gamecomntroller is instantiated 
		DontDestroyOnLoad(textLabel); 
		
	}
	
	//seeing as the score isnt being updated it looks like i need to use the upadte()
	void Update() 
	{
		textLabel.text ="Sickness: " + GameController._instance.sickness.ToString();
	}
	





}
