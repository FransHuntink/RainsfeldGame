using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPreset : MonoBehaviour {

    /// <summary>
    /// Class that stores preset colors for terrain,
    /// </summary>
    
    public string presetName;
    public Color terrainColor;
    public Color foliageColor;
    public Color backgroundColor;

    //initialize the preset
    public ColorPreset(string pName, Color terrainCol, Color foliageCol, Color bgCol)
    {
        presetName = pName;
        terrainColor = terrainCol;
        foliageColor = foliageCol;
        backgroundColor = bgCol;
    }
	
}
