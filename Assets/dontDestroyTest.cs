using UnityEngine;
using System.Collections;

public class dontDestroyTest : MonoBehaviour {
	
	
	private static dontDestroyTest instance = null;  //its private-only this gets called by the class
	public static dontDestroyTest Instance { // the public version 
		get { return instance; }
	}
	void Awake() {
		transform.Translate(0, 0, 0); //inital co-ordinates for object-ie if upon reloading room the object hasnt reset and theres no other instances at the reset then this code is woking peachy!!!!
		if (instance != null && instance != this) { 
			Destroy(this.gameObject);
			return;
		} 
		else {
			instance = this;
		}
		
		DontDestroyOnLoad(this.gameObject); //make this instance persist
		
	}
	
	//
	void Update(){
		//	//this movement is just so i can visually see if the objects r duplicated
		transform.Translate(Time.deltaTime, 0, 0, Camera.main.transform);
	}
	

	public void GoNext(){
		Application.LoadLevel (Application.loadedLevel+1);

	}




	
	/*
 //ORIGINAL SCRIOT FROM FORUM POST:
private static MyUnitySingleton instance = null;
public static MyUnitySingleton Instance {
get { return instance; }
}
void Awake() {
if (instance != null && instance != this) {
Destroy(this.gameObject);
return;
} else {
instance = this;
}
DontDestroyOnLoad(this.gameObject);
}
	 */
	
	
	
	
	
	
	
	
	
	
	
	/*
		
//		//public static reference that can be accesd from anywhere
//		public static dontDestroyTest Instance {
//			get;
//			private set;
//		}

	int instanceCount;
		
			
		void Awake()
		{
	
//			//First we check if there are any other instances conflicting
//			if (Instance != null && Instance != this)
//			{
//				//Destroy other instances if they are different
//				Destroy(gameObject);
//			}
//			
//			//Save the current singleton instance
//			Instance = this;
			
			//make this object persistent
			DontDestroyOnLoad(gameObject);
		instanceCount++;
		Debug.Log(instanceCount);
		

		}

	






*/
	
}//class




