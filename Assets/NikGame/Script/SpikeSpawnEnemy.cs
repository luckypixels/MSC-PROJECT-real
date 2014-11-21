using UnityEngine;
using System.Collections;

public class SpikeSpawnEnemy : MonoBehaviour {

public	GameObject Enemyprefab;
	public int spawnTime;



	void Start()
	{
		//Start the spawn update
		StartCoroutine("Spawn");
		spawnTime = 5;
	}
	

	
	//---------------------------Spawning the drink---------------------------
	IEnumerator Spawn()
	{
		//Wait spawnTime
		yield return new WaitForSeconds(spawnTime);
		//generate randomNumber to decide what to generate,could probably tie this in with a list & index value but I like the direct access to gameobject vars like this! 
	

		GameObject go = Instantiate(Enemyprefab,new Vector3(transform.position.x,transform.position.y,0),Quaternion.Euler(0,0,0)) as GameObject;
		
		//If x position is over 0 go left (ie world 0 s0 means centre of screen.)
		//if (go.transform.position.x > 0)
	//	{
	//		go.rigidbody.AddForce(new Vector3(-leftRightForce,upForce,0));
	//	}
		
		//Start the spawn again
		StartCoroutine("Spawn");
	}
}
