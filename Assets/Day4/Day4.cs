using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day4 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        List<int[,]> intArraysList = new List<int[,]>();
        bool[,,] gotTheNumbers;
        int[] pullingNumbers = new int[100];
        string path = "Assets/Resources/Day4Input.txt";

        int[,] winningBoard;

        //I'm going to read it with a streamreader. This way I don't have to
        //copy paste everything here.
        System.IO.StreamReader reader = new System.IO.StreamReader(path);

        //I read the line with the streamreader
        string line = reader.ReadLine();
        char[] lineCharacters = line.ToCharArray();

        char[] smallNumberMaker = new char[] { 'i', 'i' };
        int pullingNumbersPos = 0;
        for (int i = 0; i < lineCharacters.Length; i++)
        {
            if (char.IsDigit(lineCharacters[i]))
            {
                if (smallNumberMaker[0] == 'i')
                {
                    smallNumberMaker[0] = lineCharacters[i];
                }
                else
                {
                    smallNumberMaker[1] = lineCharacters[i];
                }
            }

            if (lineCharacters[i] == ',' || i == lineCharacters.Length - 1)
            {
                //make the smallnumbermaker into a number and add it to the pullingnumbers array
                if (smallNumberMaker[1] == 'i')
                {
                    smallNumberMaker[1] = smallNumberMaker[0];
                    smallNumberMaker[0] = '0';
                }
                string numberString = new string(smallNumberMaker);
                pullingNumbers[pullingNumbersPos] = int.Parse(numberString);
                pullingNumbersPos++;

                //reset smallnumbermaker and continue
                smallNumberMaker = new char[] { 'i', 'i' };
            }
        }

        line = reader.ReadLine();

        int boardColumnNumber = 0;
        int[,] board = new int[5, 5];

        while (line != null)
        {
            if (line == "")
            {
                line = reader.ReadLine();
            }

            int boardRowNumber = 0;

            char[] characterArray = line.ToCharArray();

            char[] numberGenerator = new char[] { 'i', 'i' };
            for (int i = 0; i < characterArray.Length; i++)
            {
                if (char.IsDigit(characterArray[i]))
                {
                    if (numberGenerator[0] == 'i')
                    {
                        numberGenerator[0] = characterArray[i];
                    }
                    else
                    {
                        numberGenerator[1] = characterArray[i];
                    }
                }

                if ((characterArray[i] == ' ' && numberGenerator[0] != 'i') || i == characterArray.Length - 1)
                {
                    if (numberGenerator[1] == 'i')
                    {
                        board[boardColumnNumber, boardRowNumber] = numberGenerator[0] - '0';
                    }
                    else
                    {
                        string numberString = new string(numberGenerator);
                        board[boardColumnNumber, boardRowNumber] = int.Parse(numberString);
                    }

                    boardRowNumber++;
                    numberGenerator = new char[] { 'i', 'i' };
                }
            }

            if (boardColumnNumber < 4)
            {
                boardColumnNumber++;
            }
            else
            {
                intArraysList.Add(board);
                boardColumnNumber = 0;
                board = new int[5, 5];
            }
            line = reader.ReadLine();
        }
        Debug.Log(intArraysList[0][0, 0]);


        gotTheNumbers = new bool[intArraysList.Count, 5, 5];
        //now I have a list of the boards and the numbers who will be pulled

        //i is for the numbers we pull
        for (int i = 0; i < pullingNumbers.Length; i++)
        {
            //so we should only use i here.
            int currentNumber = pullingNumbers[i];

            //set all numbers that are the same to true

            //m is for the board number
            for (int m = 0; m < intArraysList.Count; m++)
            {
                //j is for the first dimension
                for (int j = 0; j < 5; j++)
                {
                    //k is for the second dimension
                    for (int k = 0; k < 5; k++)
                    {
                        if (intArraysList[m][j, k] == currentNumber)
                        {
                            gotTheNumbers[m, j, k] = true;
                        }
                    }
                }
            }

            
            //now to check if we got a complete row or column HOW??
            for(int p = 0; p < intArraysList.Count; p++)
            {
                //we're going through all the booleans fuck it

                //if one of these hits five, we found it.
                int rowCounter = 0;
                int columnCounter = 0;
                for(int r = 0; r < 5; r++)
                {
                    for (int q = 0; q < 5; q++)
                    {
                        if (gotTheNumbers[p, r, q])
                        {
                            rowCounter++;
                        }

                        if (gotTheNumbers[p, q, r])
                        {
                            columnCounter++;
                        }
                    }
                    if (rowCounter == 5 || columnCounter == 5)
                    {
                        break;
                    }

                    rowCounter = 0;
                    columnCounter = 0;
                }

                if(rowCounter == 5 || columnCounter == 5)
                {
                    winningBoard = intArraysList[p];
                    int totalPoints = 0;

                    //now to calculate the points
                    for(int r = 0; r < 5; r++)
                    {
                        for(int q = 0; q < 5; q++)
                        {
                            if (!gotTheNumbers[p, r, q])
                            {
                                totalPoints += winningBoard[r, q];
                            }
                        }
                    }

                    totalPoints *= currentNumber;
                    Debug.Log(totalPoints);

                    return;
                }
            }
        }
    }
}

