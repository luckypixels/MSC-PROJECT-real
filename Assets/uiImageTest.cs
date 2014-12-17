using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class uiImageTest : MonoBehaviour {

	public Sprite sprite1;

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Image> ().sprite = sprite1;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
