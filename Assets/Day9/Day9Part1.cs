using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day9Part1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        int totalPoints = 0;
        //This is the text file with the information
        string path = "Assets/Resources/Day9Input.txt";

        //I'm going to read it with a streamreader. This way I don't have to
        //copy paste everything here.
        System.IO.StreamReader reader = new System.IO.StreamReader(path);

        //I read the line with the streamreader
        string line = reader.ReadLine();

        int[][] lavaTubes = new int[100][];
        int xPart = 0;
        while (line != null)
        {
            char[] lineCharacters = line.ToCharArray();

            lavaTubes[xPart] = new int[lineCharacters.Length];
            for (int i = 0; i < lineCharacters.Length; i++)
            {
                lavaTubes[xPart][i] = lineCharacters[i] - '0';
            }
            xPart++;
            line = reader.ReadLine();
        }


        for(int i = 0; i < lavaTubes.Length; i++)
        {
            for(int k = 0; k < lavaTubes[i].Length; k++)
            {
                if(k > 0 && lavaTubes[i][k] > lavaTubes[i][k - 1])
                    continue;

                if (k < lavaTubes[i].Length - 1 && lavaTubes[i][k] >= lavaTubes[i][k + 1])
                    continue;

                if (i > 0 && lavaTubes[i][k] >= lavaTubes[i - 1][k])
                    continue;

                if (i < lavaTubes.Length - 1 && lavaTubes[i][k] >= lavaTubes[i + 1][k])
                    continue;

                totalPoints += lavaTubes[i][k] + 1;
            }
        }

        Debug.Log(totalPoints);
    }
}
