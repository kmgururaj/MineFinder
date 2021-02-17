using System.Text;

namespace Guru.MineSweeper
{
    public class MineResult
    {
        private readonly char[,] arrInternal;

        private readonly int upperBoundarrX;

        private readonly int upperBoundarrY;

        private const char MineChar = '*';

        public MineResult(char[,] arr)
        {
            arrInternal = arr;
            upperBoundarrY = arrInternal.GetUpperBound(0);
            upperBoundarrX = arrInternal.GetUpperBound(1);
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
            for (int yAxis = 0; yAxis <= upperBoundarrY; yAxis++)
            {
                resultString.AppendLine();
                //for each columns
                for (int xAxis = 0; xAxis <= upperBoundarrX; xAxis++)
                {
                    if (arrInternal[yAxis, xAxis] == MineChar)
                    {
                        resultString.Append(MineChar);
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

            int count = countForTopRows + countForBottomRows + countRigtCell + countLeftCell;

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
            if (leftAxisModifiedX >= 0 && arrInternal[yAxis, leftAxisModifiedX] == MineChar)
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
            if (rightAxisModifiedX <= upperBoundarrX && arrInternal[yAxis, rightAxisModifiedX] == MineChar)
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
                if (arrInternal[bottomAxisModifiedY, xAxis] == MineChar)
                {
                    count += 1;
                }


                var bottomAxisRightModifiedX = xAxis + 1;
                if (bottomAxisRightModifiedX <= upperBoundarrX && arrInternal[bottomAxisModifiedY, bottomAxisRightModifiedX] == MineChar)
                {
                    count += 1;
                }

                var bottomAxisLeft = xAxis - 1;
                if (bottomAxisLeft >= 0 && arrInternal[bottomAxisModifiedY, bottomAxisLeft] == MineChar)
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
                if (arrInternal[topAxisModifiedY, xAxis] == MineChar)
                {
                    count += 1;
                }

                //topright
                var topAxisRightModifiedX = xAxis + 1;
                if (topAxisRightModifiedX <= upperBoundarrX && arrInternal[topAxisModifiedY, topAxisRightModifiedX] == MineChar)
                {
                    count += 1;
                }

                //topLeft
                var topAxisLeftModifiedX = xAxis - 1;
                if (topAxisLeftModifiedX >= 0 && arrInternal[topAxisModifiedY, topAxisLeftModifiedX] == MineChar)
                {
                    count += 1;
                }
            }

            return count;
        }
    }
}
