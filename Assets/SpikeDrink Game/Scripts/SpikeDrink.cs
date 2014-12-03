using UnityEngine;
using System.Collections;

public class SpikeDrink : MonoBehaviour {


	GameObject controller; // this is a ref to the game controller object that controls score and time etc
	int score;//obvious
	GameObject other; //  this is the other that is used in a collision, need class scope so i can call with 
	//rather than create this extra var i'd prefer to set a gameObject param in DestroyObject and pass the var used in OnCollision in the call. BUT I think Invoke wont allow calling with argumets?!
	int lives;
	//for referencing the vars and methods of the controller
	private GameController gameController;

	//seems that i need 2 make full full getcomponent... call eachtime to access vars and methods (check in proper tuts cos surely local ref var. would suffice)
	void Start () {
		controller = GameObject.Find("Controller");
		controller.GetComponent<GameController>().setScore (10);
		lives=controller.GetComponent<GameController>().lives;
		Debug.Log ("the lives var is: "+lives);

	}
		 void OnCollisionEnter(Collision ColOther){
		if (ColOther.gameObject.tag == "Enemy") {
			other=ColOther.gameObject; //set the class scope var of the collision so that it can be referred in the DestroyObjects method

			//lose a life
			controller.GetComponent<GameController>().setLives(-1);
			//controller.setLives(-1);
			//Debug.Log("lives :" +gameController.lives);

			Invoke("DestroyObjects",0.5f);//destroy the game objects

		}
		//decrease the score in the gamecontroller object
		}//Close collison


	//destory the drink and destroy the other object in the collision
void DestroyObjects(){
	Destroy(other);
	Destroy(gameObject);}





		}//Close class






	
