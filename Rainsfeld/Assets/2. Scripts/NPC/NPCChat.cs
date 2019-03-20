using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCChat : NPCController
{
    /// <summary>
    /// OneTimeTrigger: Player triggers once, starts cycling through dialog
    /// ManualTrigger: Player triggers every time to cycle through dialog
    /// FullAuto: NPC plays dialog once player is in range or collided with 
    /// </summary>
   
    public enum dialogMode
    {
        OneTimeTrigger, ManualTrigger, OnCollide
    }

    //chat variables that are hidden
    private bool hasInitialized; //has this NPC initialized available dialog?
    private int dialogIndex; //INT to keep track of current dialog
    private TextMesh textMesh; //attached textMesh
    private bool isCycling;

    
    //chat variables that are adjustable
    [SerializeField]
    private int NPCId; //ID of the NPC
    [SerializeField]
    private List<string> dialogList = new List<string>();
    [SerializeField]
    private dialogMode dialogType;
    [SerializeField]
    private float chatCycleSpeed = 2f;
    [SerializeField]
    private float maxChatRange = 5f; //when does the NPC stop talking on disengage
    [SerializeField]
    private float dialogSpeed = 1f;
    [SerializeField]
    private bool smartTimer = true; //bases prompt time on string length
    [SerializeField]
    private SpriteRenderer chatBubbleSprite;
    private bool isInView;


    void Start()
    {
        InitializeComponents();
        GrabDialog();
    }

    //NPC automatically tries to initialize components when null
    private void InitializeComponents()
    {
        if (chatBubbleSprite == null)
            chatBubbleSprite = GetComponentInParent<SpriteRenderer>();

        chatBubbleSprite.enabled = false;
    }

    //grabs dialog from appropriate folder based on ID
    private void GrabDialog()
    {
        dialogIndex = 0;
        textMesh = GetComponent<TextMesh>();

        string tempString = ChatHandler.ReadString("Assets/Resources/NPC" + NPCId + "/dialog.txt");
        dialogList = ChatHandler.FormatString(tempString);

        if (dialogList.Count > 0)
        {
            hasInitialized = true;
        }
        else
        {
            DebugManager.dm.Out("NPCChat: Failed to initialize NPC text for " + gameObject.name);
        }
    }


    
    //player triggers the chat trigger on this NPC
    public void OnChatTrigger()
    {

        if (hasInitialized)
        {
            chatBubbleSprite.enabled = true;
            switch (dialogType)
            {

                case dialogMode.ManualTrigger:
                    dialogIndex = +1;
                    textMesh.text = dialogList[dialogIndex];
                    break;

                case dialogMode.OnCollide:
                    if(!isCycling)
                        StartCoroutine(CycleChats());
                    break;

                case dialogMode.OneTimeTrigger:
                    if (!isCycling)
                        StartCoroutine(CycleChats());
                    break;
            }
        }
        else
        {
        
        }
    }

    //cycles through the chats until chats are no longer available. We pause the cycle when player goes out of range
    private IEnumerator CycleChats()
    {
        isCycling = true;
        float cycleTime = 1f;
        textMesh.text = dialogList[dialogIndex];

        //if smartTimer is on, we base dialog on a base time + x seconds per character
        if (smartTimer)
        {
            cycleTime = 0.8f + dialogList[dialogIndex].Length * (0.03f * dialogSpeed);
        }
        yield return new WaitForSeconds(chatCycleSpeed * cycleTime);

        //check if the player is in range before we produce a new dialog 

        IsPlayerInRange(); 

        if (dialogIndex < dialogList.Count - 1)
        {
            
            if (isInView) 
            {
                dialogIndex += 1;
                StartCoroutine(CycleChats());
            }
            else
            {
                isCycling = false;
            }
        }
        else
        {
            isCycling = false;
        }
    }

    // Is the player in range?
    private void IsPlayerInRange()
    {
        Vector3 viewPos = Camera.main.WorldToViewportPoint(gameObject.transform.position); 
        if (viewPos.x >= 0 && viewPos.x <= 1)
        {
            isInView = true;
        }
        else
        {
            isInView = false;
        }
    }
}


