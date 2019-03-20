using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class ColorPreset  {

    /// <summary>
    /// Class that stores preset colors for terrain,
    /// </summary>
   
    public string presetName;
    public Color lightningColor;
    

    // New dynamic material way
    public Material[] materials;
    public Color[] materialColors;


    /*
    //initialize the preset
    public ColorPreset(string pName, Color terrainCol, Color foliageCol, Color bgCol, Color lCol)
    {
        presetName = pName;
        terrainColor = terrainCol;
        foliageColor = foliageCol;
        backgroundColor = bgCol;
        lightningColor = lCol;
    }*/

    public ColorPreset(string name, Material[] materials, Color[] materialColors)
    {
        this.materials = materials;
        this.materialColors = materialColors;
    }
	
}
