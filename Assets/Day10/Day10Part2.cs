using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day10Part2 : MonoBehaviour
{
    //int normalBracket, curlyBracket, squareBracket, pointyBracket;
    // Start is called before the first frame update
    void Start()
    {
        //This is the text file with the information
        string path = "Assets/Resources/Day10Input.txt";

        //I'm going to read it with a streamreader. This way I don't have to
        //copy paste everything here.
        System.IO.StreamReader reader = new System.IO.StreamReader(path);

        //I read the line with the streamreader
        string line = reader.ReadLine();

        List<long> incompleteLinesPoints = new List<long>();

        while (line != null)
        {
            List<char> waitingLine = new List<char>();
            char[] lineCharacters = line.ToCharArray();

            for (int i = 0; i < lineCharacters.Length; i++)
            {
                if (lineCharacters[i] == '(' || lineCharacters[i] == '[' || lineCharacters[i] == '{' || lineCharacters[i] == '<')
                {
                    waitingLine.Add(lineCharacters[i]);
                }

                if (lineCharacters[i] == ')')
                {
                    if (waitingLine[waitingLine.Count - 1] == '(')
                    {
                        waitingLine.RemoveAt(waitingLine.Count - 1);
                    }

                    else
                        break;
                }

                if (lineCharacters[i] == '}')
                {
                    if (waitingLine[waitingLine.Count - 1] == '{')
                    {
                        waitingLine.RemoveAt(waitingLine.Count - 1);
                    }

                    else
                        break;
                }

                if (lineCharacters[i] == ']')
                {
                    if (waitingLine[waitingLine.Count - 1] == '[')
                    {
                        waitingLine.RemoveAt(waitingLine.Count - 1);
                    }

                    else
                        break;
                }

                if (lineCharacters[i] == '>')
                {
                    if (waitingLine[waitingLine.Count - 1] == '<')
                    {
                        waitingLine.RemoveAt(waitingLine.Count - 1);
                    }

                    else
                        break;
                }

                if (i == lineCharacters.Length - 1 && waitingLine.Count != 0)
                {
                    //complete the line
                    long totalScoreOfThisLine = 0;

                    for (int k = waitingLine.Count - 1; k >= 0; k--)
                    {
                        if (waitingLine[k] == '(')
                        {
                            totalScoreOfThisLine = (totalScoreOfThisLine * 5) + 1;
                        }

                        if (waitingLine[k] == '[')
                        {
                            totalScoreOfThisLine = (totalScoreOfThisLine * 5) + 2;
                        }

                        if (waitingLine[k] == '{')
                        {
                            totalScoreOfThisLine = (totalScoreOfThisLine * 5) + 3;
                        }

                        if (waitingLine[k] == '<')
                        {
                            totalScoreOfThisLine = (totalScoreOfThisLine * 5) + 4;
                        }
                    }

                    incompleteLinesPoints.Add(totalScoreOfThisLine);
                }
            }

            line = reader.ReadLine();
        }

        //now to sort the scores.
        int usedAlgorithm = 1;

        while (usedAlgorithm != 0)
        {
            usedAlgorithm = 0;

            for (int i = 0; i < incompleteLinesPoints.Count; i++)
            {
                if (i < incompleteLinesPoints.Count - 1)
                {
                    for (int k = i + 1; k < incompleteLinesPoints.Count - 1; k++)
                    {
                        if (incompleteLinesPoints[i] > incompleteLinesPoints[k])
                        {
                            long temp = incompleteLinesPoints[i];
                            incompleteLinesPoints[i] = incompleteLinesPoints[k];
                            incompleteLinesPoints[k] = temp;
                            usedAlgorithm++;
                        }
                    }
                }

                if (i > 0)
                {
                    for (int k = i - 1; k > 0; k--)
                    {
                        if (incompleteLinesPoints[i] < incompleteLinesPoints[k])
                        {
                            long temp = incompleteLinesPoints[i];
                            incompleteLinesPoints[i] = incompleteLinesPoints[k];
                            incompleteLinesPoints[k] = temp;
                            usedAlgorithm++;
                        }
                    }
                }
            }
        }

        long middleNumber = incompleteLinesPoints[((incompleteLinesPoints.Count - 2) / 2) + 1];

        Debug.Log(middleNumber);
    }
}
