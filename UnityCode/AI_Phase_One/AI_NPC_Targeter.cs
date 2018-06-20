using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This manages the targeting for the NPC AI
public class AI_NPC_Targeter : MonoBehaviour {

	public List <Transform> enemies;
	public Transform closest_enemy;
	float distance_holder = 1000;
	WaitForSeconds wait = new WaitForSeconds(0.25f);

	void Start()
	{
		closest_enemy = null;
		enemies = new List<Transform>();
		StartCoroutine(Check_For_Closest_Enemy());
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Enemy")
		{
			enemies.Add(other.transform);
		}
	}

	void OnTriggerExit(Collider other)
	{
		if(other.tag == "Enemy")
		{
			enemies.Remove(other.transform);
		}
	}

	IEnumerator Check_For_Closest_Enemy()
	{
		if(enemies == null)
		{
			closest_enemy = null;
			distance_holder = 1000;
		}
		else if(enemies.Count < 1)
		{
			closest_enemy = null;
			distance_holder = 1000;
		}
		else
		{
			foreach(Transform enemy in enemies)
			{
				if(enemy != null)
				{
					if(Vector3.Distance(transform.position, enemy.position) < distance_holder)
					{
						closest_enemy = enemy;
					}
				}
			}
			if(closest_enemy == null)
			{
				closest_enemy = null;
			}
		}
		yield return wait;
		StartCoroutine(Check_For_Closest_Enemy());
	}
}
