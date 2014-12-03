using UnityEngine;
using System.Collections;




public class NextButton : MonoBehaviour {

	void OnMouseDown(){

		Debug.Log ("begin game");
		Application.LoadLevel("LevelOne");
	}

}