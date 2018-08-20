using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{

    public GameObject playerObject;
    public float interactionRange = 5f;
    public Vector2 respawnPos;

    public virtual void InitializePlayer()
    {
        if (playerObject == null)
            playerObject = gameObject;

        respawnPos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
    }

    public virtual void OnInteraction()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(gameObject.transform.position, interactionRange);
        for (int i = 0; i < hitColliders.Length; i++)
        {
          //  if (hitColliders[i].GetComponent<NPCController>() != null)
            if(hitColliders[i].gameObject.CompareTag("Interactable"))
            {
               hitColliders[i].GetComponent<Interaction>().OnInteract();
            }
        }
    }
}
