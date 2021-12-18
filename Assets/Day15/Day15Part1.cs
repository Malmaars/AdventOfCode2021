using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Day15Part1 : MonoBehaviour
{
    int[,] chitons = new int[100, 100];
    //I could assign a new 100 by 100 int[,] to each branch, where I make the used value zero

    int shortestRoute = 5369;
    // Start is called before the first frame update
    void Start()
    {
        string path = "Assets/Resources/Day15Input.txt";

        //I'm going to read it with a streamreader. This way I don't have to
        //copy paste everything here.
        System.IO.StreamReader reader = new System.IO.StreamReader(path);

        //I read the line with the streamreader
        string line = reader.ReadLine();

        int lineNumber = 0;

        while (line != null)
        {
            char[] lineCharacters = line.ToCharArray();

            for (int i = 0; i < lineCharacters.Length; i++)
            {
                chitons[lineNumber, i] = lineCharacters[i];
            }
            lineNumber++;

            line = reader.ReadLine();
        }
        int[,] tempStringArray = new int[100, 100];
        for (int i = 0; i < tempStringArray.GetLength(0); i++)
        {
            for (int k = 0; k < tempStringArray.GetLength(1); k++)
            {
                tempStringArray[i, k] = chitons[i, k];
            }
        }

        NewBranch(tempStringArray, 0, 0, 0);
        Debug.Log(shortestRoute);
    }

    void NewBranch(int[,] route, int routeNumber, int xLoc, int yLoc)
    {
        int[,] newRoute = new int[100, 100];

        for (int i = 0; i < newRoute.GetLength(0); i++)
        {
            for (int k = 0; k < newRoute.GetLength(1); k++)
            {
                newRoute[i, k] = route[i, k];
            }
        }

        if (routeNumber > shortestRoute)
            return;

        if (xLoc == 99 && yLoc == 99 && routeNumber < shortestRoute)
        {   
            //we do good
            shortestRoute = routeNumber;
            return;
        }

        for (int i = -1; i <= 1; i += 2)
        {
            for (int k = -1; k <= 1; k += 2)
            {
                int newXLoc = xLoc + i;
                int newYLoc = yLoc + k;

                if(newXLoc < 0 || newXLoc > 99 || newYLoc < 0 || newYLoc > 99)
                {
                    continue;
                }

                if (newRoute[newXLoc, newYLoc] > 0)
                {
                    routeNumber += chitons[newXLoc, newYLoc];
                    newRoute[newXLoc, newYLoc] = 0;
                    NewBranch(newRoute, routeNumber, newXLoc, newYLoc);
                }
            }
        }
    }
}
