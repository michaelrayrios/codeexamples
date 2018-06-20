using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//A simple trigger for the tip of the drill that destroys rocks as they are mined - By Michael Rios

public class Jumbo_Drillbit_Tip : MonoBehaviour {

	//While active the drill bit hits all drillable rocks and destroys them

	//Called when the drill collides with objects on the layers via the physics collision grid
	void OnTriggerEnter(Collider other)
	{
		//Checks if the object is a resource stone and destroys it if it is
		//Note: This is to avoid destroying broken rock bits while still allowing
		//collisions with them.
		if(other.gameObject.GetComponent<Resource_Stone>() != null)
		{
			Destroy(other.gameObject);
		}
	}
}
