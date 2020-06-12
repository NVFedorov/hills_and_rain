using System;
using System.Collections.Generic;

namespace Landscape
{
    /// <summary>
    /// This class is a helper class to solve the landscape problem. 
    /// There is a landscape with hills and pits which have square shapes. 
    /// During a rain the pits are getting filled with water. The task is to calculate the area of the pits filled by water.
    /// </summary>
    public static class Problem
    {
        public static int MaxHeightValues = 32000;
        public static int MaxLandscapeSize = 32000;

        /// <summary>
        /// Solves the landscape problem.
        /// </summary>
        /// <param name="heights">The array of hill heights. The heights must be between 0 and 32000. Max length of heights is 32000.</param>
        /// <returns>Area of the filled by water pits.</returns>
        public static int Solve(int[] heights)
        {
            var timer = new System.Diagnostics.Stopwatch();
            if (heights.Length > MaxLandscapeSize)
                throw new ArgumentException($"The max landscape size is {MaxLandscapeSize}");

            if (heights[^1] < 0 || heights[^1] > MaxHeightValues)
                throw new ArgumentException($"The hill heights values must be between 0 and {MaxHeightValues}");

            timer.Start();
            var result = SolveProblem(heights);
            timer.Stop();
            System.Diagnostics.Debug.WriteLine($"Elapsed time: {timer.ElapsedMilliseconds}");
            return result;
        }

        private static int SolveProblem(int[] heights)
        {
            var result = 0;
            var hillStartEndPairs = new List<int[]>();
            for (var i = 0; i < heights.Length - 1; i++)
            {
                if (heights[i] < 0 || heights[i] > MaxHeightValues)
                    throw new ArgumentException($"The hill heights values must be between 0 and {MaxHeightValues}");

                if (heights[i] > heights[i + 1])
                {
                    var max = 0;
                    var maxJ = -1;
                    var push = false;
                    for (var j = i + 1; j < heights.Length - 1; j++)
                    {
                        if (heights[j] < 0 || heights[j] > MaxHeightValues)
                            throw new ArgumentException($"The hill heights values must be between 0 and {MaxHeightValues}");
                        //iterations++;
                        if (heights[j] < heights[j + 1])
                        {
                            push = true;
                            if (heights[i] <= heights[j + 1])
                            {
                                maxJ = j + 1;
                                break;
                            }
                            else if (heights[j + 1] > max)
                            {
                                maxJ = j + 1;
                                max = heights[maxJ];
                            }
                        }
                    }

                    if (maxJ >= 0 && push)
                    {
                        var replaced = false;
                        if (hillStartEndPairs.Count > 0)
                        {
                            if (hillStartEndPairs[^1][0] <= i && maxJ <= hillStartEndPairs[^1][1])
                            {
                                replaced = true;
                            }
                        }

                        if (!replaced)
                            hillStartEndPairs.Add(new int[] { i, maxJ });

                        if (maxJ > i)
                            i = maxJ - 1;
                    }
                }
                
            }

            foreach(var pair in hillStartEndPairs)
            {
                var min = Math.Min(heights[pair[0]], heights[pair[1]]);
                for (var i = pair[0]; i < pair[1]; i++)
                {
                    result += Math.Max(0, min - heights[i]);
                    //iterations++;
                }
            }

            return result;
        }
    }
}
