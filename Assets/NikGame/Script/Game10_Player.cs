using UnityEngine;
using System.Collections;

public class Game10_Player : MonoBehaviour
{
	public GUISkin skin;	//GUI Skin
	public int score;		//Score
	public int lives;		//Lives

	public int sickness; //the health


	private Vector3 pos;	//Position that the touch occured
	private bool dead;		//If we are dead
	
	void Start ()
	{
		sickness = 0;
		//Set screen orientation to landscape
		Screen.orientation = ScreenOrientation.Landscape;
		//Set sleep timeout to never ie dont let the screen go to sleep if inactive
		Screen.sleepTimeout = SleepTimeout.NeverSleep;

	}
	
	void Update ()
	{
		//If dead
		if (dead)
		{
			//Set collider to false
			collider.enabled = false;
			return;
		}
		//If we have 0 lives left
		if (lives < 1||sickness>=100)
		{			
			//Kill
			Debug.Log ("UR DEAD");
			dead = true;
			//Set collider to false
			collider.enabled = false;
		}
		
		//If the game is running on a touch device
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			//If we are hitting the screen
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
		//If the game is not running on a touch device which is worth doing since running unity remote is soooo slow
		else
		{
			//Find mouse position
			pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
			//Set position
			transform.position = new Vector3(pos.x,pos.y,0);
		}
	}

	/*
NEED TO ADD THE CLASSES FOR SOFTDRINK AND FOOD COS UR CALLING THE BURGER COMPONENT STILL!
-this is getting really ugly having so many different classes for each type of object-maybe put all functions in a 'onHit' class or have 1 
funtion there with switchstatements to see what change to score etc. 
	 */



	void OnTriggerEnter(Collider other)
	{
		//If player hits a drink other than a beer, then they've mixed their drinks which increases sickness lots
		//if they have a softdrink or eat some food they decrease their sickness

		//this is getting to be a lot of different else ifs-change to a switch for v2.0!!!
		if (other.tag == "Fruit")
		{
			//Run hit function
			other.GetComponent<Game10_Fruit>().Hit();
			score -= 5;
			sickness+=10;
		}
		//If we hit poison (want to change to be lose a life rather than instant game over?)
		else if (other.tag == "Enemy")
		{
			//Run hit function
			other.GetComponent<Game10_Bomb>().Hit();
		}

		else if (other.tag == "Beer")
		{
			//Run hit function
			other.GetComponent<Beer>().Hit();
			//Add score
			score += 10;
			sickness+=1;
		}

		else if (other.tag == "SoftDrink")
		{
			//Run hit function
			other.GetComponent<Beer>().Hit();
			//Add score
			score += 10;
			sickness-=5;
		}


		else if (other.tag == "Food")
		{
			//Run hit function
			other.GetComponent<Beer>().Hit();
			//Add score
			score += 100;
			sickness-=5;
		}


	
	}
	
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
				Application.LoadLevel("Menu");
			}
		}	
	}







}