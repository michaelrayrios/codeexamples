using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This handles the shooting from the NPC
public class AI_NPC_Shotpoint : MonoBehaviour {

	public GameObject bullet;
	public bool debug;
	public bool shooting = false;
	Vector3 cubeVect = new Vector3(0.25f, 0.25f, 0.25f);
	WaitForSeconds wait_long = new WaitForSeconds(5f);
	WaitForSeconds wait_short = new WaitForSeconds(0.5f);

	public void Start_Shooting()
	{
		if(!shooting)
		{
			StartCoroutine(Shooting_Cycle_CO());
			shooting = true;
		}
	}

	public void Stop_Shooting()
	{
		StopCoroutine(Shooting_Cycle_CO());
		StopCoroutine(Individual_Shot_CO());
		shooting = false;
	}

	IEnumerator Shooting_Cycle_CO()
	{
		StartCoroutine(Individual_Shot_CO());
		yield return wait_long;
		StopCoroutine(Individual_Shot_CO());
		yield return wait_long;
		StartCoroutine(Shooting_Cycle_CO());
	}

	IEnumerator Individual_Shot_CO()
	{
		Instantiate(bullet, transform.position, transform.rotation);
		yield return wait_short;
		StartCoroutine(Individual_Shot_CO());
	}

	void OnDrawGizmos()
	{
		//If debug then draw the cube at the point
		if(debug)
		{
			Gizmos.color = new Color(1, 0, 0, 0.5F);
        	Gizmos.DrawCube(transform.position, cubeVect);
		}
	}
}
