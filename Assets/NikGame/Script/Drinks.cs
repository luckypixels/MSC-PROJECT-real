using UnityEngine;
using System.Collections;


public class Drinks : MonoBehaviour {

	//create an array to store the drinks and food values
	public string name;
	//it makes sense to declare these here but will that lead to spagetti code within the onHit() methods in other scripts? 
	public int units;
	public int score;
	// Use this for initialization
	void Start () {
		}
	
	// Update is called once per frame
	void Update () {
	
	}

//this is wonderful work that you've done Nik and u learnt a lot but seeing as ur checking for collisions with Player its ONTRIGGER u need u prat!!!
	//can't simply use the other.tag as in the Player Object becuase that only works for OnTrigger events and as drinks have gravity=rigidbody NOT Triggers
	//thankfully have other.collider.name, ffs dont use getcomponent as thats so expensive!
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