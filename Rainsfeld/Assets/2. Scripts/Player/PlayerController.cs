using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PlayerBase {


    public static PlayerController instance;
    


	// Use this for initialization
	void Awake () {
        instance = this;
	}
    void Start()
    {
        InitializePlayer();
    }
    void Update()
    {
        PlayerControlListener();
    }

    public override void InitializePlayer()
    {
        base.InitializePlayer();  
    }

    public override void OnInteraction()
    {
        base.OnInteraction();
    }


    private void PlayerControlListener()
    {
        if (Input.GetButtonDown("Interact"))
        {
            Debug.Log(DebugHandler.debugType.Interaction + ": Player sent interaction");
            OnInteraction();
        }
    }
   
}
