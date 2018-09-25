using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StayUpright : MonoBehaviour {

    public float MaxZRotation;
    public float MinZRotation;
    public float MaxXRotation;
    public float MinZotation;

    Vector3 DefaultRotation;

    public Transform Player;

    public Transform Parent;

    public Vector3 MinDistFromParen;

    [Range(1, 100)]
    public float Speed;

    Vector3 SafePos;
    private void Update()
    {
        transform.LookAt(Player);
        if (transform.rotation.x >= MaxXRotation || transform.rotation.x <= MinZRotation)
        {
            transform.Rotate(DefaultRotation);
            //Debug.Log("Correcting");
        } else if (transform.rotation.z >= MaxZRotation || transform.rotation.z <= MinZotation)
        {
            transform.Rotate(DefaultRotation);
            //Debug.Log("Correcting");
        }
        SetDistAwayFromOtherInstance();
    }

    void SetDistAwayFromOtherInstance ()
    {
        Vector3 DistFromParent = new Vector3(Parent.position.x - transform.position.x, Parent.position.y - transform.position.y, Parent.position.z - transform.position.z);

        if (DistFromParent.x >= MinDistFromParen.x && DistFromParent.y >= MinDistFromParen.y && DistFromParent.z <= MinDistFromParen.z)
        {
            SafePos = new Vector3(DistFromParent.x, transform.position.y, DistFromParent.z);
            
        }
        else if (DistFromParent.x <= MinDistFromParen.x && DistFromParent.y <= MinDistFromParen.y && DistFromParent.z <= MinDistFromParen.z)
        {
            transform.position = Vector3.MoveTowards(transform.position, SafePos, Speed * Time.deltaTime);
            Debug.Log("Moving to Safe Pos");
        }
        
    }
}
