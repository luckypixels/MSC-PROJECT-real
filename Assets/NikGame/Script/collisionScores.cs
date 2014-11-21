using UnityEngine;
using System.Collections;

public class collisionScores : MonoBehaviour {

	//so theres a mistake in the the iENUmerator part of this as the call to destory without a delay works fine but
	//adding a delay, the method isnt ever called...
	
	void Start () {
		//SpriteRenderer renderer = gameObject.GetComponent(SpriteRenderer); 
		//Example ();
		Fade();
		//destroyNoDelay()
	}


	void destroyNoDelay(){
		Destroy(gameObject);

	}

	IEnumerator Example() {
		print("HELLO FROM COLLISON SCRIPT");
		yield return new WaitForSeconds(1);
		Destroy(gameObject);
	}

//from the unity docs
	IEnumerator Fade() {
		for (float f = 1f; f >= 0; f -= 0.1f) {
			Color c = renderer.material.color;
			c.a = f;
			renderer.material.color = c;
			yield return null;
		}
	}








}