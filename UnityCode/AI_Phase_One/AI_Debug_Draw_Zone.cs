using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script draws a zone for the unity editor
public class AI_Debug_Draw_Zone : MonoBehaviour {

	//Vars
	[Tooltip("Check to see the zones in the editor.")]
	public bool debug;
	[Tooltip("Change the color of the zone.")]
	public Color debugColor = new Color(0, 0, 1, 0.5F);
	
	//Vector3 to prevent instantiation on every OnDrawGizmos
	Vector3 cubeVect;
	void OnDrawGizmos()
	{
		//Set cubevect based on the objects worldScale - if debug mode is active
		if(debug)
		{
			//Set the vector to size
			cubeVect = new Vector3(transform.lossyScale.x, transform.lossyScale.y, transform.lossyScale.z);
			//Set the gizmo color to the set color
			Gizmos.color = debugColor;
			//Draw a cube using the info given
        	Gizmos.DrawCube(transform.position, cubeVect);
		}
	}
}
