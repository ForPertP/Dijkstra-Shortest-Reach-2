import java.io.*;
import java.math.*;
import java.security.*;
import java.text.*;
import java.util.*;
import java.util.concurrent.*;
import java.util.function.*;
import java.util.regex.*;
import java.util.stream.*;
import static java.util.stream.Collectors.joining;
import static java.util.stream.Collectors.toList;

class Result {

    /*
     * Complete the 'shortestReach' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. 2D_INTEGER_ARRAY edges
     *  3. INTEGER s
     */

    public static List<Integer> shortestReach(int n, List<List<Integer>> edges, int s) {
        int[] dist = new int[n + 1];
        Arrays.fill(dist, Integer.MAX_VALUE);

        PriorityQueue<Long> pq = new PriorityQueue<>();

        dist[s] = 0;
        pq.offer(((long)0 << 32) | s);

        while (!pq.isEmpty()) {
            long cur = pq.poll();
            int d = (int)(cur >> 32);
            int node = (int)(cur & 0xffffffffL);

            if (d != dist[node]) continue;

            for (int[] next : adj[node]) {
                int nextNode = next[0];
                int newDist = d + next[1];

                if (dist[nextNode] > newDist) {
                    dist[nextNode] = newDist;
                    pq.offer(((long)newDist << 32) | nextNode);
                }
            }
        }
    }

}
