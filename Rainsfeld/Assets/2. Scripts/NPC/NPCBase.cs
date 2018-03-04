using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBase : MonoBehaviour {

    /// <summary>
    /// A class with all shared variables between NPCs
    /// 

    [HideInInspector]
    public NPCChat chatController;
    [HideInInspector]
    public NPCMovement npcMovement;
    public Rigidbody2D NPCrigid;

    public virtual void initializeNPC()
    {
        if (chatController == null)
            chatController = GetComponentInChildren<NPCChat>();

        if (npcMovement == null)
            npcMovement = GetComponent<NPCMovement>();

        if (NPCrigid == null)
            NPCrigid = GetComponent<Rigidbody2D>();

    }
 
}
