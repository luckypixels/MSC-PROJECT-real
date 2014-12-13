using UnityEngine;
using System.Collections;

public class DrinkFoodCollision : MonoBehaviour {


//this tells the game to generate the relevant score icon at the position where the collison with the drink/card/food object happened.

	public GameObject score;    //The gui object of te score that is shown after player collects item-use inspector to set relevant values.

	public void Hit()
	{
		
		//Spawn the score for this obj-the script for the score obj deals with destroying the instsance
		var localScoreGui=Instantiate(score,new Vector3(transform.position.x,transform.position.y,1),Quaternion.identity);
		//Destroy this object, obviously I have to call the score instatntiate 1st as it takes this object's position for its paramaters!
		Destroy(gameObject);
		
	}
}
