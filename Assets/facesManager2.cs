using UnityEngine;
using System.Collections;

public class facesManager2 : MonoBehaviour {

		public Sprite sprite1; 
		public Sprite sprite2;  
		public Sprite sprite3; 
		public Sprite sprite4;
		public Sprite sprite5; 
		public Sprite sprite6;
		public Sprite sprite7;
		
	private SpriteRenderer spriteRenderer; //the var that refers to the gameObj's sprite renderer
	int sicknessCheck;


//at start of the level check the gamecontroller's sickness var.
	void Awake(){
	spriteRenderer = gameObject.GetComponent<SpriteRenderer> ();
	//			spriteRenderer.sprite = sprite2;
		sicknessCheck = GameController._instance.sickness;
	//	if(sicknessCheck>=50);
	//	Debug.Log ("I need to change graphic");
	//	GameController._instance.getRefToSickFaces (gameObject);
	//	Debug.Log ("sent a ref to the gamecontroller");
		}

	public void ChangeSprite (int sickness) //ok putting the if(sickness==foo) here works for this practice but since it'll be being called via the player/gamecontroller following a collision with object it needs a proper method since cant call events like update!
		{
			if (sickness == 1) {    //the i'm not drunk yet part
				spriteRenderer.sprite = sprite1;
			} 
			
			
			else if (sickness ==2){
				spriteRenderer.sprite = sprite2;
			}
			
			else if (sickness ==3){
				print ("larger sprite pls");
				spriteRenderer.sprite = sprite3;
			}
			
			
			else if (sickness == 4){
				print ("larger sprite pls");
				spriteRenderer.sprite = sprite4;
			}
			
			
			else if (sickness == 5){
				print ("larger sprite pls");
				spriteRenderer.sprite = sprite5;
			}
			
			else if (sickness == 6){     //he's about to puke sprite
				print ("larger sprite pls");
				spriteRenderer.sprite = sprite6;
			}
			//
			else if(sickness ==1000){   //this is a test for trying to get the sprite to be switched off in menu 
				//else{
				spriteRenderer.sprite = null;
			}
			
		}//close changeSprite()
		
		
	}//close class
	
