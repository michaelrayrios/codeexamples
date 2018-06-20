using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script helps manage the formation of NPCs that follow the player
//It casts rays that move nav points so that they do not end up on the opposite side of any
//given obstacles
public class AI_NPC_Assistor_Nav_Mover : MonoBehaviour {

	//If you want to debug and see the rays
	[Tooltip("Check to see visible rays.")]
	public bool debug;
	[Tooltip("Set the max distance.")]
	public float maxDistance;
	AI_NPC_Assistor_Nav_Point navPoint;
	RaycastHit hit;
	//Waitforseconds setup here to prevent excessive GC
	WaitForSeconds wait = new WaitForSeconds(0.25f);

	//Init
	void Start()
	{
		//Get the nav point for this mover
		navPoint = GetComponentInChildren<AI_NPC_Assistor_Nav_Point>();
		//Adjusts the navs to new locations
		StartCoroutine(Reset_Nav_Points_CO());
	}

	//Start the nav point cycler
	IEnumerator Reset_Nav_Points_CO()
	{
		//Reset the nav points to new locations
		Reset_Nav_Points();
		//Wait
		yield return wait;
		//Recur
		StartCoroutine(Reset_Nav_Points_CO());
	}

	//Reset the nav points - actual method called by the CO
	void Reset_Nav_Points()
	{
		//If debug - then draw a ray
		if(debug){Debug.DrawRay(transform.position, transform.forward*maxDistance, Color.red);}
		//Cast a ray
		if(Physics.Raycast(transform.position, transform.forward, out hit, maxDistance))
		{
			navPoint.transform.position = hit.point; //Set the navpoint position to the hit point of the ray
		}
		else
		{
			//If the ray did not hit this the navpoint is set to the max distance that is allowed
			navPoint.transform.position = transform.position + (transform.forward*maxDistance);
		}
	}
}
