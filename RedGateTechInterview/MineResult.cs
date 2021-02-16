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

        private int GetMineCountPerCell(int maxRowIndex, int currentRow, int currentColumn)
        {
            int count = 0;

            count += GetCountForTopRows(maxRowIndex, currentRow, currentColumn);
            count += GetCountForBottomRows(maxRowIndex, currentRow, currentColumn);
            count += GetCountRigtCell(maxRowIndex, currentRow, currentColumn);
            count += GetCountLeftCell(currentRow, currentColumn);

            return count;
        }

        private int GetCountLeftCell(int row, int column)
        {
            int count = 0;
            var leftX = row - 1;
            if (leftX >= 0 && arrInternal[leftX, column] == "*")
            {
                count += 1;
            }

            return count;
        }

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
