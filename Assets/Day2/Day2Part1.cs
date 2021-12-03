using System.Collections;
using System.Linq;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Day2Part1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int horizontal = 0;
        int depth = 0;
        //This is the text file with the information
        string path = "Assets/Resources/Day2Movement.txt";

        //I'm going to read it with a streamreader. This way I don't have to
        //copy paste everything here.
        System.IO.StreamReader reader = new System.IO.StreamReader(path);

        //I read the line with the streamreader
        string line = reader.ReadLine();

        while (line != null)
        {
            int number = 0;
            char[] characters = line.ToCharArray();
            foreach(char character in characters)
            {
                if (Char.IsDigit(character))
                {
                    Debug.Log("CONVERTING CHARACTER");
                    int.TryParse(character.ToString(), out number);
                }
            }
            if (line.Contains("forward"))
            {
                //move horizontally
                horizontal += number;
            }

            if(line.Contains("up"))
            {
                //depth -1
                depth -= number;
            }

            if (line.Contains("down"))
            {
                //depth +1
                depth += number;
            }
            //I read the next line
            line = reader.ReadLine();
        }

        Debug.Log(horizontal * depth);
    }
}
