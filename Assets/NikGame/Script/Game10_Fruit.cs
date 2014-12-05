using UnityEngine;
using System.Collections;

public class Game10_Fruit : MonoBehaviour
{

	/*these vars are for if I choose to make a diff obj appear after collison 
	(for fruit game = 2 seperate halves of apple-this doesn't work so well with glass drinks!)
public GameObject left;		//The left prefab of the fruit

//public GameObject right;	//The right prefab of the fruit

	//public float force;	    //The left and right force
	//public float torque;		//The rotation speed after we are hit
	*/
	public GameObject score;    //The gui object of te score that is shown after player collects item
	private bool canBeDead;		//If we can destroy the object
	private Vector3 screen;		//Position on the screen
	private GameObject player;	//The player
	private float rotDir = 50;	//The rotate speed
	private int playerLives;

	//this is me trying to adapt it so its referencing the gamemanager and not the player
	private GameObject playerGameManager;	//the reference to the gamemanager
	private int playerGameManagerLives; //the reference to the lives var in the gamemanager


	void Start ()
	{
		//If we tag is Fruit
		if (gameObject.tag == "Fruit")
		{
			//Find player object to access vars like score and lives later on
			player = GameObject.Find("Player");
			playerLives =player.GetComponent<Game10_Player>().lives;
			//want to migrate from the lives and score vars being in Player class and isntead be in GameManager.
			//the code im using here isnt right in that GameManager is a singleton so i should just say GameManager._instance?
			playerGameManager = GameObject.Find("GameManager");
			//playerGameManagerLives =GameManager.GetComponent<GameManager>().lives;




		}

		//set the direction of rotation
		//If random is 1
		if (Random.Range(0,2) > 0)
		{
			//Change rotate speed
			rotDir = -rotDir;
		}
	}
	
	void Update ()
	{
		//Set screen position
		screen = Camera.main.WorldToScreenPoint(transform.position);
		//If we can die and are not on the screen-if the object's fallen off screen and hasn't been in collision with player (ie the player missed it)
		if (canBeDead && screen.y < -20)
		{
			//If this objects tag is Beer->this wont work cos this script isnt 
			if (gameObject.tag == "Beer")

			{
				//Remove 1 lives from the player
				playerLives--;
			}


			//If this objects tag is Fruit
		

			//Destroy
			Destroy(gameObject);
		}
		//If we cant die and are on the screen
		else if (!canBeDead && screen.y > -10)
		{
			//We can die
			canBeDead = true;
		}
		
		//Rotate-its only in z axis and is dampened with a speed (its frame rate independent)
		transform.Rotate(new Vector3(0,0,rotDir) * Time.deltaTime);
	}
	
	public void Hit()
	{

		//Spawn the score for this obj
		var localScoreGui=Instantiate(score,new Vector3(transform.position.x,transform.position.y,1),Quaternion.identity);
		//Destroy this object, obviously I have to call the splat instatntiate 1st as it takes this object's position for its paramaters!
		Destroy(gameObject);
		//StartCoroutine(DeleteLocalScoreGUI(2.0F));
		//Destroy (localScoreGui);
	}


	

}//close the class
