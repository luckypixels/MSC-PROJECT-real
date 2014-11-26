using UnityEngine;
using System.Collections;

public class collisionScores : MonoBehaviour {
	private Color randomAlpha;
	private float currentAlpha;
	
	void Start()
	{
		StartCoroutine("Fade");

	}


	IEnumerator Fade(){
		yield return new WaitForSeconds (0.75f);
		Destroy(gameObject);

	}

}