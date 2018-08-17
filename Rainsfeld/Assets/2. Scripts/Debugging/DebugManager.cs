using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugManager : MonoBehaviour {

    /// <summary>
    /// All debugging should go through this manager
    /// Functions as debug on/off switch
    /// </summary>
    /// 

    public static DebugManager dm;
    public bool isDebugging = true;

	void Awake () {
        dm = this;
	}
    
    //will debug the message if it is enabled
    public void Out(string msg)
    {
        if (isDebugging)
            Debug.Log(msg);
    }
	
}
