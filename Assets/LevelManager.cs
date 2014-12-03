using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {


	public float delayTime=1f; //so i can set the length of the wait to difftimes vis the inspector
	/*
heres something i need to test-how long is too long a delay (makes u think app crashed) vs how short is 'woah wait im not ready!'
	 */




	//want this to be a global object so tell it to never destroy onload. Would be a good idea to make this a singleton
	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}

	// Use this for initialization
	void Start () {
		//whatLevel ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	//check which level is currently loaded
	public void whatLevel(){
		Debug.Log (Application.loadedLevelName);
	}


/*
 -this is a rather messy way to have to do this but the unity workflow wont allow the button to call an enumerator method directly
	 */
//might be able to work on this so that a parm of current level is sent with the button press and have diff buttons functions in here 
	public void nextBtnPressed(){
		Debug.Log ("the button was pressed");
		StartCoroutine(LoadAfterDelay(Application.loadedLevel+1));
	}


	IEnumerator LoadAfterDelay(int levelName){
		yield return new WaitForSeconds(delayTime);
		Application.LoadLevel(levelName);

	
	}

	/*
    IEnumerator LoadAfterDelay(string levelName){
    yield return new WaitForSeconds(10); // wait 10 seconds
    Application.LoadLevel(levelName);
    }
     

    StartCoroutine(LoadAfterDelay("Level02"));

	 */

//----------------------JUST TO CHECK THAT THIS OBJ IS STILL IN THE GAME ACROSS THE LEVELS-THERES A BETTER WAY TO DO THIS WITH SINGLETOS BUT FOR NOW THIS'LL DO
	public void levelManagerCheck(){
		Debug.Log ("levelManager Still alive");
	}





}//close class
