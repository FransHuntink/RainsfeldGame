using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventTrigger : MonoBehaviour {

    public UnityEvent[] eventList;

    /// <summary>
    /// Teleports the player
    /// On trigger to specified 
    /// location or scene
    /// </summary>
    

    
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            PlayerCollision();
        }
    }

    //invoke the specified teleporter event
    private void PlayerCollision()
    {
   
        if(eventList != null)
        {
            for (int i = 0; i < eventList.Length; i++)
                eventList[i].Invoke();
        }
    }
}
