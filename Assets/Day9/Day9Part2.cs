using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day9Part2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

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

        List<int[]> lowPoints = new List<int[]>();

        for (int i = 0; i < lavaTubes.Length; i++)
        {
            for (int k = 0; k < lavaTubes[i].Length; k++)
            {
                if (k > 0 && lavaTubes[i][k] > lavaTubes[i][k - 1])
                    continue;

                if (k < lavaTubes[i].Length - 1 && lavaTubes[i][k] >= lavaTubes[i][k + 1])
                    continue;

                if (i > 0 && lavaTubes[i][k] >= lavaTubes[i - 1][k])
                    continue;

                if (i < lavaTubes.Length - 1 && lavaTubes[i][k] >= lavaTubes[i + 1][k])
                    continue;

                lowPoints.Add(new int[] { i, k });
            }
        }

        int[] largestBasins = new int[] {0,0,0};

        for (int i = 0; i < lowPoints.Count; i++)
        {
            List<int[]> usedCoordinatesAsInts = new List<int[]>();
            HashSet<string> usedCoordinatesAsStrings = new HashSet<string>();
            usedCoordinatesAsInts.Add(lowPoints[i]);
            usedCoordinatesAsStrings.Add(lowPoints[i][0] + ", " + lowPoints[i][1]);
            int basinSize = 1;

            for (int k = 0; k < usedCoordinatesAsInts.Count; k++)
            {
                if (usedCoordinatesAsInts[k][1] > 0 && lavaTubes[usedCoordinatesAsInts[k][0]][usedCoordinatesAsInts[k][1] - 1] < 9 && usedCoordinatesAsStrings.Add(usedCoordinatesAsInts[k][0] + ", " + (usedCoordinatesAsInts[k][1] - 1)))
                {
                    usedCoordinatesAsInts.Add(new int[] { usedCoordinatesAsInts[k][0], usedCoordinatesAsInts[k][1] - 1 });
                    basinSize++;
                }

                if (usedCoordinatesAsInts[k][1] < lavaTubes[usedCoordinatesAsInts[k][0]].Length - 1 && lavaTubes[usedCoordinatesAsInts[k][0]][usedCoordinatesAsInts[k][1] + 1] < 9 && usedCoordinatesAsStrings.Add(usedCoordinatesAsInts[k][0] + ", " + (usedCoordinatesAsInts[k][1] + 1)))
                {
                    usedCoordinatesAsInts.Add(new int[] { usedCoordinatesAsInts[k][0], usedCoordinatesAsInts[k][1] + 1 });
                    basinSize++;
                }

                if (usedCoordinatesAsInts[k][0] > 0 && lavaTubes[usedCoordinatesAsInts[k][0] - 1][usedCoordinatesAsInts[k][1]] < 9 && usedCoordinatesAsStrings.Add((usedCoordinatesAsInts[k][0] - 1) + ", " + usedCoordinatesAsInts[k][1]))
                {
                    usedCoordinatesAsInts.Add(new int[] { usedCoordinatesAsInts[k][0] - 1, usedCoordinatesAsInts[k][1] });
                    basinSize++;
                }

                if (usedCoordinatesAsInts[k][0] < lavaTubes.Length - 1 && lavaTubes[usedCoordinatesAsInts[k][0] + 1][usedCoordinatesAsInts[k][1]] < 9 && usedCoordinatesAsStrings.Add((usedCoordinatesAsInts[k][0] + 1) + ", " + usedCoordinatesAsInts[k][1]))
                {
                    usedCoordinatesAsInts.Add(new int[] { usedCoordinatesAsInts[k][0] + 1, usedCoordinatesAsInts[k][1] });
                    basinSize++;
                }
            }



            int temp = int.MaxValue;
            int arrayLoc = 0;
            for (int p = 0; p < largestBasins.Length; p++)
            {
                if (largestBasins[p] < temp)
                {
                    temp = largestBasins[p];
                    arrayLoc = p;
                }
            }

            if (basinSize > temp)
                largestBasins[arrayLoc] = basinSize;
        }

       Debug.Log(largestBasins[0] * largestBasins[1] * largestBasins[2]);

    }
}
