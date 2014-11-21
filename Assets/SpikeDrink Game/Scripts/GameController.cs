using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	private int score;
	public int lives;
	// Use this for initialization
	void Start () {
		Debug.Log ("welcome to the new game");
		//just doing this to see if the call across the class is working
		score = 100;
		lives = 3;
	}


	//use a generator at set intervals with yield or 




	// Update is called once per frame
	void Update () {
	
	}

void killedEnemy(){
		score += 100;
	}


	public void setScore(int amount){

		score += amount;
		Debug.Log (score);
	}

	public void setLives(int amount){	
		lives+= amount;
		Debug.Log (lives);
	}

}
