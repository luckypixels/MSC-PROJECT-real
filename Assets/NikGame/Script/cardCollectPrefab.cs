using UnityEngine;
using System.Collections;

/// <summary>
/// This script deals with the Info Card for the player to collect in each level.
/// As it will refer to a different depending on the current level it makes sense to put this on an object that 
/// gets a new instance in each level. either create a new empty 1 specifically for it 
/// (i suppose this object could be the collectable itself-instantiate at level awake and when the time to spawn the item
/// happens then add components of a sprite renderer and rigid body to give it gravity?-no cos its less easy to play with in inspector for debugging!!!)
/// tbh itd be best put on an empty obj or on the camera or similar. 
/// </summary>

public class cardCollectPrefab : MonoBehaviour {

	public GameObject score;    //The gui object of te score that is shown after player collects item
	public GameObject pickup; // the pick up prefab for this level.


	// Use this for initialization
	void Start () {
	//decide on a time and a position for when to spawn the prefab
	}



	// if the player gets the object:-
	public void Hit()
	{
		//Spawn the score for this obj
		var localScoreGui=Instantiate(score,new Vector3(transform.position.x,transform.position.y,1),Quaternion.identity);
		//Destroy this object, obviously I have to call the splat instatntiate 1st as it takes this object's position for its paramaters!
		Destroy(gameObject);
		//StartCoroutine(DeleteLocalScoreGUI(2.0F));
		//Destroy (localScoreGui);
		//TELL THE GAME CONTROLLER THAT THE RELEVANT CARD UNLOCKED AND SO CHANGE ITS BOOL VALUE
	}


	//otherwise they missed it and so need to destroy it from memory-if the player has missed it then its reached a certain Y value
	public void missedObjSoDestory(){
		//if(gameObject.y ==foo){Destroy(gameObject);}
	}



}
