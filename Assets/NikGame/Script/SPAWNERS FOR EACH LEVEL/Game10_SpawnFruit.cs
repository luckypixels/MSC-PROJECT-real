using UnityEngine;
using System.Collections;

public class Game10_SpawnFruit : MonoBehaviour
{
	public float spawnTime;//Spawn Time (the delay between calls 2 spawn next object)


	int drinkNumber; //stores randomrange result to reference in switchstatement

	//list of the available drinks that can be generated
	public GameObject beerPint;	
	public GameObject beerBotGreen;			
	public GameObject beerBotBrown;			
	public GameObject burger;
	public GameObject cocktailThin;			
	public GameObject cocktailFat;			
	public GameObject champagne;
	public GameObject coke;
	public GameObject kebab;			
	public GameObject poison;
	public GameObject shot;
	public GameObject whiskey;
	public GameObject wineBottle;
	public GameObject wineGlass;
	public GameObject pickUpForLevel; //in inspector set the appropriate card pick up

	GameObject prefab; //the var that is used for the instancing the drink.

	/* commenting out for now til i can work out why the error...
	GameObject pickUp; //var for instance of the pick up.
	int timeToSpawnPickup;//what time to spawn the prefab of this level's collectable
	*/

	//vars for setting movement of the behaviour of genertated objects
	public float upForce = 750;			//Up force
	public float leftRightForce = 200;	//Left and right force
	public float maxX;					//Max x spawn position
	public float minX;					//Min x spawn position





//--------------------------------METHODS------------------------------
	void Start()
	{
		//Start the spawn update
		StartCoroutine("Spawn");

//decide what time in the level the pickUp prefab gets spawned and also choose a position.
//		timeToSpawnPickUp = (Random.Range (5, 60)); //if i decide to make the levels longer it'd be good to have a var of levelLength and pass this for the range's max value.

	}


//	------The switch statement for the different drinks-----
	//random.range vals are inclusive so in theory i could've seen a case 13 but the default never shoes and neither did an actual case 13 so who knows...
	
	void GenerateDrink(int drinkNumber)
	{
		switch (drinkNumber)
	{	
		case 12:
			prefab =cocktailFat;
			break;
		case 11:
			prefab =cocktailThin;
			break;
		case 10:
			prefab =whiskey;
			break;

		case 9:
			prefab =champagne;
			break;
		case 8:
			prefab= wineBottle;
			break;
		case 7:
			prefab = beerBotGreen;
			break;
		case 6:
			prefab=beerBotBrown;
			break;

		case 5:
			prefab = beerPint;
			break;
		case 4:
			prefab = wineGlass;
			break;
		case 3:
			prefab = coke;
			break;
		case 2:
			prefab = shot;
			break;
		case 1:
			prefab = burger;
			break;
		case 0:
			prefab = kebab;
			break;
		default:
			print ("theres an error-no drink selected");
			break;
		}
	}



//---------------------------Spawning the drink---------------------------
	IEnumerator Spawn()
	{
		//Wait spawnTime
		yield return new WaitForSeconds(spawnTime);
//generate randomNumber to decide what to generate,could probably tie this in with a list & index value but I like the direct access to gameobject vars like this! 

/* the randomRange is testing to see if the poison prefab should be generated, if its not then want to generate a 'good' drink
which is done with another randomrange for which drink. 
*/
	
//if have this being used in different levels=more difficult can set an int to for max of random range that is higher for each level-increase freq of poison generated

		//bool generate poison;
//random range to see if should be making the poisondrink, a bool and if true
//would be more elegant, but its extra vars as apposed to if (randomRange call<)

		int genPoisonCheck=(Random.Range(0,100));
		if (genPoisonCheck < 20) {
						//Spawn prefab is  poison
						prefab = poison;
				} else {
			drinkNumber = (Random.Range (0, 13));
				GenerateDrink (drinkNumber);
				}






//The code below which instantiates the prefab (which was selected by the above code) is taken from the android template


//---------------Now a prefab has been selected, generate it ---------------------------------
		//Spawn prefab add randomx position
		GameObject go = Instantiate(prefab,new Vector3(Random.Range(minX,maxX + 1),transform.position.y,0),Quaternion.Euler(0,0,Random.Range(-50, 50))) as GameObject;

		//If x position is over 0 go left (ie world 0 s0 means centre of screen.)
		if (go.transform.position.x > 0)
		{
			go.rigidbody.AddForce(new Vector3(-leftRightForce,upForce,0));
		}
		//Else go right
		else
		{
			go.rigidbody.AddForce(new Vector3(leftRightForce,upForce,0));
		}
		
		//Start the spawn again
		StartCoroutine("Spawn");
	}

	/* commenting it out cos its giving an error or some reason
	void SpawnPickUp(){
		Instantiate(pickUp,new Vector3(Random.Range(minX,maxX + 1),transform.position.y,0),Quaternion.Euler(0,0,Random.Range(-50, 50))) as GameObject;

	}
*/





}//close class
