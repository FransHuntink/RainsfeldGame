using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManagerNew : MonoBehaviour
{
    //adjustables
    [Header("Color adjustables")]
    [SerializeField]
    private Material foliageMaterial, terrainMaterial, backgroundMaterial; //all plants/trees/greens
    [SerializeField]
    private float lerpSmoothness = 0.5f;
    [SerializeField]
    private float lerpStepSize = 0.02f;
    [SerializeField]
    private bool allowQueue = true; // do we queue color changes or ignore if already in transition

    //store runtime data
    [SerializeField]
    private List<ColorPreset> presetQueue = new List<ColorPreset>();

    //flags
    private bool isTransitioning = false; // if colorManager is currently transitioning 
  
    private enum TargetSprite
    {
        FOLIAGE, TERRAIN
    }
    void Start()
    {
        //StartCoroutine(SetManualColor(Color.red, backgroundMaterial));
        // StartCoroutine(SetManualColor(Color.white, terrainMaterial));
        ColorPreset sunnyDay = new ColorPreset("sunnyDay", Color.green, Color.grey, Color.red);
        ColorPreset nightTime = new ColorPreset("Nighttime", Color.gray, Color.grey, Color.gray);

        SetColor(sunnyDay);
        SetColor(nightTime);  
    }

    private bool SetColor(ColorPreset preset)
    {
        if (isTransitioning)
        {
            //we either ignore this preset or add it to our queue
            DebugManager.dm.Out("ColorManager: Refused attempt to apply two presets simultaniously. Add to queue is " + allowQueue);

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
            //apply preset to foliage, terrain and background
            foliageMaterial.color = Color.Lerp(foliageMaterial.color, preset.foliageColor, t);
            terrainMaterial.color = Color.Lerp(terrainMaterial.color, preset.terrainColor, t);
            backgroundMaterial.color = Color.Lerp(backgroundMaterial.color, preset.backgroundColor, t);

            t += step;
            yield return new WaitForSeconds(lerpSmoothness);
        }
        t = 0;

        isTransitioning = false;
        DebugManager.dm.Out("ColorManager: Applied color preset " + preset.presetName);

    }

    //update ingame color manually - unused
    private IEnumerator SetManualColor(Color targetColor, Material spriteToAdjust)
    {
        float t = 0;
        float step = 0.02f;
        while (t < 1)
        {
            spriteToAdjust.color = Color.Lerp(spriteToAdjust.color, targetColor, t);
            t += step;
            yield return new WaitForSeconds(lerpSmoothness);
        }
        t = 0;

    }



}

