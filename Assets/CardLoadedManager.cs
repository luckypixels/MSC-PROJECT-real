using UnityEngine;
using System.Collections;

public class CardLoadedManager : MonoBehaviour {

	//probably also want a var that stoeres reference to current loaded so that way if card 1 is loaded and card 2 thum pressed can call card 1's hide();
	GameObject currentLoadedCard; //i it a game object? its a little confusig to knw wht datatype to declare since its an image of the ugui... 

	 bool isACardLoaded; //ITS PRIVATE BUT IMPLEMENT A PUBLIC METHOD FOR IT.

	// Use this for initialization
	void Start () {
	
	}

	public bool getCardLoadedStatus(){  //provide the method for the infoCardThumbnail buttons to check if theres a card tht needs removing
		return isACardLoaded; 
	}


//public method for the thumbnails on clicks to set the state depending if user has pressed to open or close a card
	public void setCardLoadedStatus( bool boolState){
		isACardLoaded = boolState;
		if (isACardLoaded) {                    //if its true theres a car already loaded so calls its hide animation
			//currentLoadedCard.GetComponent<foo>().Hide();
		}
	}

	//send the reference to the ccurrentLoaded with a method and as param (GameObject currentLoaded)
	//in the call send (gameObject) as the argument.  this all goes to shit of course if the ugui stuff has to be specified rather than generic gameobject


	// Update is called once per frame
	void Update () {
	
	}
}
