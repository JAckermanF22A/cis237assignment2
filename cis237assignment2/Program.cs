using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Jacob Ackerman
//Fall 2015
//CIS237

//Sadly there's no victory music for reaching the end.


namespace cis237assignment2
{
    class Program
    {
        /// <summary>
        /// This is the main entry point for the program.
        /// You are free to add anything else you would like to this program,
        /// however the maze solving part needs to occur in the MazeSolver class.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            /// <summary>
            /// Starting Coordinates.
            /// </summary>
            const int X_START = 1;
            const int Y_START = 1;

            ///<summary>
            /// The first maze that needs to be solved.
            /// Note: You may want to make a smaller version to test and debug with.
            /// You don't have to, but it might make your life easier.
            /// </summary>
            char[,] maze1 = 
            { { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' },
            { '#', '.', '.', '.', '#', '.', '.', '.', '.', '.', '.', '#' },
            { '#', '.', '#', '.', '#', '.', '#', '#', '#', '#', '.', '#' },
            { '#', '#', '#', '.', '#', '.', '.', '.', '.', '#', '.', '#' },
            { '#', '.', '.', '.', '.', '#', '#', '#', '.', '#', '.', 'F' },
            { '#', '#', '#', '#', '.', '#', '.', '#', '.', '#', '.', '#' },
            { '#', '.', '.', '#', '.', '#', '.', '#', '.', '#', '.', '#' },
            { '#', '#', '.', '#', '.', '#', '.', '#', '.', '#', '.', '#' },
            { '#', '.', '.', '.', '.', '.', '.', '.', '.', '#', '.', '#' },
            { '#', '#', '#', '#', '#', '#', '.', '#', '#', '#', '.', '#' },
            { '#', '.', '.', '.', '.', '.', '.', '#', '.', '.', '.', '#' },
            { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' } };

            char[,] copyOfMaze1 = (char[,])maze1.Clone(); //A clone of maze1 so everything doesn't break when we try to transpose!

            /// <summary>
            /// Create a new instance of a mazeSolver.
            /// </summary>
            MazeSolver mazeSolver = new MazeSolver();

            

            /// <summary>
            /// Tell the instance to solve the first maze with the passed maze, and start coordinates.
            /// </summary>

            Console.WriteLine("Original Maze:");
            mazeSolver.SolveMaze(maze1, X_START, Y_START);

            Console.WriteLine("Transposed Maze:");
            //Create the second maze by transposing the first maze
            char[,] maze2 = transposeMaze(copyOfMaze1);
            

            //Solve the transposed maze.
            mazeSolver.SolveMaze(maze2, X_START, Y_START); 

        }


        /// </summary>
        /// <param name="mazeToTranspose"></param>
        /// <returns>transposedMaze</returns>
        static char[,] transposeMaze(char[,] mazeToTranspose)
        {
            //A temporary placeholder to hold the transposed array and then get returned.
            char[,] tempMaze = new char[mazeToTranspose.GetLength(0), mazeToTranspose.GetLength(1)];

            int rowLength = tempMaze.GetLength(0);
            int colLength = tempMaze.GetLength(1);

            //Goes through row by row transposing the columns.
            for (int r = 0; r < rowLength; r++)
            {
                for (int c = 0; c < colLength; c++)
                {
                    tempMaze[r, c] = mazeToTranspose[c, r]; //Transpose the values!
                }
            }
            return tempMaze; //Spit out the newly transposed maze
        }

        public void PrintMaze(char[,] maze)
        {
            char[,] solvedMaze;
            solvedMaze = maze;

            int rowLength = solvedMaze.GetLength(0);
            int colLength = solvedMaze.GetLength(1);
            
            //Basically the same thing as the row transposer, except instead of transposing it prints out the maze.
            for (int r = 0; r < rowLength; r++)
            {
                for (int c = 0; c < colLength; c++)
                {
                    Console.Write(string.Format("{0} ", solvedMaze[r, c])); 
                }
                Console.Write(Environment.NewLine);
            }

            Console.Write(Environment.NewLine + Environment.NewLine);
        }
    }
}
