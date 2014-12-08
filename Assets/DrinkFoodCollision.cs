﻿using UnityEngine;
using System.Collections;

public class DrinkFoodCollision : MonoBehaviour {

	public GameObject score;    //The gui object of te score that is shown after player collects item
	private bool canBeDestroyed;		//If we can destroy the object-ie the obj hasnt been collected by playe
	private Vector3 screen;		//Position on the screen
	private float rotDir = 50;	//The rotate speed
	//private int playerLives; -this is now redundant as im using a direct call to the singleton class
	
	/// <remarks>
	/// to be honest i havent got a clue whats going on with this code atm, i think a lot of its redundant since its using 'fruit tags'. need to look into it to see if can delete/clean up cos its got a gameobject find in update ffs!
	/// -By that i mean the stuff about rotatiin in start and the tag for beer is illogical-i think this is left over from the template and most can be deleted...
	/// 
	/// </remarks>
	
	/*
	void Start ()
	{
	
	//set the direction of rotation
	//If random is 1
	if (Random.Range(0,2) > 0)
	{
		//Change rotate speed
		rotDir = -rotDir;
	}
}
*/
	void Update ()
	{

		Debug.Log (GameController._instance.lives);
		//Set screen position
		screen = Camera.main.WorldToScreenPoint(transform.position);
		//If the object is still alive and has gone off screen then the player didnt collect it so destory the object to free up memory
		if (canBeDestroyed && screen.y < -20)
		{
			//If this objects tag is Beer->this wont work cos this script isnt 
			if (gameObject.tag == "Beer") 
				//why have i written it so that u lose a life for collecting beer-its meant to be if tag==bomb!
			{
				//Remove 1 lives from the gameController
				//playerLives--;is now redundant as im using a direct call to the singleton class
				
				/////////------------I DONT THINK THIS IS BEING CALLED COS IM NOT SEEING THE DEBUG!---------------------------
				GameController._instance.lives--;
				Debug.Log("lives from singleton: "+ GameController._instance.lives.ToString());
			}
			
			
			//Destroy
			Destroy(gameObject);
		}
		//when object is instantiated it defaults to canBeDestroyed==false so when it is above certain point on screen, active its ability to be destoryed:
		else if (!canBeDestroyed && screen.y > -10)
		{
			//We can die
			canBeDestroyed = true;
		}
		
		//Rotate-its only in z axis and is dampened with a speed (its frame rate independent)
		transform.Rotate(new Vector3(0,0,rotDir) * Time.deltaTime);
	}
	
	//I could be wrong but i think that the hit method may be the only part of this script that needs to be kept
	//probably the above is from me not knowing what parts needed to be used from template script so i kept in case was important
	//.Hit() certainly is called for beer.cs and stuff so look in player class to see if this ever gets called (think beer is for good alcoholic drink and this is objs like wine and cocjtail where not a good obj but not as bad as poision obj...)
	
	//in fact look at the warnings that are in teh console-a lot say theres vars in this class that arent used!
	
	//---------------------------------------The collision event for the obect----------------------	
	public void Hit()
	{
		
		//Spawn the score for this obj-the script for the score obj deals with destroying the instsance
		var localScoreGui=Instantiate(score,new Vector3(transform.position.x,transform.position.y,1),Quaternion.identity);
		//Destroy this object, obviously I have to call the score instatntiate 1st as it takes this object's position for its paramaters!
		Destroy(gameObject);
		
	}
}//clsoe class
