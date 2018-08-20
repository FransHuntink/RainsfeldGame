using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class LightningPreset
{

    /// <summary> 
    /// Class that stores preset 
    /// settings for light sources
    /// currently unused
    /// </summary>

    public string presetName;
    public Color lightningColor;

    //initialize the preset
    public LightningPreset(string pName, Color lcolor)
    {
        lightningColor = lcolor;
    }

}
