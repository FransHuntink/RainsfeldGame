using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteColorManager : MonoBehaviour{
    /// <summary>
    /// individual script that manages the color of the sprites
    /// that are a child of this GameObject
    /// </summary>
    [SerializeField]
    private List<SpriteRenderer> reactingSprites = new List<SpriteRenderer>();
    [SerializeField]
    private List<Color> originalColors = new List<Color>();


	// Use this for initialization
	void Start () {
	    GrabSprites();
        ColorManager.instance.spriteInstances.Add(this);
        
	}
	
    //grab all child sprites from this object because it reacts to color
    private void GrabSprites()
    {
        foreach(Transform trans in gameObject.transform)
        {
            if (trans.GetComponent<SpriteRenderer>() != null)
            {
                reactingSprites.Add(trans.gameObject.GetComponent<SpriteRenderer>());
                originalColors.Add(trans.gameObject.GetComponent<SpriteRenderer>().color);
            }
                    
        }
    }

    //this function passes values to the coroutine
    public void PassUpdateColor(Color color, bool originalColor = false)
    {
        if (originalColor) 
        {
            StartCoroutine(ReturnDefaultColor());
        }
        else
        {
            StartCoroutine((UpdateColor((color))));
        }

    }
    //update color of all sprites childed to this class
    private IEnumerator UpdateColor(Color targetColor)
    {

        float t = 0;

       
        for(int i = 0; i < reactingSprites.Count; i++)
        {
            while (t < 1)
            {
              reactingSprites[i].color = Color.Lerp(reactingSprites[i].color, targetColor, t);
              t += 0.1f;
              yield return new WaitForSeconds(ColorManager.instance.lerpSmoothness); 
            }
            t = 0;

        }

    }
    
    public IEnumerator ReturnDefaultColor()
    {
        float t = 0;
        for (var i = 0; i < reactingSprites.Count; i++)
        {
            while (t < 1)
            {
                reactingSprites[i].color = Color.Lerp(reactingSprites[i].color, originalColors[i], t);
                t += 0.1f;
                yield return new WaitForSeconds(ColorManager.instance.lerpSmoothness);
            }
            t = 0;

        }
    }

}
