using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedGateTechInterview
{
    class Program
    {
        public class Coordinates
        {
            public int X { get; set; }
            public int y { get; set; }
        }

        static void Main(string[] args)
        {

            var arr = new string[,] { { ".", ".", "*" }, { ".", "*", "." }, { ".", ".", "." } };
            var result = MineResult.GetMineResults(arr);

            Console.WriteLine(result);
        }

        
    }
}
