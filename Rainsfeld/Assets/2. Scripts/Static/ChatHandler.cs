using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class ChatHandler {
    /// <summary>
    /// An extension class that makes reading
    /// and formatting text from .txt documents
    /// easier for NPC dialog playback
    /// </summary>
    private static float maxChatWidth = 16; //amount of characters of space we have per line of string
    private static float maxChatHeight = 3f; //amount of lines of space we have per string


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

    //formats the string taken from text file to text that fits in a chat bubble
    public static List<string> FormatString(string stringToFormat)
    {
        List<string> stringContainer = new List<string>();

        //some variables for countinng
        string tempString = "";
        int width = 0;
        int height = 0;

        for(int i =0; i < stringToFormat.Length; i++)
        {
            char dot = '.';
            char space = ' ';
            if (stringToFormat[i] != dot) //not end of line -> We add the character to our string
            {
                width += 1;
               
                    //have we exceeded our maximum width for this string?
                    if (width > maxChatWidth && stringToFormat[i] == space)
                    {
                        //yes -> We add a NewLine to the string and reset the 
                        tempString += Environment.NewLine;
                        width = 0;
                        height += 1;
                    }
                    //we add the character to our tempString
                    tempString += stringToFormat[i];
  
            }
            else //end of line -> we add string to stringContainer and reset the tempString
            {
                stringContainer.Add(tempString);
                tempString = null;
                width = 0;
                height = 0;
            }

        }




        return stringContainer;
    }
}
