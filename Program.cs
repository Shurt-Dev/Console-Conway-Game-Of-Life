using System.Data;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;

namespace ConwayGameOfLife
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool[,] world = new bool[6, 6];

            bool[,] buffer = world;

            void Place(int x, int y)
            {
                world[x, y] = true;
            }

            bool WillBeAlive(int x, int y)
            {
                int countAlive = 0;
                int countError = 0;
                /*for (int i = -1; i < 2; ++i)
                {
                    for (int j = -1; j < 2; ++j)
                    {
                        if (i == j && i == 0)
                            continue;
                        try
                        {
                            if (world[x + j, y + i] == true)
                            {
                                ++countAlive;
                                if (countAlive == 1)
                                    Console.WriteLine(x + "," + y + "\n{");
                                if (countAlive > 0)
                                Console.WriteLine(j + "," + i + "; " + countAlive);
                            }
                            //   01234    01234
                            //
                            //0  00000    00000
                            //1  00100    00000
                            //2  00010 -> 01010
                            //3  01110    00110
                            //4  00000    00100
                        }
                        catch (IndexOutOfRangeException)
                        {
                            //IOORE expected when trying to check world[-1,-1] or similar
                            countError++;
                            if (countError > 5)
                            {
                                //max IOORE we can catch is five in the corner
                                //if there are more than five, there is a problem
                                throw new ArgumentOutOfRangeException();
                            }
                        }
                    }
                }*/

                try
                {
                    countAlive += world[x - 1, y - 1] == true? 1 : 0; 
                    Console.Write(countAlive);
                    countAlive += world[x - 1, y] == true ? 1 : 0;
                    Console.Write(countAlive);
                    countAlive += world[x - 1, y + 1] == true ? 1 : 0;
                    Console.Write(countAlive);
                    countAlive += world[x, y - 1] == true ? 1 : 0;
                    Console.Write(countAlive);
                    countAlive += world[x, y + 1] == true ? 1 : 0;
                    Console.Write(countAlive);
                    countAlive += world[x + 1, y - 1] == true ? 1 : 0;
                    Console.Write(countAlive);
                    countAlive += world[x + 1, y] == true ? 1 : 0;
                    Console.Write(countAlive);
                    countAlive += world[x + 1, y + 1] == true ? 1 : 0;
                    Console.WriteLine(countAlive);
                }
                catch (IndexOutOfRangeException)
                {
                    //IOORE expected when trying to check world[-1,-1] or similar
                    countError++;
                    if (countError > 5)
                    {
                        //max IOORE we can catch is five in the corner
                        //if there are more than five, there is a problem
                        throw new ArgumentOutOfRangeException();
                    }
                }





                /*if (countAlive > 0)
                    Console.WriteLine("}\n");*/
                if (countAlive < 4 && countAlive > 1 && world[x, y] == true) { return true; }
                else if (countAlive == 3 && world[x, y] == false) { return true; }
                else { return false; }
            }

            void WorldTest()
            {
                for (int i = 0; i < world.GetLength(1) - 1; ++i)
                {
                    for (int j = 0; j < world.GetLength(0) - 1; ++j)
                    {
                        buffer[j, i] = WillBeAlive(j, i);
                    }
                }
                world = buffer;
            }

            void WorldPrint()
            {
                for (int i = 0; i < world.GetLength(1) - 1; ++i)
                {
                    for (int j = 0; j < world.GetLength(0) - 1; ++j)
                    {
                        if (world[j, i] == true)
                        {
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.Write("1");
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Write("0");
                        }
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
            //   01234
            //
            Place(1, 3);  //0  00000
            Place(2, 1);  //1  00100 
            Place(2, 3);  //2  00010
            Place(3, 3);  //3  01110
            Place(3, 2);  //4  00000

            for (int i = 0; i < 2; ++i)
            {
                WorldPrint();
                WorldTest();
            }

        }
    }
}