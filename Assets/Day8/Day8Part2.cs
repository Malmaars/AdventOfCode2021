using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Day8Part2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //This is the text file with the information
        string path = "Assets/Resources/Day8Input.txt";

        //I'm going to read it with a streamreader. This way I don't have to
        //copy paste everything here.
        System.IO.StreamReader reader = new System.IO.StreamReader(path);

        //I read the line with the streamreader
        string line = reader.ReadLine();

        int answer = 0;

        while(line != null)
        {
            //how can we determine each light position?

            //the top we can see if we compare 1 to 7

            //using this info we can compare 6 to 7 (- top light) to find right top light
            //we check the combos with 6 lights that don't have one of the two remaining lights (0 and 9 do, 6 doesn't)

            //With this we can also determine the last light from 7, which is the lower right light

            //0, 6, 9 and 4 (if we ignore the lights we already know), only have the upper left light in common

            //find the middle light by looking at 4

            //do we even need to know the bottom one? NO WE DONT

            //What about the lower left. WE ALSO DONT NEED THAT ONE FUCK THAT ONE

            //Now the most simple ways to find numbers per number:
            //0 - has 6 lights, c is on, d is off
            //1 - has 2 lights
            //2 - has 5 lights, c is on, f is off
            //3 - has 5 lights, c & f are both on
            //4 - has 4 lights
            //5 - has 5 lights, c is off, f is on
            //6 - has 6 lights, c is off, d is on
            //7 - has 3 lights
            //8 - has 7 lights
            //9 - has 6 lights, c is on, d is on

            char[][] Digits = new char[10][];

            char[] lineCharacters = line.ToCharArray();

            List<char> currentNumber = new List<char>();
            int currentDigit = 0;
            bool SecondPart = false;
            char[] lights = new char[5];

            for (int i = 0; i < lineCharacters.Length; i++)
            {
                //this shows all the light thingies, we only need 5 tho. 0 is a, 1 is b, 2 is c, 3 is d & 4 is f

                if (lineCharacters[i] != ' ' && lineCharacters[i] != '|')
                {
                    //then it's a letter
                    currentNumber.Add(lineCharacters[i]);
                }

                if ((lineCharacters[i] == ' ' && currentNumber.Count != 0) || i == lineCharacters.Length - 1)
                {
                    Digits[currentDigit] = currentNumber.ToArray();
                    currentDigit++;
                    currentNumber = new List<char>();
                }

                if (!SecondPart)
                {
                    if (lineCharacters[i] == '|')
                    {
                        char[] one = null;
                        char[] four = null;
                        char[] seven = null;

                        char[][] zeroSixNine = new char[3][];
                        char[][] twoThreeFive = new char[3][];

                        int sixCounter = 0;
                        int fiveCounter = 0;

                        //calculate the numbers and fill in the answers.
                        foreach (char[] array in Digits)
                        {
                            switch (array.Length)
                            {
                                case 2:
                                    one = array;
                                    break;

                                case 3:
                                    seven = array;
                                    break;

                                case 4:
                                    four = array;
                                    break;

                                case 5:
                                    twoThreeFive[fiveCounter] = array;
                                    fiveCounter++;
                                    break;

                                case 6:
                                    zeroSixNine[sixCounter] = array;
                                    sixCounter++;
                                    break;
                            }
                        }

                        //find a
                        foreach (char pos in seven)
                        {
                            if (Array.IndexOf(one, pos) == -1)
                            {
                                lights[0] = pos;
                            }
                        }

                        //find c
                        foreach (char[] charArray in zeroSixNine)
                        {
                            foreach (char pos in seven)
                            {
                                if (Array.IndexOf(charArray, pos) == -1)
                                    lights[2] = pos;
                            }
                        }

                        //find f
                        foreach (char pos in seven)
                        {
                            if (Array.IndexOf(lights, pos) == -1)
                                lights[4] = pos;
                        }

                        //find b
                        foreach (char pos in four)
                        {
                            int numberOfTimes = 0;
                            foreach (char[] array in zeroSixNine)
                            {
                                if (Array.IndexOf(array, pos) != -1 && pos != lights[4])
                                    numberOfTimes++;
                            }

                            if (numberOfTimes == 3)
                            {
                                lights[1] = pos;
                            }
                        }

                        //find d
                        foreach (char pos in four)
                        {
                            if (Array.IndexOf(lights, pos) == -1)
                                lights[3] = pos;
                        }

                        Digits = new char[4][];
                        currentDigit = 0;
                        SecondPart = true;
                    }
                }

                else if(currentDigit == 4)
                {
                    //calculate the final digits
                    int finalDigit = 0;

                    //first * 1000, second * 100, third * 10, fourth * 1
                    int[] fourDigits = new int[4];

                    for (int k = 0; k < Digits.Length; k++)
                    {
                        if (Digits[k].Length == 2)
                            fourDigits[k] = 1;

                        if (Digits[k].Length == 3)
                            fourDigits[k] = 7;

                        if (Digits[k].Length == 4)
                            fourDigits[k] = 4;

                        if (Digits[k].Length == 5)
                        {
                            if(Array.IndexOf(Digits[k], lights[2]) != -1 && Array.IndexOf(Digits[k], lights[4]) != -1)
                            {
                                fourDigits[k] = 3;
                            }

                            if (Array.IndexOf(Digits[k], lights[2]) == -1 && Array.IndexOf(Digits[k], lights[4]) != -1)
                            {
                                fourDigits[k] = 5;
                            }

                            if (Array.IndexOf(Digits[k], lights[2]) != -1 && Array.IndexOf(Digits[k], lights[4]) == -1)
                            {
                                fourDigits[k] = 2;
                            }
                        }

                        if (Digits[k].Length == 6)
                        {
                            if (Array.IndexOf(Digits[k], lights[2]) != -1 && Array.IndexOf(Digits[k], lights[3]) != -1)
                            {
                                fourDigits[k] = 9;
                            }

                            if (Array.IndexOf(Digits[k], lights[2]) == -1 && Array.IndexOf(Digits[k], lights[3]) != -1)
                            {
                                fourDigits[k] = 6;
                            }

                            if (Array.IndexOf(Digits[k], lights[2]) != -1 && Array.IndexOf(Digits[k], lights[3]) == -1)
                            {
                                fourDigits[k] = 0;
                            }
                        }

                        if (Digits[k].Length == 7)
                            fourDigits[k] = 8;
                    }

                    finalDigit = fourDigits[0] * 1000 + fourDigits[1] * 100 + fourDigits[2] * 10 + fourDigits[3];
                    Debug.Log("adding once");
                    answer += finalDigit;
                }
            }

            line = reader.ReadLine();
        }

        Debug.Log(answer);
    }
}
