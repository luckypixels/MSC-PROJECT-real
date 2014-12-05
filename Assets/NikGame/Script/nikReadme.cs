using UnityEngine;
using System.Collections;

public class nikReadme : MonoBehaviour {

//this is a file to remind me/u depending on how much my sense of identity has been destroyed by the pressure of the project :)
//its a TODO file and also where i can add notes to myself on how the code works as in what the hell stuff means & also what i've used.
//that said it's not to replace proper commenting in the scripts its just i should keep those as succinct as possible.never my forte!


///<description>
//Here is where I will detail some of the fucntionality, worth doing to identify what the hell is happening in the awful template in the package & then how ive built upon it.
///</description>

//-----------------------------------------------FUNCTIONALITY-------------------------------------------------


/*bombscript
-in update gets the reference to the player object so as to be able to access the script componenet on it
which allows it access to the lives var to set to 0 which = game over
*/
//-if the above is true that its using update then its doing soemthing everyframe. look to see if theres a way to adapt since each update call slows game
//-go thru all the scripts and remove any unused update()s as they will impact on performance EVEN IF EMPTY!!!

	
/*fruit
has the hit method which tells it to use the current fruit to turn into the 2 seperate pieces which is not something ill need cos 
my game u grab drink not smash a glass, but its weird code 2 look at cos instantiate refers to the prefab to make with a var set in the script BUT NOWHERE IS IT LINKED TO THE PREFAB!
*/



//-------------------------TODO------------------------------------------------

/*In gameManager class all the different cards and levels are listed 1 by 1 as independent vars. For 2.0 would be nice
* to see if theres a way to use a list or array and maybe use a dictionary so key(levelName) value(1 or 0 or strings ie true/false).
*/

//------------------------NOTES TO SELF------------------------------------------------








}