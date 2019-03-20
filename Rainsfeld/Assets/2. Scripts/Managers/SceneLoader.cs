using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    public static SceneLoader sl;


    void Awake()
    {
        sl = this;
    }


    
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public string GetCurrentScene()
    {
        string scene = SceneManager.GetActiveScene().name;
        Debug.Log(scene);
        return scene;
    }

}
