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
     * Complete the 'maxSubarray' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts INTEGER_ARRAY arr as parameter.
     */

    public static List<int> maxSubarray(List<int> arr)
    {
        int maxContiguous = arr[0];
        int currentSum = arr[0];
        int maxNonContiguous = arr[0];

        for (int i = 1; i < arr.Count; i++)
        {
            currentSum = Math.Max(arr[i], currentSum + arr[i]);
            maxContiguous = Math.Max(maxContiguous, currentSum);

            maxNonContiguous = Math.Max(maxNonContiguous, arr[i] + (maxNonContiguous > 0 ? maxNonContiguous : 0));
        }

        if (arr.All(x => x < 0))
        {
            maxNonContiguous = arr.Max();
        }

        return new List<int> { maxContiguous, maxNonContiguous };
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
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

            List<int> result = Result.maxSubarray(arr);

            textWriter.WriteLine(String.Join(" ", result));
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
