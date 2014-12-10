using UnityEngine;
using System.Collections;

public class DrinkFoodCollision : MonoBehaviour {

	public GameObject score;    //The gui object of te score that is shown after player collects item
	private bool canBeDestroyed;		//If we can destroy the object-ie the obj hasnt been collected by playe
	private Vector3 screen;		//Position on the screen
	//private int playerLives; -this is now redundant as im using a direct call to the singleton class
	
	/// <remarks>
	/// to be honest i havent got a clue whats going on with this code atm, i think a lot of its redundant since its using 'fruit tags'. need to look into it to see if can delete/clean up cos its got a gameobject find in update ffs!
	/// -By that i mean the stuff about rotatiin in start and the tag for beer is illogical-i think this is left over from the template and most can be deleted...
	/// 
	/// </remarks>
	


	//---------------------------------------The collision event for the obect----------------------	
	public void Hit()
	{
		
		//Spawn the score for this obj-the script for the score obj deals with destroying the instsance
		var localScoreGui=Instantiate(score,new Vector3(transform.position.x,transform.position.y,1),Quaternion.identity);
		//Destroy this object, obviously I have to call the score instatntiate 1st as it takes this object's position for its paramaters!
		Destroy(gameObject);
		
	}
}//clsoe class

