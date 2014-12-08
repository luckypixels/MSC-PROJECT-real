using UnityEngine;
using System.Collections;
using UnityEngine.UI;  // the new 4.6 UI biuilder components




public class Timer : MonoBehaviour {

	//vars
	public int timeForLevel=10; //the time duration of the level, set to public so i can tweak in inpsector (and can set low for quick playtesting!) 
	public Text countdown; //the new UI so ensure when i use it that i use the UnityEngine.UI import!


	// Use this for initialization
	void Start () {
		//new 4.6 ui element:
		countdown = gameObject.GetComponent<Text>();
		countdown.text="Time : " + timeForLevel;

		//tell it to countdown each second
		InvokeRepeating("ReduceTime", 1, 1); //(param1 =time til 1st call, 2nd param=interval between calls)
	
	}//close start



	//method for reducing the time and saying game overif out of time
	void ReduceTime()
	{
		if (timeForLevel > 0) {
						timeForLevel--;
						countdown.text = "Time : " + timeForLevel;
			//Debug.Log (timeForLevel);

		}
				if (timeForLevel == 0) {
			countdown.text = "Level Complete!";
			//Time.timeScale = 0; //pauses game -i want to use this and indeed i should but it stops any other code running which  make it seemnthe apps crashed!!!
			Debug.Log ("TIMES UP!");
			StartCoroutine("goNextLevel");
			//tell the gameContoller the next level is unlocked.
			tellGCUnlockNextLevel();
		}
}//close reducetime


	/*moving the code cos its as if u cant code after an inemurator*/
	
	//method to reload the game-sync it with a button that is loaded when the time is over/player lost etc	
	public void Reload()
	{
		Application.LoadLevel (Application.loadedLevel);
	}
	
	public void tellGCUnlockNextLevel(){   //the the GameController that the level was completed so it can unlock the next 1
		//GameController._instance.level2Unlocked=true;//
		GameController._instance.unlockLevel (Application.loadedLevelName);
	}
	





	IEnumerator goNextLevel(){
		Debug.Log ("coroutiene called");
		yield return new WaitForSeconds (2.0f);
		Application.LoadLevel (Application.loadedLevel+1);
		}



}//close the class
