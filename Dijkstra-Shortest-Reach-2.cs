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
        
    }    
}
