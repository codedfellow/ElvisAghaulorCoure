using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberOneArraySolution
{
    internal class ArrayHandler
    {
        public static void CalculateTotalScore(int[] inputArray)
        {
            if (inputArray.Length == 0)
            {
                Console.WriteLine("array is empty");
            }

            int totalScore = 0;
            for (int i = 0; i < inputArray.Length; i++)
            {
                int currentItem = inputArray[i];

                if (currentItem % 2 == 0)
                {
                    totalScore += 1;
                    if (currentItem == 8)
                    {
                        totalScore += 5;
                    }
                }
                else
                {
                    totalScore += 3;
                }
            }

            Console.WriteLine($"Total: {totalScore}");
        }
    }
}
