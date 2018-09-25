using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjectSpawner : MonoBehaviour {

    public GameObject ObjectToSpawn;
    public Transform SpawnLocation;
    public float SpawnFrequency;

    public float TimeToRun;
    public float RepeatRate;

    public Vector3 Offset;

    private int NumOfObj = 0;

    public int MaxObjCount;
    
    //List with object components that need to be enabled
    [SerializeField]
    Behaviour[] ComponentsToEnable;

    private void Start()
    {
        
        InvokeRepeating("SpawnObject", TimeToRun, RepeatRate);
      
    }

    
    

    void SpawnObject ()
    {

        Vector3 Location = new Vector3(SpawnLocation.position.x + Offset.x, SpawnLocation.position.y + Offset.y, SpawnLocation.position.z + Offset.z);
        Instantiate(ObjectToSpawn, Location, Quaternion.identity);
        /*EnableObjectComponents()*/;
        CheckNumOfObj(NumOfObj, MaxObjCount);
       
        NumOfObj++;
        Debug.Log(NumOfObj);

    }

    //void EnableObjectComponents ()
    //{
    //    for (int i = 0; i < ComponentsToEnable.Length; i++)
    //    {
    //        ComponentsToEnable[i].enabled = true;
    //    }
    //}
    void CheckNumOfObj (int ObjCounter, int MaxObjCount)
    {
        if (ObjCounter > MaxObjCount)
        {
            Debug.Log("Too many objects");
        } else
        {
            Debug.Log("There are currently " + ObjCounter + " objects spawned in");
        }
    }

    

}
