using System;
using System.Collections.Generic;
using System.Linq;

namespace ArrayManipulation
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');
            int n = Convert.ToInt32(firstMultipleInput[0]);
            int m = Convert.ToInt32(firstMultipleInput[1]);

            List<List<int>> queries = new List<List<int>>();

            for (int i = 0; i < m; i++)
            {
                queries.Add(Console.ReadLine().TrimEnd().Split(' ').ToList()
                    .Select(queriesTemp => Convert.ToInt32(queriesTemp)).ToList());

            }

            long result = arrayManipulation(n, queries);

            Console.WriteLine(result);

            Console.ReadKey();

        }

        static long arrayManipulation(int n, List<List<int>> queries)
        {

            int[] orgList = new int[n + 2];

            //O(n*m)
            //int m = queries.Count;

            //for (int i = 0; i < m; i++)
            //{
            //    for (int j = queries[i][0]-1; j <= queries[i][1]-1; j++)
            //    {
            //        orgList[j] += queries[i][2];
            //        if (orgList[j] > maxNumber) maxNumber = orgList[j];

            //    }

            //}

            //O(n) - this is better
            foreach (var query in queries)
            {
                int a = query[0] - 1;
                int b = query[1] - 1;
                int k = query[2];

                orgList[a] += k;
                orgList[b + 1] -= k;
            }

            return findMax(orgList);

        }

        private static long findMax(int[] orgList)
        {
            long maxNumber = 0;
            long sum = 0;
            for (int i = 0; i < orgList.Count() - 1; i++)
            {
                sum += orgList[i];
                if (sum > maxNumber) maxNumber = sum;

            }
            return maxNumber;
        }
    }
}
