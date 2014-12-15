using UnityEngine;
using System.Collections;
using UnityEngine.UI;
[RequireComponent(typeof(Button))]

public class changeInfoCardBtnThumb : MonoBehaviour 
{
	//public Image fuckingImage;
	//public Sprite newsprite;
	public bool condition;
	public Button button;
	void Start ()
	{
		button = GetComponent<Button>();
		//button.interactable =true;
		//Debug.Log(button.interactable);
	}
	void Update ()
	{
		if (button.interactable==true)
		{
	//call the animation
		}
		else
		{
			Debug.Log ("the card is locked");
		}
	}
}


//the method in the GameController._instance.isCardUnlocked (1);