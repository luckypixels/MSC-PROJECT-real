using UnityEngine;
using System.Collections;

public class PauseMenuScript : MonoBehaviour {
	//var that refer to teh gameobject
	public GameObject PauseMenuPanel;
	//the animator
	private Animator anim;
	//set the state of the bool that triggers the anims state to private.
	//private bool isPaused =false; //default to not paused



	// Use this for initialization
	void Start () {
		Time.timeScale = 1; //not paused
		anim = PauseMenuPanel.GetComponent<Animator> (); //store a ref to the animation on the object
		anim.enabled = false;
	}

	//the commented ou code is from when i was practacisng with makign a pause feature so wont delete it just yet but tis of litte/no use in this scene
//	// Update is called once per frame
//	void Update () {
//	
//				if (Input.GetKeyDown (KeyCode.Escape)) {  //for testing i cant be bothererd to make more buttons usig escape
//								PauseGame ();
//						} else if (Input.GetKeyUp (KeyCode.Escape)) {
//							UnPauseGame();		
//				}
//		}

//	public void PauseGame(){
//		anim.enabled = true;
//		anim.Play("PauseMenuSlideIn");
//		isPaused=true;
//		Time.timeScale=0;
//	}

	public void ThumbClicked()
	{

		// want to find out what card was clicked
//		switch (gameObject.name) {
//		}

		//seeing as the oher way woul be to use colliders and see what other in collision was i think the best bet is to set these scripts on each btn adn us gameObject as the ref to current obj

//would be goo to interface with game object to have getters and setters for teh bools for each of cards

	

		if (GameController._instance.batteryInfoCardUnlocked == true) {
						Debug.Log ("taxi card is UNlocked so here u go..");
						anim.enabled = true;
						anim.Play ("PauseMenuSlideIn");

				} else {
						Debug.Log ("taxi card is STILL LOCKED so fuck off..");
				}
	}//clsoe thumbclicked



	public void UnPauseGame(){
		anim.Play("PauseMenuSlideOut");
	//	isPaused=false;
	//	Time.timeScale=1;
	}








}
