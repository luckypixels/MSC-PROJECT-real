using UnityEngine;
using System.Collections;

/*
code taken from a tuts+ tutorial at:
http://code.tutsplus.com/tutorials/create-a-fruit-ninja-inspired-game-with-unity--cms-22145?utm_source=Tuts+&utm_medium=website&utm_campaign=relatedtutorials&utm_content=sidebar&WT.mc_id=Tuts+_website_relatedtutorials_sidebar
 */



public class Timer : MonoBehaviour {

	//vars

	public GUIText timeTF;
	//the time gui object

	public GameObject alertReference;
	//the alert message prefab

	// Use this for initialization
	void Start () {
	//fimd the guiText object with time displayed
		timeTF = gameObject.guiText;
		timeTF.text="hi nik";
		//tell it to countdown each second
		InvokeRepeating("ReduceTime", 1, 1);

	}



	//method for reducing the time and saying game overif out of time
	void ReduceTime()
	{
		/*
		 //use getComponent to check the time on the other script but do it instart of this or even combine this with the Player script cos getComponent in this function called every second will be horrific for performance!
		if (timeTF.text == "1")
		{

			
			Time.timeScale = 0;
			Instantiate(alertReference, new Vector3(0.5f, 0.5f, 0), transform.rotation);
			audio.Play();
			GameObject.Find("AppleGUI").GetComponent<AudioSource>().Stop();
		}

		//reduce the time by 1, need to use the string parsing as its taking string to int for the calculation then sending string info
		//timeTF.text = (int.Parse(timeTF.text) - 1).ToString();
*/
}




//method to reload the game 	
	void Reload()
	{
		Application.LoadLevel (Application.loadedLevel);
	}









	// Update is called once per frame
	void Update () {
	
	}
}
