Dijkstra-Shortest-Reach-2

#!/bin/python3
import sys
import os
import heapq

input = sys.stdin.readline

def shortestReach(n, adj, s):
    INF = 10**18
    dist = [INF] * (n + 1)
