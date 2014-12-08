using UnityEngine;
using System.Collections;

/// <summary>
///if i make all the objects have 1 class then 99% of time the reference to player is useless but i could make this 
/// a subclass of the genereric obj with the reference to player as a member exclusive to this class.
/// </summary>




public class Game10_Bomb : MonoBehaviour
{
	private bool canBeDestroyed;		//If we can destroy the object-ie the obj hasnt been collected by player
	private Vector3 screen;		//Position on the screen
	private GameObject player;	//The player this script uses it as it needs to access the lives var in player
	public GameObject score;    //The gui object of te score that is shown after player collects item

	void Start ()
	{
		//Find the player
		player = GameObject.Find("Player");
	}
	
	void Update ()
	{
		//Set screen position
		screen = Camera.main.WorldToScreenPoint(transform.position);
		//If the object is still alive and has gone off screen then the player didnt collect it so destory the object to free up memory
		if (canBeDestroyed && screen.y < -20)
		{
			//Destroy it.
			Destroy(gameObject);
		}
		//when object is instantiated it defaults to canBeDestroyed==false so when it is above certain point on screen, active its ability to be destoryed:
		else if (!canBeDestroyed && screen.y > -10)
		{
			//We can die
			canBeDestroyed = true;
		}
		
		//Rotate
		transform.Rotate(new Vector3(0,0,50) * Time.deltaTime);
	}
//---------------------------------------The collision event fr the obect----------------------	
	public void Hit()
	{
		//lose a life
		player.GetComponent<Game10_Player>().lives--;
		var localScoreGui=Instantiate(score,new Vector3(transform.position.x,transform.position.y,1),Quaternion.identity);
		//Destroy this object, obviously I have to call the splat instatntiate 1st as it takes this object's position for its paramaters!
		Destroy(gameObject);
		//Destroy
		Destroy(gameObject);
	}
}
