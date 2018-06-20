using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This manages the AI targeting object for the charger AI
public class AI_Enemy_Charger_Targeter : MonoBehaviour {

	//The logic script of this Charger
	AI_Enemy_Charger thisEnemy;
	bool holding;
	WaitForSeconds wait = new WaitForSeconds(0.25f);

	//Init
	void Start()
	{
		holding = false;
		thisEnemy = GetComponentInParent<AI_Enemy_Charger>();
	}

	//When collides with Player or NPC add them to the target list on the logic
	void OnTriggerEnter(Collider other)
	{
		if(!holding)
		{
		if(other.tag == "Player" || other.tag == "NPC")
		{
			thisEnemy.assistor_Attack_Active = true;
			thisEnemy.attack_targets.Add(other.transform);
			thisEnemy.attackTarget = other.transform;
			thisEnemy.Get_Attack_Target_Assistors();
			thisEnemy.nav_Assistor = thisEnemy.Get_Closest_Assistor();
			thisEnemy.Engage_Attack_Using_Assistors();
			StartCoroutine(Hold_For_New_Target_CO());
		}
		}
	}

	IEnumerator Hold_For_New_Target_CO()
	{
		holding = true;
		yield return wait;
		holding = false;
	}
}
