using System;
using System.Threading.Tasks;

namespace Cs7
{
    class Program
    {
        static void Main(string[] args)
        {
            var common = Demo.GetMostCommonCharacter();

            (_, int occurences) = common;


        }
    }
}