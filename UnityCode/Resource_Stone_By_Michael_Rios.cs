using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Resource Stone Destruction Handling and Object Pool Fetching - By Michael Rios

public class Resource_Stone : MonoBehaviour {

    //Private Variables
    #region 
    //Object pools
    //Pool for broken rocks
    Generic_Object_Pool rocks;
    //Pool for dust clouds
    Generic_Object_Pool dustClouds;
    //Objects received from pool
    //Storage for the returned broken rock
    GameObject pieces;
    //Storage for the returned dust cloud
    GameObject dustCloud;
    #endregion

    //Init
    void Start()
    {
        Get_Object_Pools();
    }

    //Gets the object pools from the level
    void Get_Object_Pools()
    {
        foreach(Generic_Object_Pool pool in FindObjectsOfType<Generic_Object_Pool>())
        {
            if(pool.pool_Name == "Rocks") {rocks = pool;}
            if(pool.pool_Name == "Dusts") {dustClouds = pool;}
        }
    }

    //Calls an object for both broken rock pieces and dust
    //If the return is not null then it places it where the
    //destroy object is.
    void OnDestroy()
    {
        pieces = rocks.Fetch_Object();
        dustCloud = dustClouds.Fetch_Object();
        if(pieces != null)
        {
            pieces.transform.position = transform.position;
            pieces.transform.rotation = transform.rotation;
            pieces.SetActive(true);
        }
        if(dustCloud != null)
        {
            dustCloud.transform.position = transform.position;
            dustCloud.transform.rotation = transform.rotation;
            dustCloud.SetActive(true);
        }
    }
}


