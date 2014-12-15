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

//want to import this an array and use a foreach or for each loop to loop and get init values but for 1st testing...
		if (GameController._instance.isCardUnlocked (1)==true) {
			cardBtn1.GetComponent<Button>().interactable = true;
				}
		if (GameController._instance.isCardUnlocked (2)==true) {
			cardBtn2.GetComponent<Button>().interactable = true;
		}
		if (GameController._instance.isCardUnlocked (3)==true) {
			cardBtn3.GetComponent<Button>().interactable = true;
		}
		if (GameController._instance.isCardUnlocked (4)==true) {
			cardBtn4.GetComponent<Button>().interactable = true;
		}
		if (GameController._instance.isCardUnlocked (5)==true) {
			cardBtn5.GetComponent<Button>().interactable = true;
		}
		if (GameController._instance.isCardUnlocked (6)==true) {
			cardBtn6.GetComponent<Button>().interactable = true;
		}
	

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
