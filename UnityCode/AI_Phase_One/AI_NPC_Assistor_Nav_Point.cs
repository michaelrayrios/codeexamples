using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is the actual nav point
public class AI_NPC_Assistor_Nav_Point : MonoBehaviour {

	//Setup a cube for drawing during debug
	Vector3 cubeVect = new Vector3(1, 1, 1);
	[Tooltip("Check if you would like to debug and see visuals of the point.")]
	public bool debug;

	//Is this nav point claimed?
	public bool claimed;
	//If this nav point is claimed - how claimed it?
	public Transform claimOwner;

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
