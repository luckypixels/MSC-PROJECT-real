using UnityEngine;
using System.Collections;

public class burgerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log ("hi fromm burger");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void onCollisionEnter2D(Collision2D other){
		Debug.Log ("hit the burger");
	}



}
