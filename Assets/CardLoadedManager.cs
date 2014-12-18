using UnityEngine;
using System.Collections;

public class CardLoadedManager : MonoBehaviour {


	public GameObject card1;
	public GameObject card2;
	public GameObject card3;
	public GameObject card4;
	public GameObject card5;
	public GameObject card6;

	public GameObject thumb1;
	public GameObject thumb2;
	public GameObject thumb3;
	public GameObject thumb4;
	public GameObject thumb5;
	public GameObject thumb6;





//	//need to check what carsds are unlocked when the scene awakes
//	if (GameController._instance.isCardUnlocked (cardID) == true) {
//		//Debug.Log ("i can show u taht card");
//		//FindObjectWithName.ShowCard();
//		enabled = true;
//		//ShowCard();
//		
//	} else {
//






	//probably also want a var that stoeres reference to current loaded so that way if card 1 is loaded and card 2 thum pressed can call card 1's hide();
	GameObject currentLoadedCard; //i it a game object? its a little confusig to knw wht datatype to declare since its an image of the ugui... 

	public bool isACardLoaded; //PROBABLY IT SHOULD BE§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§§ PRIVATE BUT IMPLEMENT A PUBLIC METHOD FOR IT.

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


///////////////////////////////////////
	/*
	 void Awake(){
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
	
}
	 
	*/

