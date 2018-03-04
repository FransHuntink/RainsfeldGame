using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{

    public GameObject playerObject;
    public float interactionRange = 5f;

    public virtual void InitializePlayer()
    {
        if (playerObject == null)
            playerObject = gameObject;
    }

    public virtual void OnInteraction()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(gameObject.transform.position, interactionRange);
        for (int i = 0; i < hitColliders.Length; i++)
        {
            if (hitColliders[i].GetComponent<NPCController>() != null)
            {
                hitColliders[i].GetComponent<NPCController>().OnInteractedWith();
            }
        }
    }
}
