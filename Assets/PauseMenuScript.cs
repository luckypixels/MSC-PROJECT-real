using UnityEngine;
using System.Collections;

public class PauseMenuScript : MonoBehaviour {
	//var that refer to teh gameobject
	public GameObject PauseMenuPanel;
	//the animator component
	private Animator anim;
	//set the state of the bool that triggers the anims state to private.
	private bool isPaused =false; //default to not paused
	
	
	
	// Use this for initialization
	void Start () {
		//Time.timeScale = 1; //not paused
		anim = PauseMenuPanel.GetComponent<Animator> (); //store a ref to the animation on the object
		anim.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown (KeyCode.Escape)) {  //for testing i cant be bothererd to make more buttons usig escape
			ShowCard ();
		} else if (Input.GetKeyUp (KeyCode.Escape)) {
			HideCard();		
		}
	}

	public void ShowCard(){
	//public void PauseGame(){
		anim.enabled = true;
		anim.Play("PauseMenuSlideIn");
		isPaused=true;
	//	Time.timeScale=0;
	}
	
	public void HideCard(){
	//public void UnPauseGame(){
		anim.Play("PauseMenuSlideOut");
		isPaused=false;
		//Time.timeScale=1;
	}
	
	
	


}
