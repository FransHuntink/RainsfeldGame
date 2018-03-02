using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class ChatHandler {

    //reads a string
    public static string ReadString(string textPath)
    {
        string outputString;
        //string path = "Assets/4. Chats/NPC1/dialog.txt";

        StreamReader reader = new StreamReader(textPath);
        outputString = reader.ReadToEnd();
        reader.Close();

        return outputString;
    }

    public static List<string> FormatString(string stringToFormat)
    {
        List<string> stringContainer = new List<string>();

        //temporary vars
        int stringIndex = 0;
        string tempString = "";

        for(int i =0; i < stringToFormat.Length; i++)
        {
            char dot = '.';
            if (stringToFormat[i] != dot) //not end of line -> We add the character to our string
            {
                tempString += stringToFormat[i];
            }
            else //end of line -> we add string to stringContainer and reset the tempString
            {
                stringContainer.Add(tempString);
                tempString = null;  
            }

        }




        return stringContainer;
    }
}
