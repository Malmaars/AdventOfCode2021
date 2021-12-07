using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day7Part2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //This is the text file with the information
        string path = "Assets/Resources/Day7Input.txt";

        //I'm going to read it with a streamreader. This way I don't have to
        //copy paste everything here.
        System.IO.StreamReader reader = new System.IO.StreamReader(path);

        //I read the line with the streamreader
        string line = reader.ReadLine();

        int[] allPositions = new int[1000];

        char[] lineCharacters = line.ToCharArray();
        char[] smallNumberMaker = new char[] { 'i', 'i', 'i', 'i' };

        int currentArrayNumber = 0;
        int biggestNumber = 0;
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
                int thisNumber = 0;
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

                allPositions[currentArrayNumber] = thisNumber;
                if (thisNumber > biggestNumber)
                    biggestNumber = thisNumber;

                currentArrayNumber++;

                //reset smallnumbermaker and continue
                smallNumberMaker = new char[] { 'i', 'i', 'i', 'i' };
            }
        }


        int shortestPos = int.MaxValue;
        int totalDistance = int.MaxValue;

        //ik moet hier gwn een formule van maken: ( 1 = 1, 2 = 3, 3 = 6, 4 = 10)
        // n(n+1) / 2

        for (int i = 0; i <= biggestNumber; i++)
        {
            int thisDistance = 0;
            for (int k = 0; k < allPositions.Length; k++)
            {
                int positionDistance = Mathf.Abs(allPositions[k] - i);
                thisDistance += (positionDistance * (positionDistance + 1)) / 2;
            }

            if (thisDistance < totalDistance)
            {
                totalDistance = thisDistance;
                shortestPos = i;
            }
        }

        Debug.Log(totalDistance);
        Debug.Log(shortestPos);
    }
}
