using System;

namespace RedGateTechInterview
{
    class Program
    {

        static void Main(string[] args)
        {
            var arr = new string[,] { { ".", ".", "*" }, { ".", "*", "." }, { ".", ".", "." } };
            var result = new MineResult(arr).GetMineResults();

            Console.WriteLine(result);
        }

        
    }
}
