using UnityEngine;
using System.Collections;


//the gui that i want will be different on different screens, 
//wonder if means i need different script 4 each scene, or if can have switch statement checking the name of scene to laod correct gui

public class LevelChanger_GUI : MonoBehaviour 
{

	public Texture btnTexture; //remember need to assign the artworn b4 calling it

/*
	void OnGUI()
	{
		//using art
		//if(GUI.Button(new Rect(Screen.width/2, Screen.height/2, 100, 30), btnTexture))
			if (GUI.Button(new Rect(10, 10, 70, 70), btnTexture))
			//using text no art:
		//if(GUI.Button(new Rect(Screen.width/2, Screen.height/2, 100, 30), "Change Level"))
		{
			if(Application.loadedLevel == 0)
				Application.LoadLevel(1);
			
			if(Application.loadedLevel == 1)
				Application.LoadLevel(0);
		}
	}
}
*/

//for main menu
void OnGUI()  // this "if(GUI_Button)(foo)" syntax is actual syntax that has to be used, cant clean with switch :(
{
	//using art
	//if(GUI.Button(new Rect(Screen.width/2, Screen.height/2, 100, 30), btnTexture))
	if (GUI.Button(new Rect(240, 140, 160, 40), "Play"))
		//using text no art:
		//if(GUI.Button(new Rect(Screen.width/2, Screen.height/2, 100, 30), "Change Level"))
		{
			Application.LoadLevel("LevelOne");
		
		}


		if (GUI.Button(new Rect(240, 140, 160, 40), "Play"))
			//using text no art:
			//if(GUI.Button(new Rect(Screen.width/2, Screen.height/2, 100, 30), "Change Level"))
		{
			Application.LoadLevel("LevelOne");
			
		}

		if (GUI.Button(new Rect(240, 190, 160, 40), "info Cards"))
			//using text no art:
			//if(GUI.Button(new Rect(Screen.width/2, Screen.height/2, 100, 30), "Change Level"))
		{
			Application.LoadLevel("infoCardsThumbs");
			
		}
		if (GUI.Button(new Rect(240, 240, 160, 40), "Select Level"))
			//using text no art:
			//if(GUI.Button(new Rect(Screen.width/2, Screen.height/2, 100, 30), "Change Level"))
		{
			Application.LoadLevel("levelSelect");
			
		}



	
	}//onGui

}//close the class



	/*
	//the unity documentation guide:

USING A BUTTON WITH TEXT-NO ART:

	void OnGUI() {
		
		if (GUI.Button(new Rect(10, 70, 50, 30), "Click"))
			Debug.Log("Clicked the button with text");
}

USING A BUTTON WITH A TEXTURE:

	public Texture btnTexture; //remember need to assign the artworn b4 calling it
	void OnGUI() {

		if (!btnTexture) {
			Debug.LogError("Please assign a texture on the inspector");
			return;
		}
		if (GUI.Button(new Rect(10, 10, 50, 50), btnTexture))
			Debug.Log("Clicked the button with an image");

	}
*/