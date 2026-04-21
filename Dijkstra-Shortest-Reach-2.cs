using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'shortestReach' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. 2D_INTEGER_ARRAY edges
     *  3. INTEGER s
     */

    public static List<int> shortestReach(int n, List<List<int>> edges, int s)
    {
        var adjacencyList = new List<(int node, int weight)>[n + 1];
        for (int i = 0; i <= n; i++)
            adjacencyList[i] = new List<(int, int)>();

        foreach (var edge in edges)
        {
            int u = edge[0];
            int v = edge[1];
            int w = edge[2];

            adjacencyList[u].Add((v, w));
            adjacencyList[v].Add((u, w));
        }

        var distance = new int[n + 1];
        for (int i = 0; i <= n; i++)
            distance[i] = int.MaxValue;

        var pq = new PriorityQueue<(int node, int dist), int>();

        distance[s] = 0;
        pq.Enqueue((s, 0), 0);

        while (pq.Count > 0)
        {
            var current = pq.Dequeue();
            int currentNode = current.node;
            int currentDist = current.dist;

            if (currentDist > distance[currentNode]) continue;

            foreach (var (nextNode, weight) in adjacencyList[currentNode])
            {
                if (distance[nextNode] > distance[currentNode] + weight)
                {
                    distance[nextNode] = distance[currentNode] + weight;
                    pq.Enqueue((nextNode, distance[nextNode]), distance[nextNode]);
                }
            }
        }

        var result = new List<int>();

        for (int i = 1; i <= n; i++)
        {
            if (i == s) continue;
            result.Add(distance[i] == int.MaxValue ? -1 : distance[i]);
        }

        return result;
    }
}


class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int t = Convert.ToInt32(Console.ReadLine().Trim());

        for (int tItr = 0; tItr < t; tItr++)
        {
            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int n = Convert.ToInt32(firstMultipleInput[0]);

            int m = Convert.ToInt32(firstMultipleInput[1]);

            List<List<int>> edges = new List<List<int>>();

            for (int i = 0; i < m; i++)
            {
                edges.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(edgesTemp => Convert.ToInt32(edgesTemp)).ToList());
            }

            int s = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> result = Result.shortestReach(n, edges, s);

            textWriter.WriteLine(String.Join(" ", result));
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
