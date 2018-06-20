using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Wakes up sleeping enemies based on an activation zone
public class AI_Wake_Up_Zone : MonoBehaviour {

	public List<GameObject> sleepers = new List<GameObject>();

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			if(sleepers[0] != null)
			{
				foreach(GameObject sleeper in sleepers)
				{
				sleeper.SetActive(true);
				}
			}
		}
	}
}
