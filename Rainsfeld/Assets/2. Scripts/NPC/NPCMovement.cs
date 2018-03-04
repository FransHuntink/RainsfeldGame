using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : NPCBase {
    /// <summary>
    /// This is the class that handles all AI movement and pathfinding
    /// for friendly NPCs
    /// </summary>

    [SerializeField]
    private float NPCSpeed = 15f;
    private float minDistance = 5f;
    

    void Start()
    {
        initializeNPC();
    }
    void Update()
    {
        //MoveToPoint(PlayerController.instance.gameObject.transform.position);
    }

    //moves the NPC to a point based on distance checks - temporary 
    public void MoveToPoint(Vector2 target)
    {
        Debug.Log(Vector2.Distance(transform.position, target));

        if (Vector2.Distance(transform.position, target) > minDistance)
        {
            if (gameObject.transform.position.x < target.x)
            {
                NPCrigid.velocity = Vector2.right * NPCSpeed * Time.deltaTime;
            }
            else if (gameObject.transform.position.x > target.x)
            {
                NPCrigid.velocity = Vector2.left * NPCSpeed * Time.deltaTime;
            }
        }
        else
        {
            Debug.Log("STOP");
            NPCrigid.velocity = Vector2.zero;
        }
    }

}
