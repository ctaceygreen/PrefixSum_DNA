using System;
// you can also use other imports, for example:
// using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

class Solution
{
    public int[] solution(string S, int[] P, int[] Q)
    {
        // write your code in C# 6.0 with .NET 4.5 (Mono)
        int[][] prefixSums = new int[S.Length][];
        int[] result = new int[P.Length];

        for(int i = 0; i < S.Length; i++)
        {
            prefixSums[i] = new int[4];
            var character = S[i];
            if(character == 'A') { prefixSums[i][0] = 1; }
            if (character == 'C') { prefixSums[i][1] = 1; }
            if (character == 'G') { prefixSums[i][2] = 1; }
            if (character == 'T') { prefixSums[i][3] = 1; }
        }

        //Create prefixes array sums
        for(int i = 1; i < S.Length; i++)
        {
            for(int j = 0; j < 4; j++)
            {
                prefixSums[i][j] += prefixSums[i - 1][j];
            }
        }

        for(int pIndex=0; pIndex < P.Length; pIndex++)
        {
            int startIndex = P[pIndex];
            int endIndex = Q[pIndex];

            for(int character = 0; character < 4; character++)
            {
                int minusCum = 0;
                if(startIndex - 1 >=0)
                {
                    minusCum = prefixSums[startIndex - 1][character];
                }
                if(prefixSums[endIndex][character] - minusCum > 0)
                {
                    result[pIndex] = character + 1;
                    break;
                }
            }
        }

        return result;
    }
}