using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day11Part2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //This is the text file with the information
        string path = "Assets/Resources/Day11Input.txt";

        //I'm going to read it with a streamreader. This way I don't have to
        //copy paste everything here.
        System.IO.StreamReader reader = new System.IO.StreamReader(path);

        //I read the line with the streamreader
        string line = reader.ReadLine();

        int[,] dumboSquids = new int[10, 10];
        int loopCount = 0;

        int lineNumber = 0;
        while (line != null)
        {
            char[] lineCharacters = line.ToCharArray();

            for (int i = 0; i < lineCharacters.Length; i++)
            {
                dumboSquids[lineNumber, i] = lineCharacters[i] - '0';
            }

            lineNumber++;
            line = reader.ReadLine();
        }

        int allSquidsLight = 0;

        while(allSquidsLight < 100)
        {
            loopCount++;
            for (int i = 0; i < 10; i++)
            {
                for (int k = 0; k < 10; k++)
                {
                    dumboSquids[i, k]++;
                }
            }

            bool checker = false;


            while (checker == false)
            {
                checker = true;
                for (int i = 0; i < 10; i++)
                {
                    for (int k = 0; k < 10; k++)
                    {
                        if (dumboSquids[i, k] > 9)
                        {
                            for (int h = -1; h <= 1; h++)
                            {
                                if (i + h < 0 || i + h > 9)
                                {
                                    continue;
                                }
                                for (int p = -1; p <= 1; p++)
                                {
                                    if (k + p < 0 || k + p > 9)
                                    {
                                        continue;
                                    }

                                    if (dumboSquids[i + h, k + p] >= 0)
                                        dumboSquids[i + h, k + p]++;
                                }
                            }
                            checker = false;
                            dumboSquids[i, k] = -1;
                        }
                    }
                }
            }

            for (int i = 0; i < 10; i++)
            {
                for (int k = 0; k < 10; k++)
                {
                    if (dumboSquids[i, k] == -1)
                    {
                        allSquidsLight++;
                        dumboSquids[i, k] = 0;
                    }
                }
            }

            if(allSquidsLight >= 100)
            {
                break;
            }

            allSquidsLight = 0;
        }

        Debug.Log(loopCount);
    }
}
