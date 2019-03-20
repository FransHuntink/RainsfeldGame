using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    public static ColorManager cm;

    //adjustables
    [Header("Color adjustables")]
    [SerializeField]
    private Material foliageMaterial, terrainMaterial, backgroundMaterial; //all plants/trees/greens
    [SerializeField]
    private Light lightSource; 

    //lerp adjustables
    [SerializeField]
    private float lerpSmoothness = 0.5f;
    [SerializeField]
    private float lerpStepSize = 0.02f;
    [SerializeField]
    private bool allowQueue = false; // do we queue color changes or ignore if already in transition

    //store runtime data
    [SerializeField]
    private List<ColorPreset> presetQueue = new List<ColorPreset>();

    public ColorPreset[] savedColorPresets;
    //public LightningPreset[] saved

    //flags
    private bool isTransitioning = false; 

 
    void Awake()
    {
        cm = this;

    }

    public void InvokeSetColor(int index)
    {
        lightSource = GetComponentInChildren<Light>();

        /* We pick the preset based on index parameter */

        if (index <= savedColorPresets.Length)
            SetColor(savedColorPresets[index]);
    }

    //set a color preset
    private bool SetColor(ColorPreset preset)
    {
        if (isTransitioning)
        {
            //we either ignore this preset or add it to our queue
            DebugManager.dm.Out("ColorManager: Refused attempt to apply " +
                            "two presets simultaniously. Add to queue is " + allowQueue);

            if (allowQueue)
                presetQueue.Add(preset);

            return false;
        }
        else
        {
            //we apply the color preset
            StartCoroutine(ApplyPresetColor(preset));
            return true;
        }
    }


    //update ingame color using a color preset, do not call directly
    private IEnumerator ApplyPresetColor(ColorPreset preset)
    {

        isTransitioning = true;
        float t = 0;
        float step = lerpStepSize;
        while (t < 1)
        {
            for(int i = 0; i < preset.materials.Length; i++)
            {
                preset.materials[i].color = Color.Lerp(preset.materials[i].color, preset.materialColors[i], t);
                lightSource.color = Color.Lerp(lightSource.color, preset.lightningColor, t);
            }
 
            t += step;
            yield return new WaitForSeconds(lerpSmoothness);
        }
        t = 0;

        isTransitioning = false;

        DebugManager.dm.Out("ColorManager: Applied color preset " + preset.presetName);

    }




}

