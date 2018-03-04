using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : NPCBase, IInteractable {

    /// <summary>
    /// This class is the root class of all classes
    /// associated with the NPC.
    /// This class should always be on the root object of the NPC!
    /// </summary>


	// Use this for initialization
    void Start()
    {
        initializeNPC();
    }

    void Update()
    {
      
    }

    public override void initializeNPC()
    {
        base.initializeNPC();
    }

    public void OnInteractedWith()
    {
        //send the chat interaction to our chatController NPC class
        Debug.Log(DebugHandler.debugType.Interaction + ": NPC received interaction of player.");
        chatController.OnChatTrigger();
    }



}
