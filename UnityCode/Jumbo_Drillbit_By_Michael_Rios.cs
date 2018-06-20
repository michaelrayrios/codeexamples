using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Controller for each individual drillbit of the drilling system - By Michael Rios

public class Jumbo_Drillbit : MonoBehaviour {

	//Public Variables -> Accessible for editor
	#region
	//Tuned here due to model variance per character model
	//Is left?
	[Tooltip("Check if this is the left drill.")]
	public bool onLeft;

	//RPM
	[Tooltip("RPM of drill")]
	[Range(0,10000)]
	public int drillRPM;

	//Speed of the hammer drive
	[Tooltip("Hammer drive speed")]
	[Range(1,10)]
	public float hammerDriveSpeed;

	//Forward range
	[Tooltip("Hammer drive-range on the forward end.")]
	[Range(-5,5)]
	public float hammerDriveRangeFwd;
	
	//Backward range
	[Tooltip("Hammer drive-range backward end.")]
	[Range(-5,5)]
	public float hammerDriveRangeBwd;
	#endregion

	//Public Variables -> Accessible for Jumbo_Drill
	#region
	//Is engaged?
	[Tooltip("Checked when the drill is engaged")]
	public bool drillEngaged;
	#endregion

	//Internal Variables
	#region
	//The collider used for drilling -> Fetched during init
	Collider drillHitTrigger;

	//True when the drill hammer should drive forward
	bool hammerForward;

	//Waits -> Setup here to prevent GC
	WaitForSeconds wait_quick = new WaitForSeconds(0.03f);
	WaitForSeconds wait_long = new WaitForSeconds(1);
	#endregion

	//Init
	void Start()
	{
		Set_Drillbit();	
	}

	//Update -> Check the drills state
	void Update()
	{	
		Check_Drill_State();
	}

	//Setup the drillbit
	void Set_Drillbit()
	{
		//Set false because the hammers start at the back position
		hammerForward = false;
		//Get the trigger collider for drilling collision checks
		drillHitTrigger = GetComponentsInChildren<Collider>()[0];
		//Set the collider to be inactive -> no drilling occurs unless the drill runs
		drillHitTrigger.gameObject.SetActive(false);
	}

	//Check the state of the drill and cycle if drill is to be engaged
	void Check_Drill_State()
	{
		if(drillEngaged){Cycle_Drillbit();}
	}

	//Cycle the drill rotation and hammer
	void Cycle_Drillbit()
	{
		if(drillEngaged)
		{
			Drill_Cycle();
			Hammer_Cycle();
		}
	}

	//Set the drill trigger to active and switch the bool to engaged
	public void Engage_Drill()
	{
		drillHitTrigger.gameObject.SetActive(true);
		drillEngaged = true;
	}

	//Shutdown the drills and turn the drill trigger to be inactive
	public void Disengage_Drill()
	{
		StartCoroutine(Shut_Down_Drill());
		drillHitTrigger.gameObject.SetActive(false);
		drillEngaged = false; 
	}

	//Rotates the drillbit
	void Drill_Cycle()
	{
		transform.Rotate(0,0,drillRPM*Time.deltaTime);
	}

	//Cycles the hammer portion of the drill
	void Hammer_Cycle()
	{
		if(hammerForward == true && transform.localPosition.z < hammerDriveRangeFwd)
		{
			Debug.Log("Hammer forward " + gameObject.name + " cycle order given.");
			Hammer_Cycle_Forward();
		}
		else if(hammerForward == true && transform.localPosition.z > hammerDriveRangeFwd)
		{
			hammerForward = false;
		}
		else if(hammerForward == false && transform.localPosition.z > hammerDriveRangeBwd)
		{
			Debug.Log("Hammer backward " + gameObject.name + " cycle order given.");
			Hammer_Cycle_Backward();
		}
		else
		{
			hammerForward = true;
		}
	}

	//Cycles the hammer forward
	void Hammer_Cycle_Forward()
	{
		transform.Translate(Vector3.forward*hammerDriveSpeed*Time.deltaTime);
		Debug.Log("Hammer forward " + gameObject.name + " cycled.");
	}

	//Cycles the hammer backward
	void Hammer_Cycle_Backward()
	{
		transform.Translate(Vector3.forward*-1*hammerDriveSpeed*Time.deltaTime);
		Debug.Log("Hammer backward " + gameObject.name + " cycled.");
	}

	//Retracts the drill -> COROUTINE
	IEnumerator Retract_Drill_CO()
	{
		if(transform.localPosition.z > hammerDriveRangeBwd)
		{
			Hammer_Cycle_Backward();
			yield return wait_quick;
			StartCoroutine(Retract_Drill_CO());
		}
	}

	//Shuts down the drill on a delayed timer -> COROUTINE
	IEnumerator Shut_Down_Drill()
	{
		yield return wait_long;
		StartCoroutine(Retract_Drill_CO());
	}
}
