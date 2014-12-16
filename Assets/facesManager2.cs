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


//Had been more efficient with using DONTDESTROYONLOAD to alow the same instance to persist across levels
//-but even with if(Application.LoadedLevelName.Contains("Level")=false) checking if the room wasnt a playing scene it still persisted so that worked a bit too good at persisting!!!


	private SpriteRenderer spriteRenderer; //the var that refers to the gameObj's sprite renderer
	//int sicknessCheck;
	public int sickness;

	int spriteToRequest=0; //have to set up an init value 



//at start of the level check the gamecontroller's sickness var.
	void Awake(){
		spriteRenderer = gameObject.GetComponent<SpriteRenderer> (); //probably dont need to say gameObject cos it surely defaults to this obj if none specified

//have a var to check the current value in GameController, this val gets altered after all collisions (well excpet infocardpickup) so need to have a call back to here on teh collision
		sickness = GameController._instance.sickness;
		}




//--------------------------------CHECKING IF THE SPRITE OF SICKFACES NEEDS TO BE ALTERED-------

	public void checkSicknessNeedChangeGraphic(){


		if (sickness <= 1 && sickness < 10) {    
			spriteToRequest=1;
		} 
		
		
		else if (sickness>11 && sickness < 29){
			spriteToRequest=2;
		}
		
		else if (sickness>30 && sickness < 49){
			spriteToRequest=3;
		}
		
		
		else if (sickness>50 && sickness< 69){
			spriteToRequest=4;
		}
		
		
		else if (sickness>70 && sickness <90){
			spriteToRequest= 5;
		}
		
		else if (sickness>=90&&sickness <990){   
			spriteToRequest= 6;
  		}

		else if (sickness>=1000){   
			spriteToRequest = 7;
		}

//////		//GameController._instance.GetComponent<sickFacesManager>().ChangeSprite(sprite);
		//sickFaces2.GetComponent<sickFacesManager>().ChangeSprite(spriteToRequest);
	Debug.Log("sprite shud be :" +spriteToRequest);


} 

}//close class
	

/*

/*

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
//			else if(sickness ==1000){   //this is a test for trying to get the sprite to be switched off in menu 
//				//else{
//				spriteRenderer.sprite = null;
//			}s
			
		}//close changeSprite()
*/
