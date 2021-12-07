using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day6Part1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //This is the text file with the information
        string path = "Assets/Resources/Day6Input.txt";

        //I'm going to read it with a streamreader. This way I don't have to
        //copy paste everything here.
        System.IO.StreamReader reader = new System.IO.StreamReader(path);

        //I read the line with the streamreader
        string line = reader.ReadLine();

        List<int> lanternFish = new List<int>();

        while(line != null)
        {
            char[] characterArray = line.ToCharArray();

            for(int i = 0; i < characterArray.Length; i++)
            {
                if (char.IsDigit(characterArray[i]))
                {
                    int newDigit = characterArray[i] - '0';
                    lanternFish.Add(newDigit);
                }
            }

            line = reader.ReadLine();
        }

        //part 1

        //for(int i = 0; i < 256; i++)
        //{
        //    for (int k = lanternFish.Count - 1; k >= 0; k--)
        //    {
        //        if(lanternFish[k] == 0)
        //        {
        //            lanternFish[k] = 6;
        //            lanternFish.Add(8);
        //        }
        //        else
        //        {
        //            lanternFish[k] -= 1;
        //        }
        //    }
        //}
    }
}
