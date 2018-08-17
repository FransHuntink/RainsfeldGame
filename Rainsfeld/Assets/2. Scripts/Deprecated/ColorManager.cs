using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    //enums
    public enum TimeOfDay
    {
        Dusk, Afternoon, Dawn, Night
    }

    public enum Weather
    {
        Sun, Rain
    }

    public enum ColorType
    {
        Platform, Sky
    }


    //adjustables
    [Header("Color options")]
    public float lerpSmoothness = 0.05f; //currently unused to prevent null ref-error

    //etc
    public static ColorManager instance;

    //hidden publics
    [NonSerialized] public List<SpriteColorManager> spriteInstances = new List<SpriteColorManager>();
     public GameObject rainSystem;

    //references
    public GameObject mainCamera;

    //privates
    
    [SerializeField] private List<Color> colorPresets = new List<Color>();
    [SerializeField] private List<Color> platformColorPresets = new List<Color>();
    private Color targetSkyColor;
    private Color targetPlatformColor;
    

  
    public void Awake()
    {
        instance = this;
    }

    public void SetTimeOfDay(TimeOfDay time)
    {
        Debug.Log("Setting time of day to "+ time);
        //to which time of day are we switching?
        switch (time)
        {
            case TimeOfDay.Dusk:
                targetPlatformColor = platformColorPresets[0];
                targetSkyColor = colorPresets[0];
                break;
            case TimeOfDay.Afternoon:
                //no need to set platform color, all objects return to their default color
                targetSkyColor = colorPresets[1];
                break;
            case TimeOfDay.Dawn:
                targetPlatformColor = platformColorPresets[2];
                targetSkyColor = colorPresets[2];
                break;
            case TimeOfDay.Night:
                targetPlatformColor = platformColorPresets[3];
                targetSkyColor = colorPresets[3];
                break;
            default:
                Debug.Log("Unknown enum passed to SetTimeOfDay function");
                break;

        }
        ApplyColors(ColorType.Sky,targetSkyColor);
        ApplyColors((ColorType.Platform),targetPlatformColor, time == TimeOfDay.Afternoon);

    }




    //this function allows users to set weather to a preset
    public void SetWeather(Weather weather)
    {
        if (weather == Weather.Rain)
        {
            rainSystem.SetActive((true));

            targetSkyColor = colorPresets[3];
            ApplyColors(ColorType.Sky, targetSkyColor);
        }
    }

    //this function applies changes made to colors
    private void ApplyColors(ColorType type, Color color, bool isAfternoon = false)
    {
        if (type == ColorType.Sky)
        {
            for (var i = 0; i < spriteInstances.Count; i++)
            {
                mainCamera.GetComponent<CameraBehaviour>().PassUpdateColor(targetSkyColor);
            }
        }

        if (type == ColorType.Platform)
        {
            for (var i = 0; i < spriteInstances.Count; i++)
            {
                spriteInstances[i].PassUpdateColor(color, isAfternoon);
            }

        }
       
    }

    //makes it possible to change timeOfDay through button input
    public void OnButtonPress(int id)
    {
        if (id == 0)
        {
            SetTimeOfDay(TimeOfDay.Dawn);
        }
        else if (id == 1)
        {
            SetTimeOfDay(TimeOfDay.Afternoon);
        }
        else if (id == 2)
        {
            SetTimeOfDay(TimeOfDay.Dusk);
        }
        else if (id == 3)
        {
            SetTimeOfDay((TimeOfDay.Night));
        }
        else if (id == 4)
        {
            SetWeather((Weather.Rain));
        }
    }



}
