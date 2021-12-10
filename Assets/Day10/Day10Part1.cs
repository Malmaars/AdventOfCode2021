using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day10Part1 : MonoBehaviour
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

        int errorPoints = 0;

        while(line != null)
        {
            //int normalBracket = 0;
            //int curlyBracket = 0;
            //int squareBracket = 0;
            //int pointyBracket = 0;

            List<char> waitingLine = new List<char>();
            char[] lineCharacters = line.ToCharArray();

            for (int i = 0; i < lineCharacters.Length; i++)
            {
                //Debug.Log(normalBracket);
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
                    {
                        errorPoints += 3;
                        break;
                    }
                }

                if (lineCharacters[i] == '}')
                {
                    if (waitingLine[waitingLine.Count - 1] == '{')
                    {
                        waitingLine.RemoveAt(waitingLine.Count - 1);
                    }

                    else
                    {
                        errorPoints += 1197;
                        break;
                    }
                }

                if (lineCharacters[i] == ']')
                {
                    if (waitingLine[waitingLine.Count - 1] == '[')
                    {
                        waitingLine.RemoveAt(waitingLine.Count - 1);
                    }

                    else
                    {
                        errorPoints += 57;
                        break;
                    }
                }

                if (lineCharacters[i] == '>')
                {
                    if (waitingLine[waitingLine.Count - 1] == '<')
                    {
                        waitingLine.RemoveAt(waitingLine.Count - 1);
                    }

                    else
                    {
                        errorPoints += 25137;
                        break;
                    }
                }
            }

            line = reader.ReadLine();
        }

        Debug.Log(errorPoints);
    }
}
