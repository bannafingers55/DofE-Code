using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(Player))]
public class playersetup : NetworkBehaviour
{

    [SerializeField]
    Behaviour[] componentsToDisable;

    [SerializeField]
    Behaviour[] componentsToDisableIfPaused;

    [SerializeField]
    string remoteLayerName = "RemotePlayer";
    [SerializeField]
    public bool Paused = false;
    // Use this for initialization
    void Start()
    {
        if (!isLocalPlayer)
        {
            DisableComponents();
            AssignRemoteLayer();
        }

        GetComponent<Player>().Setup();
    }
    public override void OnStartClient()
    {
        base.OnStartClient();
        string _netID = GetComponent<NetworkIdentity>().netId.ToString();
        Player _player = GetComponent<Player>();

        GameManager.RegisterPlayer(_netID, _player);
    }

    void AssignRemoteLayer()
    {
        gameObject.layer = LayerMask.NameToLayer(remoteLayerName);
    }
    void DisableComponents ()
    {
        for (int i = 0; i < componentsToDisable.Length; i++)
        {
            componentsToDisable[i].enabled = false;
        }
    }
    private void OnDisable()
    {
        GameManager.UnregisterPlayer(transform.name);
    }
    public void disableOnPause ()
    {
        for (int i = 0; i < componentsToDisableIfPaused.Length; i++)
        {
            componentsToDisableIfPaused[i].enabled = false;
        }
        Paused = true;
    }
    public void enableOnResume ()
    {
        for (int i = 0; i < componentsToDisableIfPaused.Length; i++)
        {
            componentsToDisableIfPaused[i].enabled = true;
            Paused = false;

        }
        Paused = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Paused == false)
        {
            disableOnPause();
            
        } else if (Input.GetKeyDown(KeyCode.Escape) && Paused == true )
        {
            enableOnResume();
           
            
        }
    }



}