using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day5Part2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //list of all coordinates that are next to each other
        List<int[,]> allCoordinates = new List<int[,]>();
        List<int[]> dangerousCoordinates = new List<int[]>();
        //This is the text file with the information
        string path = "Assets/Resources/Day5Input.txt";

        //I'm going to read it with a streamreader. This way I don't have to
        //copy paste everything here.
        System.IO.StreamReader reader = new System.IO.StreamReader(path);

        //I read the line with the streamreader
        string line = reader.ReadLine();

        //first make a list of all the line that move horizontally or vertically

        while (line != null)
        {
            char[] characterArray = line.ToCharArray();

            char[] numberGenerator = new char[] { 'i', 'i', 'i' };

            int xCoordinate = 0;
            int[] firstCoordinateSet = new int[2];

            for (int i = 0; i < characterArray.Length; i++)
            {
                if (char.IsDigit(characterArray[i]))
                {
                    if (numberGenerator[0] == 'i')
                    {
                        numberGenerator[0] = characterArray[i];
                    }
                    else if (numberGenerator[1] == 'i')
                    {
                        numberGenerator[1] = characterArray[i];
                    }
                    else
                    {
                        numberGenerator[2] = characterArray[i];
                    }
                }

                if (characterArray[i] == ',')
                {
                    //the next digit and the previous digit form coordinates together
                    int newDigitCreated = 0;
                    if (numberGenerator[1] == 'i')
                    {
                        newDigitCreated = numberGenerator[0] - '0';
                    }
                    else if (numberGenerator[2] == 'i')
                    {
                        newDigitCreated = int.Parse(new string(new char[] { numberGenerator[0], numberGenerator[1] }));
                    }
                    else
                    {
                        newDigitCreated = int.Parse(new string(numberGenerator));
                    }

                    //save the previous digit, and prepare for the next digit
                    xCoordinate = newDigitCreated;
                    numberGenerator = new char[] { 'i', 'i', 'i' };
                }

                if (characterArray[i] == ' ' && numberGenerator[0] != 'i')
                {
                    int newDigitCreated = 0;
                    if (numberGenerator[1] == 'i')
                    {
                        newDigitCreated = numberGenerator[0] - '0';
                    }
                    else if (numberGenerator[2] == 'i')
                    {
                        newDigitCreated = int.Parse(new string(new char[] { numberGenerator[0], numberGenerator[1] }));
                    }
                    else
                    {
                        newDigitCreated = int.Parse(new string(numberGenerator));
                    }

                    firstCoordinateSet = new int[] { xCoordinate, newDigitCreated };
                    numberGenerator = new char[] { 'i', 'i', 'i' };
                }

                if (i == characterArray.Length - 1 && firstCoordinateSet != null)
                {
                    int newDigitCreated = 0;
                    if (numberGenerator[1] == 'i')
                    {
                        newDigitCreated = numberGenerator[0] - '0';
                    }
                    else if (numberGenerator[2] == 'i')
                    {
                        newDigitCreated = int.Parse(new string(new char[] { numberGenerator[0], numberGenerator[1] }));
                    }
                    else
                    {
                        newDigitCreated = int.Parse(new string(numberGenerator));
                    }

                    allCoordinates.Add(new int[2, 2] { { firstCoordinateSet[0], firstCoordinateSet[1] }, { xCoordinate, newDigitCreated } });

                    xCoordinate = 0;
                    numberGenerator = new char[] { 'i', 'i', 'i' };
                }
            }

            line = reader.ReadLine();
        }

        for (int i = 0; i < allCoordinates.Count; i++)
        {
            //if x is the same, look at y
            if (allCoordinates[i][0, 0] == allCoordinates[i][1, 0])
            {
                //use the .count() method for a list
                if (allCoordinates[i][0, 1] > allCoordinates[i][1, 1])
                {
                    for (int j = allCoordinates[i][1, 1]; j <= allCoordinates[i][0, 1]; j++)
                    {
                        dangerousCoordinates.Add(new int[] { allCoordinates[i][0, 0], j });
                    }
                }
                else
                {
                    for (int j = allCoordinates[i][0, 1]; j <= allCoordinates[i][1, 1]; j++)
                    {
                        dangerousCoordinates.Add(new int[] { allCoordinates[i][0, 0], j });
                    }
                }
                continue;
            }

            //if y is the same
            if (allCoordinates[i][0, 1] == allCoordinates[i][1, 1])
            {
                if (allCoordinates[i][0, 0] > allCoordinates[i][1, 0])
                {
                    for (int j = allCoordinates[i][1, 0]; j <= allCoordinates[i][0, 0]; j++)
                    {
                        dangerousCoordinates.Add(new int[] { j, allCoordinates[i][0, 1] });
                    }
                }
                else
                {
                    for (int j = allCoordinates[i][0, 0]; j <= allCoordinates[i][1, 0]; j++)
                    {
                        dangerousCoordinates.Add(new int[] { j, allCoordinates[i][0, 1] });
                    }
                }

                continue;
            }

            int numberOfCoordinatesBetween = Mathf.Abs(allCoordinates[i][0, 0] - allCoordinates[i][1, 0]);

            for(int j = 0; j <= numberOfCoordinatesBetween; j++)
            {
                if ((allCoordinates[i][1, 0] > allCoordinates[i][0, 0]))
                {
                    if (allCoordinates[i][0, 1] > allCoordinates[i][1, 1])
                        dangerousCoordinates.Add(new int[] { allCoordinates[i][0, 0] + j, allCoordinates[i][0, 1] - j });

                    else
                        dangerousCoordinates.Add(new int[] { allCoordinates[i][0, 0] + j, allCoordinates[i][0, 1] + j });
                }
                if ((allCoordinates[i][1, 0] < allCoordinates[i][0, 0]))
                {
                    if (allCoordinates[i][0, 1] > allCoordinates[i][1, 1])
                        dangerousCoordinates.Add(new int[] { allCoordinates[i][1, 0] + j, allCoordinates[i][1, 1] + j });
                    else
                        dangerousCoordinates.Add(new int[] { allCoordinates[i][1, 0] + j, allCoordinates[i][1, 1] - j });
                }
            }
        }

        //now to check how many things appear multiple times

        HashSet<string> coordinateStrings = new HashSet<string>();
        HashSet<string> dupes = new HashSet<string>();

        Debug.Log(dangerousCoordinates.Count);
        for (int i = 0; i < dangerousCoordinates.Count; i++)
        {
            //because a hashset can't read two dimensional arrays
            string numberString = (dangerousCoordinates[i][0].ToString() + ", " + dangerousCoordinates[i][1].ToString());
            if (!coordinateStrings.Add(numberString))
            {
                dupes.Add(numberString);
            }
        }

        Debug.Log(dupes.Count);
    }
}
