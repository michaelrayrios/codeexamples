using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Controller for the Dual Drilling system for drilling out resource stones - By Michael Rios

public class Jumbo_Drill : MonoBehaviour {

	//Internal Variables for Drill
	#region
	//Reference to Left Jumbo Drill (fetched on init)
	Jumbo_Drillbit left_Drill;
	//Reference to Right Jumbo Drill (fetched on init)
	Jumbo_Drillbit right_Drill;

	//True if the drill should be drilling
	bool drilling;
	//True if the drill is waiting - occurs when player stops drilling
	bool waiting;
	//Which drill will lag behind the other when starting - 0/1
	int lagDrill;

	//Wait is setup here so it is not flagged for GC
	WaitForSeconds wait = new WaitForSeconds(0.25f);

	//Random for lagDrill selection
	System.Random rand = new System.Random();
	#endregion

	//Event listener handling
	//Runs on enable
	private void OnEnable()
    {
		//Start event listeners
        Player_Controller_Manager.start_drill += Start_Drills;
		Player_Controller_Manager.stop_drill += Shut_Down_Drills;
    }
	//Runs on disable
    private void OnDisable()
    {
		//Stop event listeners
        Player_Controller_Manager.start_drill -= Start_Drills;
		Player_Controller_Manager.stop_drill -= Shut_Down_Drills;
    }

	//Init
	void Start()
	{
		waiting = false;
		Get_Drills();
	}

	//Check if the drill should be drilling
	//Start or stop the drill depending on condition
	void Set_Drill_State()
	{
		if(drilling) 
		{
			StartCoroutine(Start_Drills_CO());
		}
		else if(!drilling) 
		{
			Stop_Drills();
		}
	}

	//Starts the drills if not waiting -> Called by event!
	void Start_Drills()
	{
		if(!waiting)
		{
			drilling = true;
			Set_Drill_State();
		}
	}

	//Shuts down the drills -> Called by event!
	void Shut_Down_Drills()
	{
		drilling = false;
		Set_Drill_State();
	}

	//Finds the drills in the children
	void Get_Drills()
	{
		//Fetch the drills
		foreach(Jumbo_Drillbit jdb in GetComponentsInChildren<Jumbo_Drillbit>())
		{
			if(jdb.onLeft == true) {left_Drill = jdb;}
			else {right_Drill = jdb;}
		}
	}

	//Starts the left drill by calling its public method
	void Start_Left_Drill()
	{
		if(left_Drill.drillEngaged == false){left_Drill.Engage_Drill();}
	}

	//Starts the right drill by calling its public method
	void Start_Right_Drill()
	{
		if(right_Drill.drillEngaged == false){right_Drill.Engage_Drill();}
	}

	//Stops both of the drills and calls the timer to prevent sudden reinitiation
	void Stop_Drills()
	{
		if(left_Drill.drillEngaged != false){left_Drill.Disengage_Drill();}
		if(right_Drill.drillEngaged != false){right_Drill.Disengage_Drill();}
		StartCoroutine(Inbetween_Firing_Timer_CO());
	}

	//COROUTINES
	#region
	//Start the drills -> COROUTINE
	IEnumerator Start_Drills_CO()
	{
		//Set random to select drill
		lagDrill = rand.Next(0,2);
		//Start left drill first if less than 1
		if(lagDrill < 1)
		{
			Start_Left_Drill();
			yield return wait;
			Start_Right_Drill();
		}
		else //...right drill
		{
			Start_Right_Drill();
			yield return wait;
			Start_Left_Drill();
		}
	}

	//Timer for when player releases drill -> COROUTINE
	IEnumerator Inbetween_Firing_Timer_CO()
	{
		waiting = true;
		yield return wait;
		waiting = false;
	}
	#endregion
}
