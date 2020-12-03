using System;
using System.IO;
using System.Xml;

namespace Main
{

    public class Direction
    {
        public int xDir;
        public int yDir;
    }
    class Program
    {
        static void Main(string[] args)
        {
            char[,] matrix = new char[1000,1000];
            int xPos = 0;

            foreach (var line in File.ReadAllLines(@"D:\jul\Julekalender2020\03\data\matrix.txt"))
            {
                int yPos = 0;

                foreach (char c in line.ToCharArray())
                {
                    matrix[xPos, yPos] = c;
                    yPos++;
                }

                xPos++;
            }

            var words = File.ReadAllLines(@"D:\jul\Julekalender2020\03\data\wordlist.txt");
            bool[] foundwords = new bool[words.Length];

            for (xPos = 0; xPos < matrix.GetLength(0); xPos++)
            {
                for (int yPos = 0; yPos < matrix.GetLength(1); yPos++)
                {
                    for (int i = 0; i < words.Length; i++)
                    {
                        if (!foundwords[i])
                        {
                            if (IsWordThere(matrix, xPos, yPos, words[i]))
                            {
                                foundwords[i] = true;
                            }
                        }
                    }
                }
            }


            Console.WriteLine("Hello World!");
        }

        private static Direction[] directions = new[]
        {
            new Direction {xDir = 1, yDir = 0},
            new Direction {xDir = 1, yDir = 1},
            new Direction {xDir = 0, yDir = 1},
            new Direction {xDir = -1, yDir = 1},
            new Direction {xDir = -1, yDir = 0},
            new Direction {xDir = -1, yDir = -1},
            new Direction {xDir = 0, yDir = -1},
            new Direction {xDir = 1, yDir = -1}
        };

        private static bool IsWordThere(char[,] matrix, int xPos, int yPos, string word)
        {
            foreach (var dir in directions)
            {
                if (IsWordThere(matrix, xPos, yPos, dir, word))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool IsWordThere(char[,] matrix, int xPos, int yPos, Direction dir, string word)
        {
            char[] wordarray = word.ToCharArray();

            for (int i = 0; i < word.Length; i++)
            {
                int curXPos = xPos + i * dir.xDir;
                int curYPos = yPos + i * dir.yDir;

                if (curYPos < 0) return false;
                if (curXPos < 0) return false;
                if (curXPos >= matrix.GetLength(0)) return false;
                if (curYPos >= matrix.GetLength(1)) return false;

                if (matrix[curXPos, curYPos] != wordarray[i]) return false;

                Console.WriteLine("jj");
            }

            return true;

        }
    }
}
