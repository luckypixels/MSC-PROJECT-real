using UnityEngine;
using System.Collections;

public class SoundButton : MonoBehaviour {

	//need to find a way to make this setting be global amongst all the scenes

	//it might be better to have sound start as muted adn player can allow it-it sucks when a game makes loads of noise  by default when ur on a bus
	//but if have no sound at start up it looks like i forgot to include it or its not working.if have a 'enable sounds?' dialogue ask ppl if they like it or if its yet more annoying button presses added
	public GameObject prefabTest;
	bool soundMuted;
	// Use this for initialization

	void Awake(){
		soundMuted = true; //start the game with sounds turned off by default
	}

	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		/* COmmenting out since this isnt for pressing a button and going to screen its just a mouse click anuywhere on screen.
		if (Input.GetMouseButtonDown (0))       //u prat this isnt saying if button pressed ON THIS OBJECT its saying if pressed regardless of where!
		{Debug.Log ("sound button pressed");	}
		//soundButToggle();
	
			if (Input.touchCount == 1)
		{Debug.Log ("sound button pressed");
			Instantiate(prefabTest,new Vector3(0,0,0),Quaternion.identity);}
				//soundButToggle();
		}*/
	
}

/*

	void soundButToggle(){
		if (soundMuted) { //if sound muted is true set to false, else it must be set to false-so set it to true!
			soundMuted=0;		
		}
	else{soundMuted=1;}
	}

	Debug.LogType("soundMuted is set to"+SoundMuted);
	}
*/
}
