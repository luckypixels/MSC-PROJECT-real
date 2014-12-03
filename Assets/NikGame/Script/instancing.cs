using UnityEngine;
using System.Collections;

public class instancing : MonoBehaviour {

	public GameObject prefab;

	// Use this for initialization
	void Start () {

		Instantiate (prefab);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
