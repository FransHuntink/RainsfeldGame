using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressManager : MonoBehaviour {

    /// <summary>
    /// This class will load an XML 
    /// template save file from somewhere
    /// Right now, hacked together to load
    /// </summary>


    
    public static ProgressManager pm;
    private int progress;

    void Awake()
    {
        pm = this;
    }
    

	

}
