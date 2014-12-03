using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	private int score; //have to use this even tho NOTHING is referenving this script, its justa  testament to how useless unity really is.
	public int lives;
	// Use this for initialization
	void Start () {
		Debug.Log ("welcome to the new game");
		//just doing this to see if the call across the class is working

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
