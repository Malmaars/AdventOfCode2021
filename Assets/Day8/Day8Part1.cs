using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day8Part1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //I'm gonna do this in a very simple way

        //This is the text file with the information
        string path = "Assets/Resources/Day8Input.txt";

        //I'm going to read it with a streamreader. This way I don't have to
        //copy paste everything here.
        System.IO.StreamReader reader = new System.IO.StreamReader(path);

        //I read the line with the streamreader
        string line = reader.ReadLine();

        int total1478 = 0;

        while (line != null)
        {
            char[] lineCharacters = line.ToCharArray();
            bool startLooking = false;
            int countingNumberSize = 0;
            for (int i = 0; i < lineCharacters.Length; i++)
            {
                if(startLooking == true)
                {
                    if(lineCharacters[i] != ' ')
                    {
                        countingNumberSize += 1;
                    }

                    if ((lineCharacters[i] == ' ' && countingNumberSize != 0) || i == lineCharacters.Length - 1)
                    {
                        if (countingNumberSize == 2 || countingNumberSize == 3 || countingNumberSize == 4 || countingNumberSize == 7)
                        {
                            total1478 += 1;
                        }
                        //create a new int
                        countingNumberSize = 0;
                    }
                }

                if(lineCharacters[i] == '|')
                {
                    //start looking at the next numbers
                    startLooking = true;
                }
            }
            line = reader.ReadLine();
        }

        Debug.Log(total1478);
    }
}
