using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day14Part2 : MonoBehaviour
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
        line = reader.ReadLine();
        line = reader.ReadLine();

        //I could make a dictionary of combinations so I can track which combinations are present per runthrough
        //So I could transition the polymer to new combinations. if NH -> C then NH = NC & CH
        Dictionary<string, long> polymerOptions = new Dictionary<string, long>();
        Dictionary<string, long> polymerDifferences = new Dictionary<string, long>();
        HashSet<char> polymerCharacters = new HashSet<char>();

        char[] lineCharacter;

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

        foreach(char element in polymerCharacters)
        {
           foreach(char secondElement in polymerCharacters)
            {
                polymerOptions.Add(new string(new char[] { element, secondElement}), 0);
                polymerDifferences.Add(new string(new char[] { element, secondElement }), 0);
            }
        }
        //Now all options are inside the dictionary

        reader = new System.IO.StreamReader(path);
        line = reader.ReadLine();
        //now to add the combinations of the first line

        lineCharacter = line.ToCharArray();
        for(int i = 0; i < lineCharacter.Length - 1; i++)
        {
            string currentPolymerCombination = new string(new char[] { lineCharacter[i], lineCharacter[i + 1] });
            //Debug.Log(currentPolymerCombination);
            polymerOptions[currentPolymerCombination] += 1;
        }

        long totalTest = 0;

        for (int i = 0; i < 40; i++)
        {
            //check each option in the dictionary and transition it.
            //The number we check will always be set to zero.
            foreach (char[] possibilities in polyRules)
            {
                string theOneWeSearchFor = new string(new char[] { possibilities[0], possibilities[1] });
                polymerDifferences[theOneWeSearchFor] = 0;
            }

            foreach (char[] possibilities in polyRules)
            {
                
                string theOneWeSearchFor = new string(new char[] { possibilities[0], possibilities[1] });
                string newCombo1 = new string(new char[] { possibilities[0], possibilities[2] });
                string newCombo2 = new string(new char[] { possibilities[2], possibilities[1] });

                //Debug.Log(polymerOptions[theOneWeSearchFor]);
                long elementAmount = polymerOptions[theOneWeSearchFor];
                polymerDifferences[newCombo1] += elementAmount;
                polymerDifferences[newCombo2] += elementAmount;
                polymerDifferences[theOneWeSearchFor] -= elementAmount;
            }

            totalTest = 0;

            foreach (char[] possibilities in polyRules)
            {
                string theOneWeSearchFor = new string(new char[] { possibilities[0], possibilities[1] });

                polymerOptions[theOneWeSearchFor] += polymerDifferences[theOneWeSearchFor];
                totalTest += polymerOptions[theOneWeSearchFor];
                //Debug.Log(possibilities[0] + " " + possibilities[1] + " " + possibilities[2]);
            }
        }

        //total combinations + 1
        Debug.Log(totalTest);
        

        long highestNumber = 0;
        long lowestNumber = long.MaxValue;

        long total = 0;
        foreach(char element in polymerCharacters)
        {
            long number = 0;
            foreach (char[] elementArray in polyRules)
            {
                if (elementArray[0] == element || elementArray[1] == element)
                {
                    string theOneWeSearchFor = new string(new char[] { elementArray[0], elementArray[1] });

                    if (elementArray[0] == element && elementArray[1] == element)
                    {
                        number += polymerOptions[theOneWeSearchFor] * 2;
                        total += polymerOptions[theOneWeSearchFor] * 2;
                    }

                    else
                    {
                        number += polymerOptions[theOneWeSearchFor];
                        total += polymerOptions[theOneWeSearchFor];
                    }
                }
            }

            //if(number%2 != 0)
            //{
            //    Debug. Log("THIS SHOULDNT BE POSSIBLE");
            //}

            number /= 2;
            if (element == 'C' || element == 'B')
                number++;

            if (element == 'H')
                Debug.Log(number);

            if (number > highestNumber)
                highestNumber = number;

            if (number < lowestNumber)
                lowestNumber = number;
        }

        Debug.Log(highestNumber - lowestNumber);

    }
}
