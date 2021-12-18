using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day14Part1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //This is the text file with the information
        string path = "Assets/Resources/Day14Input.txt";

        //I'm going to read it with a streamreader. This way I don't have to
        //copy paste everything here.
        System.IO.StreamReader reader = new System.IO.StreamReader(path);

        //I read the line with the streamreader
        string line = reader.ReadLine();

        List<char> polymer = new List<char>();
        HashSet<char> polymerCharacters = new HashSet<char>();

        char[] lineCharacter = line.ToCharArray();

        for (int i = 0; i < lineCharacter.Length; i++)
        {
            polymer.Add(lineCharacter[i]);
            polymerCharacters.Add(lineCharacter[i]);
        }

        line = reader.ReadLine();
        line = reader.ReadLine();

        //each entry has 3 characters, the first two are the one the third character goes in between
        char[][] polyRules = new char[100][];
        int ruleIndex = 0;
        while (line != null)
        {
            lineCharacter = line.ToCharArray();
            int charIndex = 0;
            polyRules[ruleIndex] = new char[3];
            for (int i = 0; i < lineCharacter.Length; i++)
            {
                if (char.IsLetter(lineCharacter[i]))
                {
                    polyRules[ruleIndex][charIndex] = lineCharacter[i];
                    polymerCharacters.Add(lineCharacter[i]);
                    charIndex++;
                }
            }
            ruleIndex++;
            line = reader.ReadLine();
        }


        for(int i = 0; i < 10; i++)
        {
            for(int k = 0; k < polymer.Count - 1; k++)
            {
                for(int p = 0; p < polyRules.Length; p++)
                {
                    if(polymer[k] == polyRules[p][0] && polymer[k+1] == polyRules[p][1])
                    {
                        polymer.Insert(k + 1, polyRules[p][2]);
                        k++;
                        break;
                    }
                }
            }
        }

        int highestNumber = 0;
        int lowestNumber = int.MaxValue;

        foreach(char character in polymerCharacters)
        {
            int numberOfCharacters = 0;
            for(int i = 0; i < polymer.Count; i++)
            {
                if(character == polymer[i])
                {
                    numberOfCharacters++;
                }
            }

            if (numberOfCharacters > highestNumber)
                highestNumber = numberOfCharacters;

            if (numberOfCharacters < lowestNumber)
                lowestNumber = numberOfCharacters;
        }

        Debug.Log(highestNumber - lowestNumber);
    }
}
