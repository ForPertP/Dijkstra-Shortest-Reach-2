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

    public static List<Integer> shortestReach(int n, List<int[]>[] adj, int s) {

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

        List<Integer> result = new ArrayList<>();
        for (int i = 1; i <= n; i++) {
            if (i == s) continue;
            result.add(dist[i] == Integer.MAX_VALUE ? -1 : dist[i]);
        }

        return result;
    }
}


public class Solution {
    public static void main(String[] args) throws IOException {

        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        BufferedWriter bw = new BufferedWriter(new OutputStreamWriter(System.out));

        int t = Integer.parseInt(br.readLine());

        while (t-- > 0) {

            StringTokenizer st = new StringTokenizer(br.readLine());
            int n = Integer.parseInt(st.nextToken());
            int m = Integer.parseInt(st.nextToken());

            List<int[]>[] adj = (List<int[]>[]) new ArrayList[n + 1];
            
            for (int i = 1; i <= n; i++) adj[i] = new ArrayList<>();

            for (int i = 0; i < m; i++) {
                st = new StringTokenizer(br.readLine());
                int u = Integer.parseInt(st.nextToken());
                int v = Integer.parseInt(st.nextToken());
                int w = Integer.parseInt(st.nextToken());

                adj[u].add(new int[]{v, w});
                adj[v].add(new int[]{u, w});
            }

            int s = Integer.parseInt(br.readLine());

            List<Integer> result = Result.shortestReach(n, adj, s);

            StringBuilder sb = new StringBuilder();
            for (int val : result) {
                sb.append(val).append(" ");
            }
            bw.write(sb.toString().trim());
            bw.newLine();
        }

        bw.flush();
    }
}
