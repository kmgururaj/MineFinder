using System.Text;

namespace RedGateTechInterview
{
    public class MineResult
    {
        private readonly string[,] arrInternal;
        public MineResult(string[,] arr)
        {
            arrInternal = arr;
        }

        /// <summary>
        /// Get Mine Results
        /// </summary>
        /// <param name="arr"></param>
        /// <returns>Result String</returns>
        public string GetMineResults()
        {
            var resultString = new StringBuilder();
            int maxRowIndex = arrInternal.GetUpperBound(0) + 1;

            //For each rows
            for (int row = 0; row <= arrInternal.GetUpperBound(0); row++)
            {
                resultString.AppendLine();
                //for each columns
                for (int column = 0; column <= arrInternal.GetUpperBound(1); column++)
                {
                    if (arrInternal[row, column] == "*")
                    {
                        resultString.Append("*");
                        continue;
                    }

                    int count = GetMineCountPerCell(maxRowIndex, row, column);

                    resultString.Append(count.ToString());

                }
            }
            return resultString.ToString();
        }

        /// <summary>
        /// Get Mine Count Per Cell
        /// </summary>
        /// <param name="maxRowIndex">Max Row Index</param>
        /// <param name="currentRow">current cell row index</param>
        /// <param name="currentColumn">current cell column index</param>
        /// <returns></returns>
        private int GetMineCountPerCell(int maxRowIndex, int currentRow, int currentColumn)
        {
            int count = 0;

            count += GetCountForTopRows(maxRowIndex, currentRow, currentColumn);
            count += GetCountForBottomRows(maxRowIndex, currentRow, currentColumn);
            count += GetCountRigtCell(maxRowIndex, currentRow, currentColumn);
            count += GetCountLeftCell(currentRow, currentColumn);

            return count;
        }

        /// <summary>
        /// Left cell mine count
        /// </summary>
        /// <param name="currentRow">Current Row</param>
        /// <param name="currentColumn">Current Column</param>
        /// <returns>Mine count</returns>
        private int GetCountLeftCell(int currentRow, int currentColumn)
        {
            int count = 0;
            var leftX = currentRow - 1;
            if (leftX >= 0 && arrInternal[leftX, currentColumn] == "*")
            {
                count += 1;
            }

            return count;
        }

        /// <summary>
        /// Get Count Rigt Cell
        /// </summary>
        /// <param name="maxRowIndex">Max Row Index</param>
        /// <param name="curretRow">Curret Row</param>
        /// <param name="currentColumn">Current Column</param>
        /// <returns>Count of mines</returns>
        private int GetCountRigtCell(int maxRowIndex, int curretRow, int currentColumn)
        {
            int count = 0;

            var rightX = curretRow + 1;
            if (rightX < maxRowIndex && arrInternal[rightX, currentColumn] == "*")
            {
                count += 1;
            }

            return count;
        }

        /// <summary>
        /// Get Count For Bottom Rows
        /// </summary>
        /// <param name="maxRowIndex">Max Row Index</param>
        /// <param name="currentRow">Current Row</param>
        /// <param name="currentColumn">Current Column</param>
        /// <returns>Count</returns>
        private int GetCountForBottomRows(int maxRowIndex, int currentRow, int currentColumn)
        {
            int count = 0;
            var bottomY = currentColumn + 1;
            if (bottomY < maxRowIndex)
            {
                //bottom
                if (arrInternal[currentRow, bottomY] == "*")
                {
                    count += 1;
                }


                var bottomRightX = currentRow + 1;
                if (bottomRightX < maxRowIndex && arrInternal[bottomRightX, bottomY] == "*")
                {
                    count += 1;
                }

                var bottomLeftX = currentRow - 1;
                if (bottomLeftX >= 0 && arrInternal[bottomLeftX, bottomY] == "*")
                {
                    count += 1;
                }
            }

            return count;
        }

        /// <summary>
        /// Get Count For Top Rows
        /// </summary>
        /// <param name="maxRowIndex">Max Row Index</param>
        /// <param name="currentRow">Current Row</param>
        /// <param name="currentColumn">Current Column</param>
        /// <returns>Count</returns>
        private int GetCountForTopRows(int maxRowIndex, int currentRow, int currentColumn)
        {
            int count = 0;
            var topY = currentColumn - 1;
            if (topY >= 0)
            {
                //top
                if (arrInternal[currentRow, topY] == "*")
                {
                    count += 1;
                }

                //topright
                var topRightX = currentRow + 1;
                if (topRightX < maxRowIndex && arrInternal[topRightX, topY] == "*")
                {
                    count += 1;
                }

                //topLeft
                var topLeftX = currentRow - 1;
                if (topLeftX >= 0 && arrInternal[topLeftX, currentRow] == "*")
                {
                    count += 1;
                }
            }

            return count;
        }
    }
}
