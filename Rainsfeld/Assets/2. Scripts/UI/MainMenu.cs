using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    /// <summary>
    /// this class handles
    /// all main menu functionality
    /// </summary>
    private void Start()
    {
        StartScene("Prologue");
    }


    private void StartScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
