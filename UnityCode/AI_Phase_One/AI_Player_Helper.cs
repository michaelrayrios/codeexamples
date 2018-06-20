using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This manages when the play enters and exits navigation zones
public class AI_Player_Helper : MonoBehaviour {

	//Vars
	[Tooltip("is the player in a zone?")]
	public bool playerInZone;
	[Tooltip("What zone is the player in?")]
	public Transform zone;

	public bool isMoving;
	Vector3 lastPosition;
	WaitForSeconds wait = new WaitForSeconds(0.25f);
	
	//Event handling for going in and out of zones
	public delegate void IntoZone();
    public static event IntoZone InZone;

	public delegate void OutOfZone();
    public static event OutOfZone OutZone;

	//Init
	void Start()
	{
		//Player starts outside of a zone - set info here
		playerInZone = false;
		zone = null;
		isMoving = false;
		lastPosition = transform.position;
		StartCoroutine(Check_If_Moving());
	}

	//When the player enters a zone - set zone info and broacast event
	void OnTriggerEnter(Collider other)
	{
		if(other.tag=="AI_Zone")
		{
			Debug.Log("Entered Zone");
			if(playerInZone == false)
			{
			playerInZone = true;
			zone = other.transform;
			if(InZone != null)
            InZone();
			}
		}
	}

	//When the player exists a zone - set zone info and broadcast event
	void OnTriggerExit(Collider other)
	{
		if(other.tag=="AI_Zone")
		{
			Debug.Log("Exited Zone");
			if(playerInZone == true)
			{
				playerInZone = false;
				zone = null;
				if(OutZone != null)
            	OutZone();
			}
		}
	}

	IEnumerator Check_If_Moving()
	{
		lastPosition = transform.position;
		yield return wait;
		if(Vector3.Distance(lastPosition, transform.position) > 0.25f)
		{
			isMoving = true;
		}
		else
		{
			isMoving = false;
		}
		StartCoroutine(Check_If_Moving());		
	}
}
