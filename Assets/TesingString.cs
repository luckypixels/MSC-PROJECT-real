using UnityEngine;
using System.Collections;

public class TesingString : MonoBehaviour {

	private string hello;

	// Use this for initialization
	void Start () {
	
		hello="fuck off";
//		if (hello.Contains ("PISS FLAPS")) {
//				Debug.Log ("hello contains: " + hello);
//			}
//
//		else{Debug.Log ("hello doesnt contain that");}
//
		if (Application.loadedLevelName.Contains ("Level")==false) {
			Debug.Log ("this is testing the level name 2");
		}
		
		else{Debug.Log ("hello doesnt contain that");}

	
	
	
	}
	

}
