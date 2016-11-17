using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using LedGeekBox.Helper;
using LedGeekBox.ViewModel;

namespace LedGeekBox.Model.Scenario
{
    public class SnakeScenario : IScenario
    {

        public SnakeScenario()
        {

        }

        List<IStep> _steps;

        Thread t1 = null;

        int NbrOfCycle = 300;

        public int Start(List<IStep> steps)
        {
            _steps = steps;
            t1 = new Thread(Render);
            t1.Start();

            return ModelHelper.period * NbrOfCycle;
        }


        public enum EDirection
        {
            Haut, Bas, Gauche, Droite, Undefine
        }

        private EDirection GetNextDirection(Position head, EDirection snakeDirection)
        {
            bool ok = false;
            EDirection dir = EDirection.Bas;

       do
            {
                int rand = randomX.Next(1, 5);
                switch (rand)
                {
                    case 1:
                        if (head.Y != 0 && snakeDirection != EDirection.Bas)
                        {
                            ok = true;
                            dir = EDirection.Haut;
                        }
                        break;
                    case 2:
                        if (head.Y != 15 && snakeDirection != EDirection.Haut)
                        {
                            ok = true;
                            dir = EDirection.Bas;
                        }
                        break;
                    case 3:
                        if (head.X != 0 && snakeDirection != EDirection.Droite)
                        {
                            ok = true;
                            dir = EDirection.Gauche;
                        }
                        break;
                    case 4:
                        if (head.X != 39 && snakeDirection != EDirection.Gauche)
                        {
                            ok = true;
                            dir = EDirection.Droite;
                        }
                        break;
                }
            } while (!ok);
            return dir;
        }



        private static bool[,] NewGrid(List<Position> snake, bool[,] grid)
        {
            snake.ForEach(P => grid[P.X, P.Y] = true);
            return grid;
        }


        private static Random randomX = new Random();

        private static Random randomJump = new Random();
        int currentSaut = 0;
        int cpt = 0;

        List<Position> snake = new List<Position>();
        EDirection snakeDirection = EDirection.Droite;

        public void Render()
        {
            snake.Add(new Position(4, 7));
            snake.Add(new Position(3, 7));
            snake.Add(new Position(2, 7));
            snake.Add(new Position(1, 7));
            snake.Add(new Position(0, 7));
            currentSaut = randomX.Next(2, 6);

            for (int cycle = 0; cycle < NbrOfCycle; cycle++)
            {
                EDirection dir = EDirection.Undefine;
                cpt++;
                if (cpt == currentSaut)
                {
                    cpt = 0;
                    currentSaut = randomX.Next(2, 6);
                    dir = GetNextDirection(snake[0], snakeDirection);
                }
                else
                {
                    if (snake[0].IsACorner())
                    {
                        dir = GetNextDirection(snake[0], snakeDirection);
                    }
                    else
                    {
                        dir = snakeDirection;
                        /**************/
                        if (snake[0].Y == 0 && snakeDirection == EDirection.Haut)
                        {
                            dir = GetNextDirection(snake[0], snakeDirection);
                        }

                        if (snake[0].Y == 15 && snakeDirection == EDirection.Bas)
                        {
                            dir = GetNextDirection(snake[0], snakeDirection);
                        }

                        if (snake[0].X == 0 && snakeDirection == EDirection.Gauche)
                        {
                            dir = GetNextDirection(snake[0], snakeDirection);
                        }

                        if (snake[0].X == 39 && snakeDirection == EDirection.Droite)
                        {
                            dir = GetNextDirection(snake[0], snakeDirection);
                        }
                        /************/
                    }

                }

                bool[,] datas = new bool[40, 16];

              
                Position newHead = null;
                switch (dir)
                {
                    case EDirection.Bas:
                        newHead = new Position(snake[0].X, snake[0].Y + 1);
                        break;
                    case EDirection.Droite:
                        newHead = new Position(snake[0].X + 1, snake[0].Y);
                        break;
                    case EDirection.Gauche:
                        newHead = new Position(snake[0].X - 1, snake[0].Y);
                        break;
                    case EDirection.Haut:
                        newHead = new Position(snake[0].X, snake[0].Y - 1);
                        break;
                }
                if (newHead.X == 40 || newHead.X == -1 || newHead.Y == 16 || newHead.Y == -1)
                {
                    
                }
                snakeDirection = dir;

                List<Position> newSnake = new List<Position> { newHead, snake[0], snake[1], snake[2], snake[3] };
                snake = newSnake;
                datas = NewGrid(snake, datas);
                var line1 = HelperMatriceListConvertor.ConvertToList(datas);

                _steps.ForEach(x => x.Apply(line1));

                Thread.Sleep(ModelHelper.period);
            }


        }

        public void Stop()
        {
            if (t1 != null && t1.IsAlive)
            {
                t1.Abort();
            }
            t1 = null;
        }
    }

    public class Position
    {
        public int X { get; set; } // de 0 a 39

        public int Y { get; set; } // de 0 a 7

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return string.Format("X:{0}  -   Y:{1} ", X, Y);
        }


        public bool IsACorner()
        {
            if ((X == 0 && Y == 0) || (X == 39 && Y == 0) || (X == 0 && Y == 15) || (X == 39 && Y == 15))
            {
                return true;
            }
            return false;
        }
    }
}
