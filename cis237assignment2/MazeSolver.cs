using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment2
{
    /// <summary>
    /// This class is used for solving a char array maze.
    /// You might want to add other methods to help you out.
    /// A print maze method would be very useful, and probably neccessary to print the solution.
    /// If you are real ambitious, you could make a seperate class to handle that.
    /// </summary>
    class MazeSolver
    {
        /// <summary>
        /// Class level memeber variable for the mazesolver class
        /// </summary>
        char[,] maze;
        int xStart;
        int yStart;
        bool finishBool;
        bool deadEndBool;
        bool completionPrint;

        Program program = new Program();

        /// <summary>
        /// Default Constuctor to setup a new maze solver.
        /// </summary>
        public MazeSolver()
        {}


        /// <summary>
        /// This is the public method that will allow someone to use this class to solve the maze.
        /// Feel free to change the return type, or add more parameters if you like, but it can be done
        /// exactly as it is here without adding anything other than code in the body.
        /// </summary>
        public void SolveMaze(char[,] maze, int xStart, int yStart)
        {
            //Assign passed in variables to the class level ones. It was not done in the constuctor so that
            //a new maze could be passed in to this solve method without having to create a new instance.
            //The variables are assigned so they can be used anywhere they are needed within this class. 
            this.maze = maze;
            this.xStart = xStart;
            this.yStart = yStart;
            completionPrint = false;

            mazeTraversal(maze, xStart, yStart);
            //Do work needed to use mazeTraversal recursive call and solve the maze.
        }


        /// <summary>
        /// This should be the recursive method that gets called to solve the maze.
        /// Feel free to change the return type if you like, or pass in parameters that you might need.
        /// This is only a very small starting point.
        /// </summary>
        private void mazeTraversal(char[,] maze, int xPosition, int yPosition)
        {
            deadEndBool = true;
            if(finishCheck(maze, xPosition, yPosition))
            {
                if(completionPrint == false)
                {
                    finishBool = true;
                    program.PrintMaze(maze);
                    completionPrint = true;
                }
               
                return;
            }
            else
            {
                finishBool = false;
            }

            if(maze[xPosition, yPosition] == '.')
            {
                maze[xPosition, yPosition] = 'X';
            }

            if(finishBool != true)
            {
                if(!wallChecker(maze, xPosition + 1, yPosition)) //Check up
                {
                    deadEndBool = false;
                    mazeTraversal(maze, xPosition + 1, yPosition);  
                }

                if(!wallChecker(maze, xPosition -1, yPosition)) //Check down
                {
                    deadEndBool = false;
                    mazeTraversal(maze, xPosition-1, yPosition);
                }

                if(!wallChecker(maze, xPosition, yPosition +1)) //Check right
                {
                    deadEndBool = false;
                    mazeTraversal(maze, xPosition, yPosition + 1);
                }

                if(!wallChecker(maze, xPosition, yPosition -1 )) //Check left
                {
                    deadEndBool = false;
                    mazeTraversal(maze, xPosition, yPosition - 1);
                }

                if (deadEndBool == true)
                {
                    if (returnAStep(maze, xPosition + 1, yPosition))
                    {
                        maze[xPosition, yPosition] = '0';
                        mazeTraversal(maze, xPosition + 1, yPosition);
                    }

                    if (returnAStep(maze, xPosition - 1, yPosition))
                    {
                        maze[xPosition, yPosition] = '0';
                        mazeTraversal(maze, xPosition - 1, yPosition);
                    }

                    if (returnAStep(maze, xPosition, yPosition + 1))
                    {
                        maze[xPosition, yPosition] = '0';
                        mazeTraversal(maze, xPosition, yPosition + 1);
                    }

                    if (returnAStep(maze, xPosition, yPosition - 1))
                    {
                        maze[xPosition, yPosition] = '0';
                        mazeTraversal(maze, xPosition, yPosition - 1);
                    }
                }
            }
        }


        //It checks for walls
        private bool wallChecker(char [,] maze, int xPosition, int yPosition)
        {
            if(maze[xPosition, yPosition] == '#' || maze[xPosition, yPosition] == '0' || maze[xPosition, yPosition] == 'X') //If the passed position isn't a valid move, it's a wall or a previously checked route so we return true. 
                {
                    return true;
                }
            else
            {
                return false;
            }
        }

        //Does this look familiar to you? If so return true, if not return false.
        private bool returnAStep(char[,] maze, int xPosition, int yPosition)
        {
            if(maze[xPosition, yPosition] == 'X')
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool finishCheck(char[,] maze, int xPosition, int yPosition)
        {
            if(maze[xPosition, yPosition] == 'F')
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
