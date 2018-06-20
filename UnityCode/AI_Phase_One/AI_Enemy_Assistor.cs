using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//When an enemy collides with an assistor it redirects to another to do a "Swipe attack"
public class AI_Enemy_Assistor : MonoBehaviour {

	//Assigned number for this Assistor (1 - 4)
	[Tooltip("Assigned number for this assistor.")]
	[Range(1,4)]
	public int assistor_Number;

	void OnTriggerStay(Collider other)
	{
		if(other.tag == "Enemy")
		{
			AI_Enemy_Charger enemy = other.GetComponent<AI_Enemy_Charger>();
			
			enemy.agent.isStopped = true;
			enemy.agent.stoppingDistance = 0;
			if(assistor_Number == 1) {enemy.nav_Assistor = enemy.attack_target_Assistors[1];}
			else if(assistor_Number == 2) {enemy.nav_Assistor = enemy.attack_target_Assistors[2];}
			else if (assistor_Number == 3) {enemy.nav_Assistor = enemy.attack_target_Assistors[3];}
			else if (assistor_Number == 4) {enemy.nav_Assistor = enemy.attack_target_Assistors[0];}
			enemy.agent.isStopped = false;
		}
	}
}
