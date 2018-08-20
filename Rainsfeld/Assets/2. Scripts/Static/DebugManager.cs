using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugManager : MonoBehaviour {
    

    private static bool createdManager = false;
    /// <summary>
    /// All debugging should go through this manager
    /// Functions as debug on/off switch
    /// </summary>
    /// 

    public static DebugManager dm;
    public bool isDebugging = true;

	void Awake () {
        dm = this;

        if(!createdManager)
        {
            DontDestroyOnLoad(this.gameObject);
            createdManager = true;
        }



    }
    
    //will debug the message if it is enabled
    public void Out(string msg)
    {
        if (isDebugging)
            Debug.Log(msg);

    }

}
