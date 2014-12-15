using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class InfoCardScreenSetInitVals : MonoBehaviour {

	public Sprite unlockedSprite; 
	public Sprite lockedSprite; 

	public GameObject cardBtn1;
	public GameObject cardBtn2;
	public GameObject cardBtn3;
	public GameObject cardBtn4;
	public GameObject cardBtn5;
	public GameObject cardBtn6;

	//public Image imageComponent;

	void Awake(){
	//here the game should call checkcard method and update the sprite on the buttons from locked to unlocked accordingly.
	//would be a for loop
	//shoudl have the cards listed in an array so can loop w/ >array.size and also means can set values in each iteration

		//cardBtn2.GetComponent<SpriteRenderer>().sprite=unlockedSprite;
		Debug.Log(cardBtn2.name);		//image.sprite = unlockedSprite;


		//
		//Image imageComponent cardBtn2.GetComponent<Image>().sprite = unlockedSprite;
		//}
		//





		//Image[] images;
		//void Start()
		//{
			// Get all components of type Image that are children of this GameObject.
		//	images = gameObject.GetComponentsInChildren<Image>();
			// Loop through each image and set it's Sprite to the other Sprite.
		//	foreach (Image image in images)
		//	{
		//		image.sprite = unlockedSprite;
		//	}







		//
//		spriteRenderer = GetComponent<SpriteRenderer>(); // get the SpriteRenderer of the Gameobject
//		if (spriteRenderer.sprite == null) {
//			spriteRenderer.sprite = sprite1;



	{Debug.Log("initting the carsds values");}
	
		for (int i = 0; i < 6; i++) {
			Debug.Log(i);
		}
	
	
	
	
	
	}
}
