using System;
using System.Collections.Generic;
using UnityEngine;

public class Day13Part1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //This is the text file with the information
        string path = "Assets/Resources/Day13Dots.txt";

        //I'm going to read it with a streamreader. This way I don't have to
        //copy paste everything here.
        System.IO.StreamReader reader = new System.IO.StreamReader(path);

        //I read the line with the streamreader
        string line = reader.ReadLine();

        List<int[]> dots = new List<int[]>();

        while (line != null)
        {
            char[] lineCharacters = line.ToCharArray();

            char[] smallNumberMaker = new char[] { 'i', 'i', 'i', 'i' };

            int[] thisCoordinate = new int[2];
            for (int i = 0; i < lineCharacters.Length; i++)
            {
                if (char.IsDigit(lineCharacters[i]))
                {
                    if (smallNumberMaker[0] == 'i')
                    {
                        smallNumberMaker[0] = lineCharacters[i];
                    }
                    else if (smallNumberMaker[1] == 'i')
                    {
                        smallNumberMaker[1] = lineCharacters[i];
                    }
                    else if (smallNumberMaker[2] == 'i')
                    {
                        smallNumberMaker[2] = lineCharacters[i];
                    }
                    else if (smallNumberMaker[3] == 'i')
                    {
                        smallNumberMaker[3] = lineCharacters[i];
                    }
                }

                if (lineCharacters[i] == ',' || i == lineCharacters.Length - 1)
                {
                    int thisNumber;
                    //make the smallnumbermaker into a number and add it to the pullingnumbers array
                    if (smallNumberMaker[1] == 'i')
                    {
                        thisNumber = smallNumberMaker[0] - '0';
                    }
                    else if (smallNumberMaker[2] == 'i')
                    {
                        string numberString = new string(new char[] { smallNumberMaker[0], smallNumberMaker[1] });
                        thisNumber = int.Parse(numberString);
                    }
                    else if (smallNumberMaker[3] == 'i')
                    {
                        string numberString = new string(new char[] { smallNumberMaker[0], smallNumberMaker[1], smallNumberMaker[2] });
                        thisNumber = int.Parse(numberString);
                    }
                    else
                    {
                        string numberString = new string(smallNumberMaker);
                        thisNumber = int.Parse(numberString);
                    }

                    //assign number
                    if (lineCharacters[i] == ',')
                    {
                        //x coordinate
                        thisCoordinate[0] = thisNumber;
                    }
                    else
                    {
                        //y coordinate
                        thisCoordinate[1] = thisNumber;
                    }

                    //reset smallnumbermaker and continue
                    smallNumberMaker = new char[] { 'i', 'i', 'i', 'i' };
                }

                dots.Add(thisCoordinate);
            }

            line = reader.ReadLine();

        }

        int xSize = 0;
        int ySize = 0;

        foreach (int[] coordinate in dots)
        {
            if (coordinate[0] > xSize)
                xSize = coordinate[0];

            if (coordinate[1] > ySize)
                ySize = coordinate[1];
        }

        bool[,] dotsArray = new bool[xSize + 1, ySize + 1];

        foreach (int[] coordinate in dots)
        {
            dotsArray[coordinate[0], coordinate[1]] = true;
        }

        //now all the dots are true, and no dots is false.
        //now to fold

        //gotta read that other input
        path = "Assets/Resources/Day13Folds.txt";
        reader = new System.IO.StreamReader(path);
        line = reader.ReadLine();


        //we got an array to check wether it's x or y, and an array for the line it folds at.
        char[] xOrY = new char[12];
        int[] foldArray = new int[12];

        int foldArrayLocation = 0;
        while (line != null)
        {
            char[] lineCharacters = line.ToCharArray();

            char[] smallNumberMaker = new char[] { 'i', 'i', 'i' };
            for (int i = 0; i < lineCharacters.Length; i++)
            {
                if (lineCharacters[i] == 'x' || lineCharacters[i] == 'y')
                {
                    xOrY[foldArrayLocation] = lineCharacters[i];
                }

                if (char.IsDigit(lineCharacters[i]))
                {
                    if (smallNumberMaker[0] == 'i')
                    {
                        smallNumberMaker[0] = lineCharacters[i];
                    }
                    else if (smallNumberMaker[1] == 'i')
                    {
                        smallNumberMaker[1] = lineCharacters[i];
                    }
                    else if (smallNumberMaker[2] == 'i')
                    {
                        smallNumberMaker[2] = lineCharacters[i];
                    }
                }

                if(i == lineCharacters.Length - 1)
                {
                    int thisNumber = 0;
                    if (smallNumberMaker[1] == 'i')
                    {
                        thisNumber = smallNumberMaker[0] - '0';
                    }
                    else if (smallNumberMaker[2] == 'i')
                    {
                        string numberString = new string(new char[] { smallNumberMaker[0], smallNumberMaker[1] });
                        thisNumber = int.Parse(numberString);
                    }
                    else
                    {
                        string numberString = new string(new char[] { smallNumberMaker[0], smallNumberMaker[1], smallNumberMaker[2] });
                        thisNumber = int.Parse(numberString);
                    }

                    foldArray[foldArrayLocation] = thisNumber;
                }
            }

            foldArrayLocation++;
            line = reader.ReadLine();
        }

        for(int i = 0; i < 12; i++)
        {
            bool[,] newArray = null;
            if(xOrY[i] == 'x')
            {
                //fold along sideways, along a column
                newArray = new bool[foldArray[i], dotsArray.GetLength(1)];

                for(int k = 0; k < dotsArray.GetLength(0); k++)
                {
                    for(int p = 0; p < dotsArray.GetLength(1); p++)
                    {
                        if (dotsArray[k, p])
                        {
                            if (k < foldArray[i])
                            {
                                newArray[k, p] = dotsArray[k, p];
                            }

                            else if(k == foldArray[i])
                            {
                                continue;
                            }

                            else
                            {
                                newArray[dotsArray.GetLength(0) - k - 1, p] = dotsArray[k, p];
                            }
                        }
                    }
                }
            }
            else
            {
                //fold along upwards, along a row
                newArray = new bool[dotsArray.GetLength(0), foldArray[i]];

                for (int k = 0; k < dotsArray.GetLength(0); k++)
                {
                    for (int p = 0; p < dotsArray.GetLength(1); p++)
                    {
                        if (dotsArray[k, p])
                        {
                            if (p < foldArray[i])
                            {
                                newArray[k, p] = dotsArray[k, p];
                            }

                            else if (p == foldArray[i])
                            {
                                continue;
                            }
                            else
                            {
                                newArray[k, dotsArray.GetLength(1) - p - 1] = dotsArray[k, p];
                            }
                        }
                    }
                }
            }

            dotsArray = newArray;
        }

        int dotTotal = 0;
        foreach(bool dot in dotsArray)
        {
            if (dot)
                dotTotal++;
        }

        Debug.Log(dotTotal);
    }
}
