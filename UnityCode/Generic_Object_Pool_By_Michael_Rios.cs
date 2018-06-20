using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//A generic object pool -> Written by Michael Rios

public class Generic_Object_Pool : MonoBehaviour {

	//Public Variables -> (Inspector Access)
	#region
	//The object being pooled
	[Tooltip("The object that needs to be pooled.")]
	public GameObject pool_Object;
	//A name for the object pool
	[Tooltip("The name of the object pool.")]
	public string pool_Name;
	//How many objects in the object pool?
	[Tooltip("How many obejects does this object ")]
	public int poolAmount;
	#endregion

	//Internal Variables
	#region
	//The array used for the object pool
	GameObject[] pool;
	#endregion

	//On Awake
	//Set and populate the pool
	void Awake()
	{
		Set_Pool();
		Populate_pool();
	}

	//Sets the pool size based on inspector
	void Set_Pool()
	{
		pool = new GameObject[poolAmount];
	}

	//Populates the pool based on inspector
	void Populate_pool()
	{
		for(int i=0; i<(poolAmount-1);i++)
		{
			GameObject this_Pool_Object = (GameObject)Instantiate(pool_Object);
  			this_Pool_Object.SetActive(false); 
 		 	pool[i] = this_Pool_Object;
		}
	}

	//Fetches a game object -> Returns null if no object is available
	public GameObject Fetch_Object()
	{
		for (int i=0; i<poolAmount-1; i++) 
		{
			if(pool[i] == null) {return null;}
    		if (!pool[i].activeInHierarchy) 
			{	
    			return pool[i];
    		}
 		}   
  		return null; //No object was available
	}	
}
