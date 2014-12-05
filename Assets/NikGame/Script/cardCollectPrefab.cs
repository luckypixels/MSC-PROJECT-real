using UnityEngine;
using System.Collections;

public class cardCollectPrefab : MonoBehaviour {

	public GameObject score;    //The gui object of te score that is shown after player collects item



	// Use this for initialization
	void Start () {
	
	}
	public void Hit()
	{
		//Spawn the score for this obj
		var localScoreGui=Instantiate(score,new Vector3(transform.position.x,transform.position.y,1),Quaternion.identity);
		//Destroy this object, obviously I have to call the splat instatntiate 1st as it takes this object's position for its paramaters!
		Destroy(gameObject);
		//StartCoroutine(DeleteLocalScoreGUI(2.0F));
		//Destroy (localScoreGui);
	}

}
