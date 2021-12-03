using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Day3Part2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        calculateOxygen();
        calculateO2();

    }

    void calculateOxygen()
    {
        //This is the text file with the information
        string path = "Assets/Resources/Day3Input.txt";

        //I'm going to read it with a streamreader. This way I don't have to
        //copy paste everything here.
        System.IO.Stream s = new System.IO.MemoryStream();
        System.IO.StreamReader reader = new System.IO.StreamReader(path);


        //I read the line with the streamreader
        string line = reader.ReadLine();

        List<int[]> intListArray = new List<int[]>();
        int j = 0;
        while (line != null)
        {
            //int number = line[i];
            //Debug.Log(number);
            char[] characters = line.ToCharArray();
            //int.TryParse(characters[i].ToString(), out number);
            int[] tempArray = new int[12];
            for (int i = 0; i < 12; i++)
            {
                int.TryParse(characters[i].ToString(), out tempArray[i]);
            }
            intListArray.Add(tempArray);

            j++;
            line = reader.ReadLine();

        }

        for (int i = 0; i < 12; i++)
        {
            int numberOffSet = 0;
            for (int k = 0; k < intListArray.Count; k++)
            {
                int[] currentArray = intListArray[k];
                if (currentArray[i] == 0)
                {
                    numberOffSet -= 1;
                }
                else
                {
                    numberOffSet += 1;
                }
            }

            int biggestNumber;

            if (numberOffSet >= 0)
            {
                biggestNumber = 1;
            }
            else biggestNumber = 0;

            for (int k = 0; k < intListArray.Count; k++)
            {
                int[] currentArray = intListArray[k];
                if (currentArray[i] != biggestNumber)
                {
                    intListArray.Remove(intListArray[k]);
                    k -= 1;
                    continue;
                }
            }
        }
        int[] currentArray2 = intListArray[0];

        //1305
        Debug.Log(currentArray2[0] + "" + currentArray2[1] + "" + currentArray2[2] + "" + currentArray2[3] + "" + currentArray2[4] + "" + currentArray2[5] + "" + currentArray2[6] + "" + currentArray2[7] + "" + currentArray2[8] + "" + currentArray2[9] + "" + currentArray2[10] + "" + currentArray2[11]);
    }

    void calculateO2()
    {
        //This is the text file with the information
        string path = "Assets/Resources/Day3Input.txt";

        //I'm going to read it with a streamreader. This way I don't have to
        //copy paste everything here.
        //System.IO.Stream s = new System.IO.MemoryStream();
        System.IO.StreamReader reader = new System.IO.StreamReader(path);


        //I read the line with the streamreader
        string line = reader.ReadLine();

        List<int[]> intListArray = new List<int[]>();
        int j = 0;
        while (line != null)
        {
            //int number = line[i];
            //Debug.Log(number);
            char[] characters = line.ToCharArray();
            //int.TryParse(characters[i].ToString(), out number);
            int[] tempArray = new int[12];
            for (int i = 0; i < 12; i++)
            {
                int.TryParse(characters[i].ToString(), out tempArray[i]);
            }
            intListArray.Add(tempArray);

            j++;
            line = reader.ReadLine();

        }

        //Debug.Log(intListArray.Count);
        for (int i = 0; i < 12; i++)
        {
            int numberOffSet = 0;
            for (int k = 0; k < intListArray.Count; k++)
            {
                int[] currentArray = intListArray[k];
                if (currentArray[i] == 0)
                {
                    numberOffSet -= 1;
                }
                else
                {
                    numberOffSet += 1;
                }
            }

            int biggestNumber;

            if (numberOffSet < 0)
            {
                biggestNumber = 0;
            }
            else biggestNumber = 1;

           // Debug.Log(biggestNumber);
            for (int k = 0; k < intListArray.Count; k++)
            {
                int[] currentArray = intListArray[k];
                if (currentArray[i] == biggestNumber && intListArray.Count != 1)
                {
                    intListArray.Remove(intListArray[k]);
                    k -= 1;
                    continue;
                }
            }
        }

        int[] currentArray2 = intListArray[0];
        //2594
        Debug.Log(currentArray2[0] + "" + currentArray2[1] + "" + currentArray2[2] + "" + currentArray2[3] + "" + currentArray2[4] + "" + currentArray2[5] + "" + currentArray2[6] + "" + currentArray2[7] + "" + currentArray2[8] + "" + currentArray2[9] + "" + currentArray2[10] + "" + currentArray2[11]);
    }
}
