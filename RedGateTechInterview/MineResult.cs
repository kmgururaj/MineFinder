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
            //For each rows
            for (int yAxis = 0; yAxis <= arrInternal.GetUpperBound(0); yAxis++)
            {
                resultString.AppendLine();
                //for each columns
                for (int xAxis = 0; xAxis <= arrInternal.GetUpperBound(1); xAxis++)
                {
                    if (arrInternal[yAxis, xAxis] == "*")
                    {
                        resultString.Append("*");
                        continue;
                    }

                    int count = GetMineCountPerCell(yAxis, xAxis);

                    resultString.Append(count.ToString());

                }
            }
            return resultString.ToString();
        }

        /// <summary>
        /// Get Mine Count Per Cell
        /// </summary>
        /// <param name="maxRowIndex">Max Row Index</param>
        /// <param name="yAxis">current cell row index</param>
        /// <param name="currentColumn">current cell column index</param>
        /// <returns></returns>
        private int GetMineCountPerCell(int yAxis, int xAxis)
        {
            var countForTopRows = GetCountForTopRows(yAxis, xAxis);
            var countForBottomRows = GetCountForBottomRows(yAxis, xAxis);
            var countRigtCell = GetCountRigtCell(yAxis, xAxis);
            var countLeftCell = GetCountLeftCell(yAxis, xAxis);

            int count = 0;
            count += countForTopRows;
            count += countForBottomRows;
            count += countRigtCell;
            count += countLeftCell;

            return count;
        }

        /// <summary>
        /// Left cell mine count
        /// </summary>
        /// <param name="yAxis">Current Row</param>
        /// <param name="xAxis">Current Column</param>
        /// <returns>Mine count</returns>
        private int GetCountLeftCell(int yAxis, int xAxis)
        {
            int count = 0;
            var leftAxisModifiedX = xAxis - 1;
            if (leftAxisModifiedX >= 0 && arrInternal[yAxis, leftAxisModifiedX] == "*")
            {
                count += 1;
            }

            return count;
        }

        /// <summary>
        /// Get Count Rigt Cell
        /// </summary>
        /// <param name="maxRowIndex">Max Row Index</param>
        /// <param name="yAxis">Curret Row</param>
        /// <param name="yAxis">Current Column</param>
        /// <returns>Count of mines</returns>
        private int GetCountRigtCell(int yAxis, int xAxis)
        {
            int count = 0;

            var rightAxisModifiedX = xAxis + 1;
            if (rightAxisModifiedX <= arrInternal.GetUpperBound(1) && arrInternal[yAxis, rightAxisModifiedX] == "*")
            {
                count += 1;
            }

            return count;
        }

        /// <summary>
        /// Get Count For Bottom Rows
        /// </summary>
        /// <param name="maxRowIndex">Max Row Index</param>
        /// <param name="yAxis">Current Row</param>
        /// <param name="xAxis">Current Column</param>
        /// <returns>Count</returns>
        private int GetCountForBottomRows(int yAxis, int xAxis)
        {
            int count = 0;
            var bottomAxisModifiedY = yAxis + 1;
            if (bottomAxisModifiedY <= arrInternal.GetUpperBound(0))
            {
                //bottom
                if (arrInternal[bottomAxisModifiedY, xAxis] == "*")
                {
                    count += 1;
                }


                var bottomAxisRightModifiedX = xAxis + 1;
                if (bottomAxisRightModifiedX <= arrInternal.GetUpperBound(1) && arrInternal[bottomAxisModifiedY, bottomAxisRightModifiedX] == "*")
                {
                    count += 1;
                }

                var bottomAxisLeft = xAxis - 1;
                if (bottomAxisLeft >= 0 && arrInternal[bottomAxisModifiedY, bottomAxisLeft] == "*")
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
        /// <param name="yAxis">Current Row</param>
        /// <param name="xAxis">Current Column</param>
        /// <returns>Count</returns>
        private int GetCountForTopRows(int yAxis, int xAxis)
        {
            int count = 0;
            var topAxisModifiedY = yAxis - 1;
            if (topAxisModifiedY >= 0)
            {
                //top
                if (arrInternal[topAxisModifiedY, xAxis] == "*")
                {
                    count += 1;
                }

                //topright
                var topAxisRightModifiedX = xAxis + 1;
                if (topAxisRightModifiedX <= arrInternal.GetUpperBound(1) && arrInternal[topAxisModifiedY, topAxisRightModifiedX] == "*")
                {
                    count += 1;
                }

                //topLeft
                var topAxisLeftModifiedX = xAxis - 1;
                if (topAxisLeftModifiedX >= 0 && arrInternal[topAxisModifiedY, topAxisLeftModifiedX] == "*")
                {
                    count += 1;
                }
            }

            return count;
        }
    }
}
