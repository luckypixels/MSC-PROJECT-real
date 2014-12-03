using UnityEngine;
using System.Collections;

public class PauseTestCubeRotate : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		print ("cube rotate");
		//transform.rotation = Quaternion.identity;
		transform.Translate(0,1*Time.deltaTime,0);
	}
}
