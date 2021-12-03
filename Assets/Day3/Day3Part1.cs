using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day3Part1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //This is the text file with the information
        string path = "Assets/Resources/Day3Input.txt";

        //I'm going to read it with a streamreader. This way I don't have to
        //copy paste everything here.
        System.IO.StreamReader reader = new System.IO.StreamReader(path);

        //I read the line with the streamreader

        int[] numberOffset = new int[12];
       
        string line = reader.ReadLine();
        while (line != null)
        {
            for (int i = 0; i < 12; i++)
            {
                int number = line[i];
                //Debug.Log(number);
                //char[] characters = line.ToCharArray();
                //int.TryParse(characters[i].ToString(), out number);

                if (number == 48)
                {
                    numberOffset[i] -= 1;
                    //Debug.Log("-1");
                }
                else if (number == 49)
                {
                    numberOffset[i] += 1;
                    //Debug.Log("+1");
                }

            }
            line = reader.ReadLine();
        }

        for (int i = 0; i < 12; i++)
        {
            if (numberOffset[i] == 0)
            {
                Debug.Log("Help");
            }

            if(numberOffset[i] < 0)
            {
                numberOffset[i] = 0;
            }
            else
            {
                numberOffset[i] = 1;
            }
        }
        //gamma is 1491
        //epsilon is 2604
        Debug.Log(numberOffset[0] + " " + numberOffset[1] + " " + numberOffset[2] + " " + numberOffset[3] + " " + numberOffset[4] + " " + numberOffset[5] + " " + numberOffset[6] + " " + numberOffset[7] + " " + numberOffset[8] + " " + numberOffset[9] + " " + numberOffset[10] + " " + numberOffset[11]);
    }
}
