using UnityEngine;
using System.Collections;

public class nikReadme : MonoBehaviour {

/*------The (initial) game works like this:-
player has to 'chop' thru the apples and avoid the bombs.
-if they hit even just 1 bomb its game over immediately
-if they fail to hit an apple (ie it falls back off bottom of screen) then they lose a life.
*/

/*-------My ideas----------
-want it to have a range of different drinks and kebabs,burgers thrown, 
surely copying exisiting method of instatniate prefab would work  4 range of objects
-have different point values for different drinks

*/


/*bombscript
-in update gets the reference to the player object so as to be able to access the script componenet on it
which allows it access to the lives var to set to 0 which = game over
*/

/*player script
-this is the main script-controls the logic of the game ie the lives and also the UI
*/

/*timer 
this is my own script which is from the tuts+ tut and in it it they do time countdown there, if i use a getComponent for the 
time status in my reduce time fucntion then its calling getcomponent every sec which will kill the game!
*/


/*spawn
has the random rage method that wprks out wehat to generate-havent looked at this enuff yet

*/

	
/*fruit
has the hit method which tells it to use the current fruit to turn into the 2 seperate pieces which is not something ill need cos 
my game u grab drink not smash a glass, but its weird code 2 look at cos instantiate refers to the prefab to make with a var set in the script BUT NOWHERE IS IT LINKED TO THE PREFAB!

*/



}