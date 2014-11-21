using UnityEngine;
using System.Collections;

public class MusicScript : MonoBehaviour {

	bool musicAlready;
	//telling the music to be persistent across the levels-only concern i have is if the other levels hav own version of  track playing so use if ststement to check
	void Awake() {
		if (musicAlready == false) { //if music isnt already playing then we can start playing music
						musicAlready = true;
						DontDestroyOnLoad (transform.gameObject);
				}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
