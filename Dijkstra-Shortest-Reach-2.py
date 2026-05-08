#!/bin/python3
import sys
import os
import heapq

input = sys.stdin.readline


def shortestReach(n, adj, s):
    INF = 10**18
    dist = [INF] * (n + 1)

    dist[s] = 0
    pq = [(0, s)]

    while pq:
        d, node = heapq.heappop(pq)

        if d != dist[node]:
            continue

        for next_node, w in adj[node].items():
            nd = d + w
            if dist[next_node] > nd:
                dist[next_node] = nd
                heapq.heappush(pq, (nd, next_node))

    result = []
    for i in range(1, n + 1):
        if i == s:
            continue
        result.append(-1 if dist[i] == INF else dist[i])

    return result

