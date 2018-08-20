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



    public override void OnInteraction()
    {
        base.OnInteraction();
    }


    private void PlayerControlListener()
    {
        if (Input.GetButtonDown("Interact"))
        {
            OnInteraction();
        }
    }

   public void RespawnPlayer()
    {
        if (respawnPos != null)
            gameObject.transform.position = respawnPos + new Vector2(0, 15);

        ColorManager.cm.InvokeSetColor(0);
    }
   
}
    