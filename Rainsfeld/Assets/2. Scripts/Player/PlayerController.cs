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



    private void PlayerControlListener()
    {
        if (Input.GetButtonDown("Interact"))
        {
            base.OnInteraction();
        }
    }

   public void RespawnPlayer()
    {
        if (respawnPos != null)
            gameObject.transform.position = respawnPos + new Vector2(0, 15);

        ColorManager.cm.InvokeSetColor(0);
    }
   
}
    