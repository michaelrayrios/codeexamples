using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Turns rotation on off for the enemy AI assistors
public class AI_Enemy_Assistor_Controller : MonoBehaviour {

    //Seconds for switch On
    [Tooltip("How many seconds rotation will be on.")]
    public float secondsOn;
    //Seconds for switch Off
    [Tooltip("How many seconds rotation will be off.")]
    public float secondsOff;
    [Tooltip("Turn rotation on or off")]
    public bool rotationTurnedOn;

    //Bools
    bool rotate_On;

    //Wait
    WaitForSeconds wait_On;
    WaitForSeconds wait_Off;
    WaitForEndOfFrame wait_Frame;

    //Player
    public GameObject player;


	//Init
	void Start () {
		wait_On = new WaitForSeconds(secondsOn);
        wait_Off = new WaitForSeconds(secondsOff);
        StartCoroutine(Switch_Rotate());
    }

    //Checks for fixed rotation per frame
    private void Update()
    {
        if (!rotate_On) { Rotate_Off(); }
        else
        {
            Rotate_On();
        }
    }

    //Fixes rotation
    void Rotate_Off()
    {
        transform.rotation = Quaternion.identity;
    }

    void Rotate_On()
    {
        transform.rotation = player.transform.rotation;
    }

    //CO: Switch the rotation
	IEnumerator Switch_Rotate()
    {
        if(rotationTurnedOn)
        {
            rotate_On = false;
            yield return wait_Off;
            rotate_On = true;
            yield return wait_On;
        }
        yield return wait_Frame;

        StartCoroutine(Switch_Rotate());
    }
}
