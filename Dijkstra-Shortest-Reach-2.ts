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
