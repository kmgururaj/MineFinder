using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedGateTechInterview
{
    public static class MineResult
    {
        /// <summary>
        /// Get Mine Results
        /// </summary>
        /// <param name="arr"></param>
        /// <returns>Result String</returns>
        public static string GetMineResults(string[,] arr)
        {
            var resultString = new StringBuilder();

            int maxRowIndex = arr.GetUpperBound(0) + 1;

            //For each rows
            for (int row = 0; row <= arr.GetUpperBound(0); row++)
            {
                resultString.AppendLine();
                //for each columns
                for (int column = 0; column <= arr.GetUpperBound(1); column++)
                {
                    if (arr[row, column] == "*")
                    {
                        resultString.Append("*");
                        continue;
                    }

                    var count = 0;

                    var topY = column - 1;
                    if (topY >= 0)
                    {
                        //top
                        if (arr[row, topY] == "*")
                        {
                            count += 1;
                        }

                        //topright
                        var topRightX = row + 1;
                        if (topRightX < maxRowIndex && arr[topRightX, topY] == "*")
                        {
                            count += 1;
                        }

                        //topLeft
                        var topLeftX = row - 1;
                        if (topLeftX >= 0 && arr[topLeftX, row] == "*")
                        {
                            count += 1;
                        }
                    }

                    var bottomY = column + 1;
                    if (bottomY < maxRowIndex)
                    {
                        //bottom
                        if (arr[row, bottomY] == "*")
                        {
                            count += 1;
                        }


                        var bottomRightX = row + 1;
                        if (bottomRightX < maxRowIndex && arr[bottomRightX, bottomY] == "*")
                        {
                            count += 1;
                        }

                        var bottomLeftX = row - 1;
                        if (bottomLeftX >= 0 && arr[bottomLeftX, bottomY] == "*")
                        {
                            count += 1;
                        }
                    }

                    var rightX = row + 1;
                    if (rightX < maxRowIndex && arr[rightX, column] == "*")
                    {
                        count += 1;
                    }

                    var leftX = row - 1;
                    if (leftX >= 0 && arr[leftX, column] == "*")
                    {
                        count += 1;
                    }

                    resultString.Append(count.ToString());

                }
            }
            return resultString.ToString();
        }
    }
}
