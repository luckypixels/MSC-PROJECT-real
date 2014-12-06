using UnityEngine;
using System.Collections;

public class Game10_Player : MonoBehaviour
{
	public GUISkin skin;	//GUI Skin
	public int score;		//Score
	public int lives;		//Lives
	//since these are going to be used in the singleton class its not quite the same as here where need to have local refs-so does that mean the if lives==0 -> game over should be in the gamecontroller?





	private GameObject sickFace;
	public int sickness; //the health

	//int timeLeft=getComponent<Timer>.timeForLevel;

	private Vector3 pos;	//Position that the touch occured
	private bool dead;		//If we are dead
	
	void Start ()
	{
		//reset sickness in each level, or could have it so the var is persisitent across levels.
		//sickness = 0;

		///<remarks>The screen orientation and sleep timeout code is taken from the template</remarks>
		//Set screen orientation to landscape
		Screen.orientation = ScreenOrientation.Landscape;
		//Set sleep timeout to never ie dont let the screen go to sleep if inactive
		Screen.sleepTimeout = SleepTimeout.NeverSleep;

		//sickFace = GameObject.Find("sickFaces");
	}
	
	void Update ()
	{
		//TODO
		//put the sickness stuff with a proper gui thing-dont waste time doing it now cos theres a cool new trick can do with the 4.6 gui slider!
		//Debug.Log ("sickness=" +sickness);


		/*
		Allow me to skip between levels
		 */
		if (Input.GetKeyDown (KeyCode.Space)) {
			Debug.Log ("pressed level skip");
			StartCoroutine("goToNextLevel");//using this syntax rather than functionname() as param as that syntax wont work with StopCoroutine.		
		}



		//If the player has died then they shouldn't be able to interact with the objects (check this isnt going to conflict with gui ie restart button)
		if (dead)
		{
			collider.enabled = false;
			return;
		}
		//If we have 0 lives left
		if (lives < 1||sickness>=100)
		{			
			//Kill
			Time.timeScale=0; //this pauses the game
			dead = true;
			//Set collider to false-why have i repeated the code since its in the if(dead)-try commenting out to make sure its not used and so can safely delete
			collider.enabled = false;
			if(sickness>=100){
				Debug.Log ("Game over-u puked");
			}

		}

		//This code for touch repsonse is taken from the Android template, however its nothing that isnt in any tutorial. obviosy i ahd to chanf platfrom from droid to iOS
		//If the game is running on a touch device
		if (Application.platform == RuntimePlatform.IPhonePlayer) 
		{
			//If  the palyer touches the screen
			if (Input.touchCount == 1)
			{
				//Find screen touch position
				pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 1));
				//Set position
				transform.position = new Vector3(pos.x,pos.y,0);
				//Set collider to true
				collider.enabled = true;
				return;
			}
			//Set collider to false
			collider.enabled = false;
		}
		//code for quickly testing the game on macbook rather a touch device (which is worth doing since running unity remote is soooo slow)
		else
		{
			//Find mouse position
			pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
			//Set position
			transform.position = new Vector3(pos.x,pos.y,0);
		}


		//should i put the call to the sickFaces class here?




	}



	/// <summary>
	/// /This code is for collisions with the drinks and other objects. 
	/// Sticking to beer will increase sickness a small amount but any other alcoholic drink will mean they mixed their
	/// drinks and thus get sick quickly.
	/// </summary>
	void OnTriggerEnter(Collider other)   
	{
				//If player hits a drink other than a beer, then they've mixed their drinks which increases sickness lots
				//if they have a softdrink or eat some food they decrease their sickness

				//this is getting to be a lot of different else ifs-change to a switch for v2.0!!!

			switch (other.tag) {
				//	case "Fruit":
					case "badAlcohol":
			other.GetComponent<alcoholicDrink>().Hit();
					score -= 50;
					sickness+=15;
						break;
	
					case "Beer":
			other.GetComponent<Beer>().Hit();
			//Add score
			score += 10;
			sickness+=5;

						break;	


		case "SoftDrink":
			other.GetComponent<Beer>().Hit();
			//Add score
			score += 50;
			sickness-=5;
			break;	

		case "Food":
			other.GetComponent<Beer>().Hit();
			//Add score
			score += 100;
			sickness-=10;
			break;	



		case "Enemy":
			other.GetComponent<Game10_Bomb>().Hit();
			score -= 200;
			sickness +=20;
			break;

				default:
						Debug.Log ("Default case");
			score += 0;
			sickness +=0;
						break;
				}

		Debug.Log (sickness);
		}





//currently this is the templates default gui. dont like it but need to have a menu of buttons since iphones dont have the phsyical back buttons of (pre current gen) android devices
	void OnGUI()
	{
		GUI.skin = skin;
		
		//Score
		GUI.Label(new Rect(10,10,300,300),score.ToString());
		
		//If dead
		if (dead)
		{
			//Show "Lives: 0"
			GUI.Label(new Rect(10,Screen.height - 35,300,300),"Lives: 0");
		}
		else
		{
			//Show lives left
			GUI.Label(new Rect(10,Screen.height - 35,300,300),"Lives: " + lives.ToString());
		}


		//Menu Button
		if(GUI.Button(new Rect(Screen.width - 120,0,120,40),"Menu"))
		{
			//Load Menu scene
			Application.LoadLevel("MainMenu");
		}


		//If dead
		if (dead)
		{
			//Play Again Button
			if(GUI.Button(new Rect(Screen.width / 2 - 90,Screen.height / 2 - 60,180,50),"Play Again"))
			{
				Application.LoadLevel(Application.loadedLevel);
			}

			//Menu Button
			if(GUI.Button(new Rect(Screen.width / 2 - 90,Screen.height / 2,180,50),"Menu"))
			{
				Application.LoadLevel("MainMenu Real");
			}
		}	

}


	/*Go to next Level*/

IEnumerator goToNextLevel(){
	//if (Application.loadedLevel >= Application.levelCount) 
	//	{ //if this is the last level then we wont be able to go a next level-ret to main menu-except this makes the script break so ignore it for now!!!
			Debug.Log ("ienumerator method called");
			yield return new WaitForSeconds (1.5f);
			Application.LoadLevel (Application.loadedLevel + 1);
	//}
}




}
