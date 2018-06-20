using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//This handles the majority of the Charger unit AI
public class AI_Enemy_Charger : MonoBehaviour {

	//Vars
	[Tooltip("The player assistor attached to the player.")]
	public AI_Enemy_Assistor_Controller player_Assistors;
	public AI_Enemy_Assistor nav_Assistor;
	public bool debug;
	[Tooltip("The sensed targets.")]
	public List<Transform> attack_targets;
	[Tooltip("Current target selected from the list.")]
	public	Transform attackTarget;
	[Tooltip("Assistors of the target.")]
	public List<AI_Enemy_Assistor> attack_target_Assistors;
	public int attack_Pass;
	public bool assistor_Attack_Active;
	
	//Internal vars
	public NavMeshAgent agent;
	WaitForSeconds wait = new WaitForSeconds(0.25f);

	//Init
	void Start()
	{
		assistor_Attack_Active = false;
		attack_Pass = 0;
		agent = GetComponent<NavMeshAgent>();
		attack_targets = new List<Transform>();
		StartCoroutine(Goto_Target_CO());
	}

	//Goto the target
	void Goto_Target()
	{
		agent.SetDestination(player_Assistors.transform.position);
	}

	//Goto the target cycler
	IEnumerator Goto_Target_CO()
	{
		Debug.Log("Attacking target actual.");
		Goto_Target();
		yield return wait;
		if(assistor_Attack_Active) {//Do not repeat
		}
		else{
		StartCoroutine(Goto_Target_CO());
		}
	}

	//Goto nav point cycler
	IEnumerator Attack_Using_Assistor_CO()
	{
		Debug.Log("Attacking an assistor");
		Attack_Using_Assistor();
		yield return wait;
		StartCoroutine(Attack_Using_Assistor_CO());
	}

	void OnDestroy()
	{
		StopAllCoroutines();
	}

	//Checks for an attack target
	public void Check_For_Attack_Targets()
	{
		if(attack_targets[0] != null)
		{
			attackTarget = attack_targets[0];
			attack_targets.RemoveAt(0);
			attack_targets.Add(attackTarget);
		}
	}

	//Gets the assistors for the attack target
	public void Get_Attack_Target_Assistors()
	{
		attack_target_Assistors = new List<AI_Enemy_Assistor>(); //Clear out any assistor data from the list

		//Cycle through each enemy
		foreach(AI_Enemy_Assistor assistor in attackTarget.GetComponentsInChildren<AI_Enemy_Assistor>())
		{
			attack_target_Assistors.Add(assistor);
		}
	}

	//Gets the closest assistor
	public AI_Enemy_Assistor Get_Closest_Assistor()
	{
		AI_Enemy_Assistor closest = null;
		float distance = 1000;

		foreach(AI_Enemy_Assistor assistor in attack_target_Assistors)
		{
			if((closest == null) )
			{
				closest = assistor;
				distance = Vector3.Distance(transform.position, closest.transform.position);
			}
			else if(distance > Vector3.Distance(transform.position, assistor.transform.position))
			{
				distance = Vector3.Distance(transform.position, assistor.transform.position);
				closest = assistor;
			}
		}
		return closest;
	}

	public void Engage_Attack_Using_Assistors()
	{
		StopCoroutine(Goto_Target_CO());
		StartCoroutine(Attack_Using_Assistor_CO());
	}

	void Attack_Using_Assistor()
	{
		if(agent != null)
		{
			agent.SetDestination(nav_Assistor.transform.position);
		}
	}

	//Not yet implemented
	public void Advance_Attack_Pass()
	{
        if(attack_Pass >= 4)
		{
			attack_Pass = 0;
			//Retreat will go here
		}
		else
		{
			attack_Pass++;
		}
	}
}
