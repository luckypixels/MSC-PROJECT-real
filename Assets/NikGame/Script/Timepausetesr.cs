using UnityEngine;
using System.Collections;

/*
this is a test to see if pausing a game works, it works a charm, so instead of using a keydown:-
use this with a button and toggle graphic depending on the pause state.
 */


public class Timepausetesr : MonoBehaviour {

	int countdown;
	bool paused=true;

	public Animator startButton;
	public Animator settingsButton;


	public void OpenSettings()
	{
		startButton.SetBool("isHidden", true);
		settingsButton.SetBool("isHidden", true);
	}


	void Awake(){
		Time.timeScale = 0;
	}
	void Start () {
		countdown = 30;
		InvokeRepeating ("countDown",1,1);
	}
	
	// Update is called once per frame
	void Update () {
	if (Input.GetKeyDown("a")) {
			//using a bool for this so can toggle pause on adn off

			if(paused==false){  //if we arent already paused...
				paused=true;
				Debug.Log ("paused");
				Time.timeScale=0;}
			else{		//otherwise its unpaused and so: pause it
				paused=false;
				Debug.Log ("NOT paused");
				Time.timeScale=1;}
				
		}
	//put listener for the pause button here
	}

	void countDown(){
		Debug.Log(countdown);
		countdown--;
		if (countdown == 0) {
			Debug.Log ("out of time");		
		}
	}


	public void startButtonPressed(){
		Time.timeScale = 1;
	}



}
