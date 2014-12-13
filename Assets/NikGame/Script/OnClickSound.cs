using UnityEngine;
using System.Collections;

public class OnClickSound : MonoBehaviour {

	public AudioClip clickSound;

	// Use this for initialization
	void Start () {
	//	audio.PlayOneShot (clickSound);
	}
	
	public void Playsound () {
		audio.PlayOneShot (clickSound);
	}

}
