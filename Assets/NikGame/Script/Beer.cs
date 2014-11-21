using UnityEngine;
using System.Collections;

//since the hit() method here is probably the same as in fruit i think either have this class inherit it, or have a generic class that all objs use with a hit method that affects score and sickness as params 



public class Beer : MonoBehaviour {
	public GameObject splat;	//The splat prefab
	public GameObject score;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

//the method to call upon a collision with a beer drink
	public void Hit(){

				Instantiate (splat, new Vector3 (transform.position.x, transform.position.y, 1), transform.rotation);
			var localScoreGui=Instantiate(score,new Vector3(transform.position.x,transform.position.y,1),Quaternion.identity);

				//Destroy this object, obviously I have to call the splat instatntiate 1st as it takes this object's position for its paramaters!
				Destroy (gameObject);
		}

}
