using UnityEngine;
using System.Collections;

public class SoundEffectsManager : MonoBehaviour {

	// <summary>
	/// Singleton
	/// </summary>
	public static SoundEffectsManager Instance;

	//get a reference to sound files that'll be usedusing public for easy assigning value
	public AudioClip goodDrinkSound;
	public AudioClip softDSound;
	public AudioClip badDrinkSound;
	public AudioClip spikedDrinkSound;
	public AudioClip foodSound;
	public AudioClip pickUpSound;

	void Awake()
	{
		// lazy singleton
		if (Instance != null)
		{
			Debug.Log("Multiple instances of SoundEffectsManager!");
		}
		Instance = this;
	}
	
	public void GoodDrinkSound()
	{
		MakeSound(goodDrinkSound);
	}
	
	public void OpenCanSound()
	{
		MakeSound(softDSound);
	}
	
	public void SpikedDrinkSound()
	{
		MakeSound(spikedDrinkSound);
	}
	

	public void BadDrinkSound()
	{
		MakeSound(badDrinkSound);
	}

	public void FoodSound()
	{
		MakeSound(foodSound);
	}

	public void PickUpSound(){
		MakeSound(pickUpSound);
	}

	private void MakeSound(AudioClip originalClip)
	{
		// As it is not 3D audio clip, position doesn't matter.
		AudioSource.PlayClipAtPoint(originalClip, transform.position);
	}
}
