using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCChat : NPCBase {
    public int ID; //unique ID that every NPC has

	// Use this for initialization
	void Start () {
        string tempString = ChatHandler.ReadString("Assets/Resources/NPC" + ID + "/dialog.txt");
        List<string> tempstringlist = ChatHandler.FormatString(tempString);  
	}

    // Update is called once per frame
    void Update () {
		
	}
}
