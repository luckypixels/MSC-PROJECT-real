using UnityEngine;
using System.Collections;


//this code is taken from jessse freeman's tutorial for lynda.com
//-if unity would hurry the hell up and release v.4.6 i would have access to real gui building with my art rather than their hideous awful ongui() methods



public class NextButton : MonoBehaviour {

	public string scene;

	private bool loadLock;


	// Use this for initialization
	void Start () {
	

	}




	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			//Run hit function
			LoadScene ();
		}
		}








	// Update is called once per frame
	void Update () {
	
		//using the jesse freeman uniy tut so the code is for mouse not touch
		if (Input.GetMouseButtonDown (0) && !loadLock)
						LoadScene ();

		if (Input.touchCount == 1 && !loadLock)
			LoadScene ();

	}




	void LoadScene (){
		loadLock = true;
		Application.LoadLevel (scene);
	
	}

	}


/*this goes straight into the game, think should hve a yield delay on the game or a 'ready?' dialogue 2 start*/



