using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPCController : NPCBase, IInteractable {


    /// <summary>
    /// This class is the root class of all classes
    /// associated with the NPC.
    /// should always be on the root object of the NPC!
    /// </summary>

    //  [HideInInspector]
    public NPCChat chatController;

    void Start()
    {
        InitializeNPC();
    }

    //initialize this NPC
    private void InitializeNPC()
    {
        //DebugManager.dm.Out("NPCController - initialized this NPC");
        if (chatController == null)
            chatController = GetComponentInChildren<NPCChat>();
    }
    
    //someone interacts with this NPC
    public override void OnInteract()
    {
        chatController.OnChatTrigger();
        base.OnInteract();
    }


}
