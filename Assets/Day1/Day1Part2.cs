using System.Collections;
using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class Day1Part2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //This is the text file with the information
        string path = "Assets/Resources/Day1Depth.txt";

        //I'm going to read it with a streamreader. This way I don't have to
        //copy paste everything here.
        System.IO.StreamReader reader = new System.IO.StreamReader(path);

        //I'm going to add each line in a List<string>, so every entry is in a seperate part of the list, easily accessible
        List<int> DepthNumbers = new List<int>();

        //I don't need to sort them, so I just need to read every line and put them in a list.

        //I read the line with the streamreader
        string line = reader.ReadLine();

        while (line != null)
        {
            //I can use string.contains to check for certain words.

            //I add the line to the List
            DepthNumbers.Add(Convert.ToInt32(line));

            //I read the next line
            line = reader.ReadLine();
        }

        int previousNumber = 0;
        int totalIncrease = 0;

        for(int i = 0; i < DepthNumbers.Count - 2; i++)
        {
            if(previousNumber == 0)
            {
                previousNumber = DepthNumbers[i] + DepthNumbers[i + 1] + DepthNumbers[i + 2];
                continue;
            }

            int currentNumber = DepthNumbers[i] + DepthNumbers[i + 1] + DepthNumbers[i + 2];

            if(currentNumber > previousNumber)
            {
                totalIncrease++;
            }

            previousNumber = currentNumber;
        }

        Debug.Log(totalIncrease);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
