// IN YOUR EDITOR FOLDER, have SimpleEditorUtils.cs.
// paste in this text.
// to play, HIT COMMAND-ZERO rather than command-P
// (the zero key, is near the P key, so it's easy to remember)
// simply insert the actual name of your opening scene
// "__preEverythingScene" on the second last line of code below.

using UnityEditor;
using UnityEngine;
using System.Collections;


[InitializeOnLoad]
public static class SimpleEditorUtils
{
    // click command-0 to go to the prelaunch scene and then play

    [MenuItem("Play/PlayFromMenu")]
    public static void PlayFromPrelaunchScene()
    {
        if (EditorApplication.isPlaying == true)
        {
            EditorApplication.isPlaying = false;
            return;
        }
        EditorApplication.SaveCurrentSceneIfUserWantsTo();

        EditorApplication.OpenScene(
                    "Assets/0. Scenes/MainMenu.unity");
        EditorApplication.isPlaying = true;
    }
}