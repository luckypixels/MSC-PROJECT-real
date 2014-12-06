using UnityEngine;
using System.Collections;


public class Drinks : MonoBehaviour {

	//create an array to store the drinks and food values
	public string name;
	//it makes sense to declare these here but will that lead to spagetti code within the onHit() methods in other scripts? 
	public int units;
	public int score;


//THIS CLASS IS UTTERLY REDUNDANT YET WHEN I DELETED IT THE GAME COMPLETELY BROKE!!!
	//(EVEN AFTER REMOVING ALL REFS TO IT ON PREFABS)



	void OnCollisionEnter(Collision other){

		string GOname = other.collider.name;
		//if (other.collider.name != "BeerPint") {
			if (GOname.Contains("Beer") == true)
			{
			//	Debug.Log("BEER HIT ");
			}
			else
			{
			//	Debug.Log("not beer");
			}

	}
	

}//close the class