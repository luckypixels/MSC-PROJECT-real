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
	
	
	//THE LEVELs state text -as level one is unlcoked  by default theres no need to include it here
	public Text LevelStateText2;
	public Text LevelStateText3;
	public Text LevelStateText4;
	public Text LevelStateText5;
	public Text LevelStateText6;





	// Use this for initialization
	void Start () {
		LevelStateText6.text = "level 2 is: " + GameController._instance.level2Unlocked.ToString(); 
		LevelStateText2.text = "level 3 is: " + GameController._instance.level3Unlocked.ToString ();
		LevelStateText3.text="level 4 is: " + GameController._instance.level4Unlocked.ToString ();
		LevelStateText4.text="level 5 is: " + GameController._instance.level5Unlocked.ToString();
		LevelStateText5.text="level 6 is: " + GameController._instance.level6Unlocked.ToString();

		infoCardStateText1.text="the taxi card is: " + GameController._instance.taxiInfoCardUnlocked.ToString(); 
		infoCardStateText2.text="the battery card is: " + GameController._instance.batteryInfoCardUnlocked.ToString();
		infoCardStateText3.text = "the soft drinks card is: " + GameController._instance.softDInfoCardUnlocked.ToString ();
		infoCardStateText4.text= "the spiking card is: " + GameController._instance.spikingInfoCardUnlocked.ToString ();
		infoCardStateText5.text="the eat card is : "+ GameController._instance.eatInfoCardUnlocked.ToString();
		infoCardStateText6.text="the legalHighss card is: "+GameController._instance.highsInfoCardUnlocked.ToString();

	}

}//close clASS