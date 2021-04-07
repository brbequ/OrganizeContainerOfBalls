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

class Solution
{

    // Complete the organizingContainers function below.
    static string organizingContainers(int[][] container)
    {
        // Total in each container
        // Count of each type
        long[] total = new long[container.Length];
        long[] type = new long[container.Length];

        // Calculate totals for the containers (sum each row)
        for (int row = 0; row < container.Length; row++)
        {
            // Convert to long to prevent overflow
            total[row] = container[row].Sum(val => (long)val);
        }

        // Calculate total of each type (add up columns)  
        for (int col = 0; col < container.Length; col++)
        {
            type[col] = 0;
            for (int idx = 0; idx < container.Length; idx++)
            {
                type[col] += container[idx][col];
            }
        }

        // Sort the arrays and compare them
        Array.Sort(total);
        Array.Sort(type);
        if (total.SequenceEqual(type))
            return "Possible";
        
        return "Impossible";
    }

    static void Main(string[] args)
    {
        foreach(int[][] testcase in testcases)
        {
            string result = organizingContainers(testcase);

            Console.WriteLine(result);
        }

    }

    static List<int[][]> testcases = new List<int[][]>()
    {
        new int[2][] // Possible
        {
            new int[]{ 1, 1 },
            new int[]{ 1, 1 }
        },
        new int[2][] // Impossible
        {
            new int[]{ 0, 2 },
            new int[]{ 1, 1 }
        },
        new int[2][] // Possible
        {
            new int[]{ 999336263, 998799923 },
            new int[]{ 998799923, 999763019 }
        },
        new int[4][] // Possible
        {
            new int[]{997612619, 934920795, 998879231, 999926463 },
            new int[]{960369681, 997828120, 999792735, 979622676 },
            new int[]{999013654, 998634077, 997988323, 958769423 },
            new int[]{997409523, 999301350, 940952923, 993020546 }
        },
        new int[9][] // Possible
        {
            new int[]{ 993263231, 806455183, 972467746, 761846174, 226680660, 667393859, 815298761, 790313908, 997845516 },
            new int[]{ 873142072, 579210472, 996344520, 999601755, 904458846, 663577990, 980240637, 713052540, 963408591 },
            new int[]{ 551159221, 873763794, 752756532, 798803609, 670921889, 995259612, 981339960, 763904498, 499472207 },
            new int[]{ 975980611, 999974039, 729219884, 834636710, 973988213, 969888254, 846967495, 687204298, 511348404 },
            new int[]{ 993232608, 998103218, 857820670, 995587240, 817798750, 773950980, 824882180, 797565274, 887424441 },
            new int[]{ 847857578, 768853671, 916073200, 982234748, 986511977, 733420232, 997714976, 819799716, 891570083 },
            new int[]{ 733197334, 985682497, 612123868, 971798655, 999905357, 710092446, 997494889, 683312998, 850074746 },
            new int[]{ 799093993, 543648222, 944524289, 814951921, 981087922, 997222915, 506561779, 997697933, 652807674 },
            new int[]{ 989362549, 973516812, 891706714, 786904549, 982329176, 376575034, 993535504, 984745483, 777613376 }
        }
    };
}
