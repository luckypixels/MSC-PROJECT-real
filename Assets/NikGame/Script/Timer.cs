using UnityEngine;
using System.Collections;
using UnityEngine.UI;  // ALLOWS using the new 4.6 UI biuilder components


public class Timer : MonoBehaviour {
	public int timeForLevel; 
	public Text countdown; //the new UI textlabel so ensure when i use it that i use the UnityEngine.UI import!


	private float timeToSpawnPickUp;  

	public GameObject infocardSpawner;



//-----------------------------------------------------METHODS------------------------------------------------------------------------------------

	/*
	//want to access the infocardpickup object to tell it to become active;
	//GetComponent<InfoCardPickUp>().movePrefabAndIncreaseColour();
 */

	void Awake(){
		//decide when to create the pickup
		timeToSpawnPickUp= Random.Range(5,57);  //this means tht the prefab wont be created too early or too close to end of level to be fairer on player 
		Debug.Log ("going to spawn at: "+timeToSpawnPickUp);
	}		




	void Start () {
		//new 4.6 ui element:
		countdown = gameObject.GetComponent<Text>();
		countdown.text="Time : " + timeForLevel;
		
		//tell it to countdown each second
		InvokeRepeating("ReduceTime", 1, 1); //(param1 =time til 1st call, 2nd param=interval between calls)

		//get ref to the spawner
		if (infocardSpawner == null) {
			GameObject.Find("InfoCardspawner");		
		} 



		}//close start


	void Update(){  //if not using this delete it cos it still does empty update events so will slow performance.
		
		if (timeForLevel == timeToSpawnPickUp) { //if the time matches call the function which is in the spawner obj
			Debug.Log ("going to call instantiator");
			infocardSpawner.GetComponent<infoCardPickUpSpawner>().instantiatePickUp2();			
		}
	}
	
	//method for reducing the time and saying level complete if out of time
	void ReduceTime()
	{
		if (timeForLevel > 0) {
			timeForLevel--;
			countdown.text = "Time : " + timeForLevel;
		}
		if (timeForLevel == 0) {
			countdown.text = "Level Complete!";
			Debug.Log ("TIMES UP!");
			goNextLevel();




		}
	}//close reducetime


	/*


	 */






	void goNextLevel(){
		if(Application.loadedLevel!=Application.levelCount && Application.loadedLevelName!="LevelSix") //need to check this isnt last level-means can add & delete levels but trade off is i'll need to put all non gameplay scenes B4 game itself in build settings in menu->plyBtn MUST call level1 by name and not currentllevel+1
			Application.LoadLevel (Application.loadedLevel+1);
		Debug.Log ("should be going to next level");
	}



	//method to reload the game-sync it with a button that is loaded when the time is over/player lost etc	
	public void Reload()
	{
		Application.LoadLevel (Application.loadedLevel);
	}
	
	
	

}//close the class


//////////////////////////////////////

