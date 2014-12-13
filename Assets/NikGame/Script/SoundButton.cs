using UnityEngine;
using System.Collections;


/// <summary>
///- Script is used on the sound button to mute the music, has a reference to the gameObject which features the audioSource component 
/// and then sets the .mute property to true.
/// 
///- currently the button is a generic 2d object, i hope to use a UGUI 1 and see if i can do sprite swap for sound on and off.
///
//- to mute the audio source need to identify the game object that it is attatched to unless it is on the same object as this script
//in that case 'gameObject' will suffice. 
/// </summary>

///<remarks>//it might be better to have sound start as muted adn player can allow it-it sucks when a game makes loads of noise  by default when ur on a bus
//but if have no sound at start up then it looks like i forgot to include it or its not working!
//if have an 'enable sounds?' dialogue ask ppl if they like it, or if its increases more annoying button presses added-user testing will identify the paipoints and what methods to solve them :) 
///</remarks>

///<remarks> consider this, this script will be attatched to a settings button, the button will not be visible permanently, but if i use this with a new UGUI tool does that use inactive state and visibility turned off?
/// or does it destroy the instance and instantiate as needed.Aside the obvious impact on perfomance due to instantiate/destroy
/// what im worrying about is that this script inits to set audiosource to not be muted. if the button this is attatched to is loaded as new instance each time then it will surely init with the sound unlocked?
/// This script should basically be the event listener for the sound toggle button (this is auto added to the new ugui) and i think i should rewrite this so the 
/// bool state of isMuted resides in the audio object (can give it a script component with bool)-thus loading a button doesnt alter the audio, clicking it does. As the soundObject is persistent so to is the correct
/// value of the bool. when button load it can look see bol value and have the relevant graphic for the button to match the state of bool. my god this is more verbose than the code!!!
///</remarks>


public class SoundButton : MonoBehaviour {

	//--------------------------------------VARIABLES--------------------------------------------
	
	//public GameObject audioSourceGameObj; -Can use this so that I can use inspector to set the musicObj, if do this can comment out the GameObject.Find("MusicObject"); 
	bool soundMuted;//current state of the audio
	GameObject soundsGameObject; //the reference to the object that has the audio component
	AudioSource soundClip; //and its audio component


	private static SoundButton instance = null; //the private version
	public static SoundButton Instance { //the public version which allows for access across all scripts
		get { return instance; }
	}
	void Awake() {
		if (instance != null && instance != this) { //if there is already an instance and its not this 1 being created
			Destroy(this.gameObject);    //get rid of this 1 as its obsolete
			Debug.Log ("delete extra copy of sound");
			return;
		} else {
			instance = this;      //otherwise there isnt a previous instance so this 1 becomes the main 1
			Debug.Log ("this is the only sound 2 plays");
		} 
		DontDestroyOnLoad(this.gameObject);  //ensure it persists across levels & hope it doesnt screw it up like with the gamecontroller
	
		//soundMuted = true; //start the game with sounds turned off by default
	
	}





//------------------------------------METHODS-----------------------------------------------

	void Start () {

//		soundsGameObject = GameObject.Find("MusicObject"); //find the object in the scene, no need to  
//		if(soundsGameObject != null)
//		{
//			Debug.Log ("i've got the music object");
//			soundClip = soundsGameObject.GetComponent<AudioSource>();
//				if(soundClip != null)
//				{
//					Debug.Log ("and its audio component");
//						// Mute Sound's Audio
//						soundClip.mute = true; 
//				}
//		}
	}


//the method for toggling sound on and off
//	public void soundButToggle(){
//		if (soundMuted) { //if sound muted is currently true then set to false and unmute the audio source, 
//			soundMuted=false;
//			soundClip.mute = false;
//		}
//
//		else{ //else it must currently be false-so set it to true!
//			soundMuted=true;
//			soundClip.mute = true;
//		}



	//if (Input.touchCount == 1) - i only pasted this here in case i cant remember how to set up touch!!!


}//close class
