using System;
using System.Linq;

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
            if (heights.Length >= MaxLandscapeSize)
                throw new ArgumentException($"The max landscape size is {MaxLandscapeSize}"); 
            
            if (heights.Any(x => x < 0 || x > MaxHeightValues))
                throw new ArgumentException($"The hill heights values must be between 0 and {MaxHeightValues}");



            return 0;
        }
    }
}
