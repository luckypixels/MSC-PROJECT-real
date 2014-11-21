using UnityEngine;
using System.Collections;

public class SplatNik : MonoBehaviour {

	private Color randomAlpha;
	private float currentAlpha;

	// Use this for initialization
	void Start () {
		randomAlpha = new Color (1, 1, 1, Random.Range (0.3f, 0.5f));
		gameObject.renderer.material.color = randomAlpha;
		InvokeRepeating ("ReducingAlpha", 0.3f, 0.3f);
	}

	void ReducingAlpha (){
		currentAlpha = gameObject.renderer.material.color.a;

		if (gameObject.renderer.material.color.a <= 1.0f) {
						Destroy (gameObject);
				}
		else {
			gameObject.renderer.material.color=new Color (1,1,1, currentAlpha-0.1f);
		}
	
	}



	// Update is called once per frame
	void Update () {
	
	}
}
