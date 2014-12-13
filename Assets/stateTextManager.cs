using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class stateTextManager : MonoBehaviour {

//the vars for the text labels in teh scene
	//the cards state text label
	public Text infoCardStateText1;
	public Text infoCardStateText2;
	public Text infoCardStateText3;
	public Text infoCardStateText4;
	public Text infoCardStateText5;
	public Text infoCardStateText6;
	
	

	// Use this for initialization
	void Start () {
		infoCardStateText1.text="the taxi card is: " + GameController._instance.taxiInfoCardUnlocked.ToString(); 
		infoCardStateText2.text="the battery card is: " + GameController._instance.batteryInfoCardUnlocked.ToString();
		infoCardStateText3.text = "the soft drinks card is: " + GameController._instance.softDInfoCardUnlocked.ToString ();
		infoCardStateText4.text= "the spiking card is: " + GameController._instance.spikingInfoCardUnlocked.ToString ();
		infoCardStateText5.text="the eat card is : "+ GameController._instance.eatInfoCardUnlocked.ToString();
		infoCardStateText6.text="the legalHighss card is: "+GameController._instance.highsInfoCardUnlocked.ToString();

	}

}//close clASS