'use strict';

import { WriteStream, createWriteStream } from "fs";

process.stdin.resume();
process.stdin.setEncoding('utf-8');

let inputString: string = '';
let currentLine: number = 0;
let inputLines: string[] = [];

process.stdin.on('data', function(inputStdin: string): void {
    inputString += inputStdin;
});

process.stdin.on('end', function(): void {
    inputLines = inputString.split(/\s+/);
    inputString = ''; 
    main();
});

function readInt(): number {
    return parseInt(inputLines[currentLine++], 10);
}

class PriorityQueue {
    private heap: number[][] = [];
    constructor() {}

    push(val: number[]) {
        this.heap.push(val);
        let idx = this.heap.length - 1;
        while (idx > 0) {
            let pIdx = (idx - 1) >> 1;
            if (this.heap[idx][1] >= this.heap[pIdx][1]) break;
            [this.heap[idx], this.heap[pIdx]] = [this.heap[pIdx], this.heap[idx]];
            idx = pIdx;
        }
    }

    pop(): number[] | undefined {
        if (this.heap.length === 0) return undefined;
        const top = this.heap[0];
        const last = this.heap.pop()!;
        if (this.heap.length > 0) {
            this.heap[0] = last;
            let idx = 0;
            while (true) {
                let left = (idx << 1) + 1;
                let right = (idx << 1) + 2;
                let smallest = idx;
                if (left < this.heap.length && this.heap[left][1] < this.heap[smallest][1]) smallest = left;
                if (right < this.heap.length && this.heap[right][1] < this.heap[smallest][1]) smallest = right;
                if (smallest === idx) break;
                [this.heap[idx], this.heap[smallest]] = [this.heap[smallest], this.heap[idx]];
                idx = smallest;
            }
        }
        return top;
    }

    isEmpty() { return this.heap.length === 0; }
}

function shortestReach(n: number, m: number): number[] {
    const adj: Map<number, number>[] = Array.from({ length: n + 1 }, () => new Map());

    for (let i = 0; i < m; i++) {
        const u = readInt();
        const v = readInt();
        const w = readInt();
        if ((adj[u].get(v) || Infinity) > w) {
            adj[u].set(v, w);
            adj[v].set(u, w);
        }
    }

  
    }

    const result: number[] = [];
    for (let i = 1; i <= n; i++) {
        if (i === s) continue;
        result.push(minDists[i] === 4294967295 ? -1 : minDists[i]);
    }
    return result;
}

function main() {
    const ws: WriteStream = createWriteStream(process.env['OUTPUT_PATH']!);
    const t = readInt();

    for (let tItr = 0; tItr < t; tItr++) {
        const n = readInt();
        const m = readInt();
        const result = shortestReach(n, m);
        ws.write(result.join(' ') + '\n');
    }
    ws.end();
}
