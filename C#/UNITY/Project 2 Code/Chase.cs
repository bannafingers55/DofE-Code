using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour {

    public Transform Player;
    public int MoveSpeed = 4;
    public int MaxDist = 10;
    public int MinDist = 5;

    public int GunDamage;
    public float fireRate;
    public GameObject Bullet;

    [SerializeField]
    Behaviour[] ComponentsToDisableOnDeath;
    public Transform target;
    public GameObject player;
    public GameObject townsfolk;

    public float bulletSpeed;

    [SerializeField]
    Behaviour[] ToEnableOnSpawn;

    [SerializeField]
    ParticleSystem blood;



    private void Start()
    {
        EnableComponentsOnSpawn();
        transform.LookAt(Player);
    }

    private void Update()
    {
       
        //transform.LookAt(Player);

        
        transform.position += transform.forward * MoveSpeed * Time.deltaTime;

        if (Vector3.Distance(transform.position, Player.position) <= MaxDist)
        {
            Debug.Log("Within shooting range");

            //for (int i = 0; i < ComponentsToDisableOnDeath.Length; i++)
            //{
            //    //ComponentsToDisableOnDeath[i].enabled = false;
            //}



        }
        
    }
    void EnableComponentsOnSpawn ()
    {
        for (int i = 0; i < ToEnableOnSpawn.Length; i++)
        {
            ToEnableOnSpawn[i].enabled = true;
        }
    }

    

    //void ShootPlayer ()
    //{
    //    GameObject projectile = Instantiate(Bullet, transform.position + (target.position - transform.position).normalized, Quaternion.LookRotation(target.position - transform.position));
    //    projectile.GetComponent<Rigidbody>().velocity = transform.GetComponent<Rigidbody>().velocity;
        
        
    //}
}
