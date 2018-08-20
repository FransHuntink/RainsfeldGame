using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class ColorPreset  {

    /// <summary>
    /// Class that stores preset colors for terrain,
    /// </summary>

    public string presetName;
    public Color terrainColor;
    public Color foliageColor;
    public Color backgroundColor;
    public Color lightningColor;

    //initialize the preset
    public ColorPreset(string pName, Color terrainCol, Color foliageCol, Color bgCol, Color lCol)
    {
        presetName = pName;
        terrainColor = terrainCol;
        foliageColor = foliageCol;
        backgroundColor = bgCol;
        lightningColor = lCol;
    }
	
}
