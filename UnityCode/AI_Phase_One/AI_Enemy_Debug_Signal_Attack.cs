using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Simply signals an attack
public class AI_Enemy_Debug_Signal_Attack : MonoBehaviour {
    
    //Signal to the console
    [Tooltip("What should this signal to the console?")]
    public string signal;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" || other.tag == "NPC")
        Debug.Log(signal);
    }
}
