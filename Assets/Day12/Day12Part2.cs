using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Day12Part2 : MonoBehaviour
{
    List<cave> allCavesAsCaves = new List<cave>();

    Dictionary<string, int> caveIndexes = new Dictionary<string, int>();

    HashSet<List<cave>> possibleRoutes = new HashSet<List<cave>>();

    long totalRoutes = 0;
    // Start is called before the first frame update
    void Start()
    {
        //I can have multiple lists or arrays for each of the caves
        //A variable for its name, a list of strings for possible routes, a variable for if it's small or not, and a variable for if it's been visited earlier.
        //And then I need a way to check each possible route.

        //This is the text file with the information
        string path = "Assets/Resources/Day12Input.txt";

        //I'm going to read it with a streamreader. This way I don't have to
        //copy paste everything here.
        System.IO.StreamReader reader = new System.IO.StreamReader(path);

        //I read the line with the streamreader
        string line = reader.ReadLine();

        HashSet<string> allCaves = new HashSet<string>();

        int indexCave = 0;
        while (line != null)
        {
            char[] lineCharacters = line.ToCharArray();

            List<char> caveName = new List<char>();
            for (int i = 0; i < lineCharacters.Length; i++)
            {
                if (lineCharacters[i] == '-')
                {
                    string temp = new string(caveName.ToArray());
                    allCaves.Add(temp);

                    if (!caveIndexes.ContainsKey(temp))
                    {
                        caveIndexes.Add(temp, indexCave);
                        indexCave++;
                    }
                    break;
                }
                else
                {
                    caveName.Add(lineCharacters[i]);
                }
            }

            line = reader.ReadLine();
        }

        foreach (string caveThing in allCaves)
        {
            reader = new System.IO.StreamReader(path);
            line = reader.ReadLine();
            HashSet<string> allConnections = new HashSet<string>();

            while (line != null)
            {
                char[] lineCharacters = line.ToCharArray();

                List<char> caveName = new List<char>();
                for (int i = 0; i < lineCharacters.Length; i++)
                {
                    if (lineCharacters[i] == '-')
                    {
                        if (caveThing == new string(caveName.ToArray()))
                        {
                            caveName = new List<char>();
                        }

                        else
                            break;
                    }

                    else
                    {
                        caveName.Add(lineCharacters[i]);
                    }

                    if (i == lineCharacters.Length - 1)
                    {
                        allConnections.Add(new string(caveName.ToArray()));
                    }
                }
                line = reader.ReadLine();
            }

            bool isItSmall = false;

            if (Char.IsLower(caveThing.ToCharArray()[0]))
            {
                isItSmall = true;
            }

            allCavesAsCaves.Add(new cave(caveThing, allConnections, isItSmall, false));
        }


        //Here I add all routes to each cave
        foreach (cave cavey in allCavesAsCaves)
        {
            foreach (string connection in cavey.Routes)
            {
                if (connection != cavey.Name)
                    allCavesAsCaves[caveIndexes[connection]].Routes.Add(cavey.Name);
            }
        }

        //now I have info per cave

        foreach (string currentConnection in allCavesAsCaves[caveIndexes["start"]].Routes)
        {
            foreach (cave caves in allCavesAsCaves)
            {
                caves.Visited = false;
            }
            //Everything has to start at start
            List<cave> newRoute = new List<cave>();
            CheckNextCave(allCavesAsCaves[caveIndexes[currentConnection]], newRoute, false);

        }

        Debug.Log(totalRoutes);
    }

    public void CheckNextCave(cave currentCave, List<cave> caveRoute, bool firstSmallCave)
    {

        List<cave> newBranch = new List<cave>();
        foreach (cave dataConvert in caveRoute)
        {
            newBranch.Add(dataConvert);
        }

        newBranch.Add(currentCave);

        if (currentCave.Visited && !firstSmallCave)
            firstSmallCave = true;

        if (currentCave.Small)
            currentCave.Visited = true;

        foreach (string nextCave in currentCave.Routes)
        {
            if(nextCave == "end")
            {
                totalRoutes++;
                continue;
            }

            bool stop = false;
            cave newCave = null;
            foreach (cave caves in newBranch)
            {
                if (caves.Name == nextCave)
                {
                    for (int k = 0; k < newBranch.Count; k++)
                    {
                        if (newBranch[k].Name == nextCave)
                        {
                            newCave = newBranch[k];
                            stop = true;
                        }
                    }
                }
            }


            if (!stop)
            {
                newCave = new cave(allCavesAsCaves[caveIndexes[nextCave]].Name, allCavesAsCaves[caveIndexes[nextCave]].Routes, allCavesAsCaves[caveIndexes[nextCave]].Small, false);
                //make a new instance
            }

            if ((!newCave.Visited || !firstSmallCave) && newCave.Name != "start")
            {
                CheckNextCave(newCave, newBranch, firstSmallCave);
            }
        }
    }

    public class cave
    {
        public string Name { get; }
        public HashSet<string> Routes { get; set; }
        public bool Small { get; }
        public bool Visited;

        public cave(string name, HashSet<string> routes, bool small, bool visited)
        {
            Name = name;
            Routes = routes;
            Small = small;
            Visited = visited;
        }
    }
}
