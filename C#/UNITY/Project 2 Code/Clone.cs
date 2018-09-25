using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System;

public class Clone : MonoBehaviour {

    public GameObject Object;
    public Transform Enemy;

    float OffsetX;
    float OffsetY;
    float OffsetZ;

    float Rotation;
    
    

    [SerializeField]
    Vector3 Offset;


    private void Start()
    {
        InvokeRepeating("CloneEnemy", 1f, 10f);

        float OffsetX = UnityEngine.Random.Range(1, 10);
        float OffsetY = UnityEngine.Random.Range(1, 10);
        float OffsetZ = UnityEngine.Random.Range(1, 10);

    }
    void CloneEnemy ()
    {
        Vector3 CurrentPos = new Vector3(Enemy.position.x + OffsetX, Enemy.position.y + OffsetY, Enemy.position.z + OffsetZ);
        
        Instantiate(Object, CurrentPos + Offset, Quaternion.identity);

        
    }
    
}
