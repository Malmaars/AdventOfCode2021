using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day6Part2 : MonoBehaviour
{
    long zeros, ones, twos, threes, fours, fives, sixes, sevens, eights;
    long totalFish;
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

        while(line != null)
        {
            char[] characterArray = line.ToCharArray();

            for (int i = 0; i < characterArray.Length; i++)
            {
                if (char.IsDigit(characterArray[i]))
                {
                    int newDigit = characterArray[i] - '0';

                    switch (newDigit)
                    {
                        case 1:
                            ones += 1;
                            break;

                        case 2:
                            twos += 1;
                            break;

                        case 3:
                            threes += 1;
                            break;

                        case 4:
                            fours += 1;
                            break;

                        case 5:
                            fives += 1;
                            break;
                    }
                }
            }

            line = reader.ReadLine();
        }

        for (int i = 0; i < 256; i++)
        {
            long temp = zeros;

            zeros = ones;
            ones = twos;
            twos = threes;
            threes = fours;
            fours = fives;
            fives = sixes;
            sixes = sevens + temp;
            sevens = eights;
            eights = temp;
        }

        totalFish = zeros + ones + twos + threes + fours + fives + sixes + sevens + eights;

        Debug.Log(totalFish);


        //part 2

        //initial count is 300
        //there are 83 1s, 51 2s, 56 3s, 60 4s and 50 5s
        //I guess I might have to make my own formula to this.

        //in 6 days, there will have been 300 added, making a total of 600, because every starting number has only had the chance to run once
        //Each fish has 7 days to reproduce at max, new fish take 9 days 

        //f(x) = g^x * b

        //x = 256 is the puzzle

        //f(80) = 351188
        //f(0) = 300

        //b = 300

        //f(x) = g^x * 300

        //f(80) = g^80 * 300 = 351188
        //g^80 = 351188/300
        //Debug.Log(Mathf.Pow(351188/300, 1 / 80)); this just returns 1 so Imma have to keep it like this

        //f(256) =
        //Debug.Log(Mathf.Pow(Mathf.Pow(351188 / 300, 1 / 80), 256) * 300);

        //5 * 8 = 40


        //I can divide 256 by 8, which might help. 80 as well   
    }
}
