using UnityEngine;
using System.Collections;

public class SpikeEnemy : MonoBehaviour {

	int touchCount; //var to see ow may times the player has tapped on the object
	//want the objects to move at slightly different speed
	
	int speed; //the speed that this instance of the enemy moves at. is set a random value in the start method


	// Use this for initialization
	void Start () {
	speed = Random.Range (4, 8);
	}
	
	// Update is called once per frame
	void Update () {
				//For the sake of quick development im gonna use the mouse for testing on my macbook as well as having the final touch based for iOS
				if (Input.GetMouseButtonDown (0))
						touchCount++;
				if (touchCount == 3) {
						DestroyEnemy ();
				}

	//on iPad
		if (Application.platform == RuntimePlatform.IPhonePlayer) {
						//If we are hitting the screen
						if (Input.touchCount == 3) {
								DestroyEnemy ();
						}
				}
	
	}




	void  FixedUpdate() {
		//Debug.Log (speed);
		rigidbody.AddForce(Vector3.left *speed);
	}




	//on cvollison with the drink onject
	
	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "Drink") {
			//Destroy(other);
			//DestroyEnemy();
			
		}
		//decrease the score in the gamecontroller object
	}//Close collison






	public void DestroyEnemy(){
		Destroy (gameObject);
	}

}
