using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class cardThumbOnPress : MonoBehaviour {
		//var that refer to teh gameobject which is te card to load
		public GameObject CardForThisBtn;
		
	public GameObject PauseMenuPanel;
	//the animator component
	private Animator anim;
	//set the state of the bool that triggers the anims state to private.
	private bool isPaused =false; //default to not paused

	public bool isUnlocked;

	void Start () {
		//Time.timeScale = 1; //not paused
		anim = PauseMenuPanel.GetComponent<Animator> (); //store a ref to the animation on the object
		anim.enabled = false;
	}


		
		public void ThumbClicked() //this method calls the method in controller.need to identify which button was pressed to call this method, then send that to the controller as a parm in that method call.
		{
			/*
		have an int in here,this number is used at the end of this method as the parameter for calling the relevant function in controller
		want to see which card called the method, switch statement for each name and each 1 has a number,which gets assigned to the above mentioned var
		 */
			int cardID = 0;
			
		switch (gameObject.name) 
	
		{
			case "SpikingInfoCardBtn":
				Debug.Log ("called spiking");
				cardID =1;	
				break;
					
				
			case "SoftDrinkInfoCardBtn":
				Debug.Log ("called softdrinsk");
				cardID =2;	
				break;
					
			case "BatteryInfoCardBtn":
				Debug.Log ("called battery");
				cardID=3;	
				break;
				
				
			case "TaxiInfoCardBtn":
				Debug.Log ("called taxi");
			cardID=4;
				break;
				
				
			case "EatInfoCardBtn":
				Debug.Log ("called eat");
				cardID=5;	
				break;
					
				
			case "LegalInfoCardBtn":
				Debug.Log ("called legal Highs");
				cardID =6;	
				break;
				

				
			default:
				Debug.Log ("unknown card button pressed");
				break;
			}
			
//once its identified which card to check the status of it'll show that card-provided the response was that the card is unloked.			
				
			if (GameController._instance.isCardUnlocked (cardID) == true) {
						Debug.Log ("i can show u taht card");
						//FindObjectWithName.ShowCard();
						enabled = true;
						ShowCard();

				} else {
									
			Debug.Log ("sorry the card is still locked");
						
				}


	//the is the call i'll be making to the gamecontroller with the param different depending on button that called it
		} 
	//clsoe thumbclicked
		
	public void ShowCard(){
		//gameObject.GetComponent<Button>().image.overrideSprite = null;

		//Debug.Log ("has: "+gameObject.GetComponent<Button>().);
		anim.enabled = true;
		anim.Play("PauseMenuSlideIn");

	}
	
	public void HideCard(){
		anim.Play("PauseMenuSlideOut");
		isPaused=false;
	}
		
	
				
	}