using UnityEngine;
using System.Collections;

public class infoCardPickUpSpawner : MonoBehaviour {
	


	//im using this class as a spawner object to handle the instantiate the pick up. Atm i only have 1 pick up the info card for whatever the currentl level
	//but i can resuse this class to create other objs just need to crete new member vars to pass to the instantiate method. 

	//also oter benefit is that i can tell objects that this instantiates to inherit the transform and rotation values of this obj.

	//public GameObject infocardPU; 
	public GameObject brick; //odd name yes but the bug doesnt seem to be happening since using the latest unity build and this variable so im not going to risk breaking it now!



	void Start () {
				//Instantiate(infocardToSpawn);
				//if (brick !=null) {   //this is deliberately left empty yet this 
				//		Debug.Log ("tested if not null and all is well!");
				//} else {
			//			Debug.Log ("tested if not null and its empty,pls assign");
			//	}


		//Invoke ("instantiatePickUp2", 4.0f);
	}

	//if time have this obj have random positions, otherwise wherever its set up in the scene view will suffice for v1.0
//work out time to call instatiate
//get reference to the timer-think it should be this class works out time to spawn, sends a request to the timer class and that mointors time
//when that time is met it calls the function back here to instantiate the 


	private int numOfTimesCalled=0;

	public void instantiatePickUp2(){

		Debug.Log ("going to (try to) spawn it");
		if (numOfTimesCalled < 1) {
				Instantiate (brick, transform.position, transform.rotation);
			numOfTimesCalled++;		
		}
		//use the current variables of this spawner object's vector3 position and rotation= defualt (.identity)

	}
	//public instantiatePickUp2();



}
