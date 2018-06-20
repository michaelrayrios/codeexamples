using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//This is the AI for the NPCs navigation
public class AI_NPC_Navigator : MonoBehaviour {

    //Vars
    [Tooltip("The object that is the player.")]
	public AI_Player_Helper player;
    //The nav pool that is pulled from the player object
	AI_General_Navpoint_Pool playerNavPool;
    //The Targeter of the NPC
    AI_NPC_Targeter targeter;
    //The Shotpoint of the NPC
    AI_NPC_Shotpoint shotpoint;
    //The nav agent of the NPC
	NavMeshAgent agent;
    //The transform to goto
    Transform goto_This;
    //Store the wait here so that is it not created every call
    WaitForSeconds wait = new WaitForSeconds(0.25f);
    WaitForSeconds long_Wait = new WaitForSeconds(1f);

    //Init
	void Start()
	{
        //The nav pool is pulled from the Player
        playerNavPool = player.GetComponent<AI_General_Navpoint_Pool>();
        //The targeter is pulled from the NPC
        targeter = GetComponentInChildren<AI_NPC_Targeter>();
        //Get the shotpoint
        shotpoint = GetComponentInChildren<AI_NPC_Shotpoint>();
        //The agent is pulled from the NPC
		agent = GetComponent<NavMeshAgent>();
        //Set the nav point to the player using the method to do this
        SetPoint_Player();
        //Call the check if player is moving cycler
        StartCoroutine(Check_If_Player_Moving_CO());
        //Call the nav cycler
        StartCoroutine(Goto_CO());   
	}

    void Update()
    {
        if(Check_For_Shooting_Conditions())
        {
            Turn_To_Closest_Enemy();
            Shoot_If_Shot_Exists();
        }
        else
        {
            // Null reference check - Gabe
            if(shotpoint != null)
            {
                if(shotpoint.shooting)
                {
                    shotpoint.Stop_Shooting();
                    shotpoint.StopAllCoroutines();
                }
            }
        }
    }

    //For events
    #region
	void OnEnable()
    {
        AI_Player_Helper.InZone += SetPoint_Zone;
		AI_Player_Helper.OutZone += SetPoint_Player;
    }
    
    
    void OnDisable()
    {
        AI_Player_Helper.InZone -= SetPoint_Zone;
		AI_Player_Helper.OutZone -= SetPoint_Player;
    }
    #endregion

    //Sets the destination and goes to it (auto)
	void GotoPoint()
    {
        agent.SetDestination(goto_This.position);
    }

    //Sets the destination to a player nav helper and goes to it (auto)
    void SetPoint_Player()
    {
        goto_This = 
        playerNavPool.
        Claim_Open_Navpoint(
            transform).
            transform; //NULL HAPPENS HERE
    }

    //Sets the destination to a zone position and goes to it
    void SetPoint_Zone()
    {
        if(player.zone != null)
        {
            AI_General_Navpoint_Pool navPool = 
            player.
            zone.
            GetComponent<AI_General_Navpoint_Pool>();
            if((goto_This = 
            navPool.
            Claim_Open_Navpoint(
            transform).
            transform) == null) //NULL HAPPENS HERE (transform)
            {
            Debug.Log("Tried to get a point but no point was received.");
            }
            else
            {
            Debug.Log("Tried to get a point - and got one.");
            }
        ;
        }
    }

    bool Check_For_Shooting_Conditions()
    {
        // Null reference check - Gabe
        if(agent != null && targeter != null)
        {
            if(agent.isStopped == true && targeter.closest_enemy != null)
            {
                return true;
            }
        }
        return false;
    }

    void Turn_To_Closest_Enemy()
    {
        transform.LookAt(targeter.closest_enemy);
    }

    void Shoot_If_Shot_Exists()
    {
        RaycastHit hitInfo;

        if(Physics.Raycast(shotpoint.transform.position, transform.forward, out hitInfo, 20))
        {
            if(hitInfo.transform.tag == "Enemy") {shotpoint.Start_Shooting();}
        }
        else
        {
            shotpoint.Stop_Shooting();
        }
    }

    //Goto cycler for auto adjustments while moving
    IEnumerator Goto_CO()
    {
        GotoPoint();
        yield return wait;
        StartCoroutine(Goto_CO());
    }

    IEnumerator Check_If_Player_Moving_CO()
    {
        if(player.isMoving == true)
        {
            agent.isStopped = false;
        }
        else
        {
            StartCoroutine(Ease_Out_Stop_Moving());
        }
        yield return wait;
        StartCoroutine(Check_If_Player_Moving_CO());     
    }

    IEnumerator Ease_Out_Stop_Moving()
    {
        yield return wait;
        agent.isStopped = true;
    }
}
