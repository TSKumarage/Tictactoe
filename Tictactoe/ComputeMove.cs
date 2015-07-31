using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tictactoe
{
    class ComputeMove
    {
        private int[,] board = new int[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
        private Square computersMove;
        List<Square> availablePoints;
        public Square get_computersMove()
        {
            return computersMove;
        }
        public void play(Square spot, int player)
        {
            this.board[spot.get_x(), spot.get_y()] = player;
        }

        public bool hasXWon()
        {
            if ((board[0, 0] == board[1, 1] && board[0, 0] == board[2, 2] && board[0, 0] == 1) 
                || (board[0, 2] == board[1, 1] && board[0, 2] == board[2, 0] && board[0, 2] == 1))
            {

                return true;
            }
            for (int i = 0; i < 3; ++i)
            {
                if (((board[i, 0] == board[i, 1] && board[i, 0] == board[i, 2] && board[i, 0] == 1)
                        || (board[0, i] == board[1, i] && board[0, i] == board[2, i] && board[0, i] == 1)))
                {

                    return true;
                }
            }
            return false;
        }

        public bool hasOWon()
        {
            if ((board[0, 0] == board[1, 1] && board[0, 0] == board[2, 2] && board[0, 0] == 2) 
                || (board[0, 2] == board[1, 1] && board[0, 2] == board[2, 0] && board[0, 2] == 2))
            {

                return true;
            }
            for (int i = 0; i < 3; ++i)
            {
                if (((board[i, 0] == board[i, 1] && board[i, 0] == board[i, 2] && board[i, 0] == 2)
                        || (board[0, i] == board[1, i] && board[0, i] == board[2, i] && board[0, i] == 2)))
                {

                    return true;
                }
            }
            return false;
        }

        private List<Square> getAvailableStates()
        {
            availablePoints = new List<Square>();
            for (int i = 0; i < 3; ++i)
            {
                for (int j = 0; j < 3; ++j)
                {
                    if (board[i, j] == 0)
                    {
                        availablePoints.Add(new Square(i, j));
                    }
                }
            }
            return availablePoints;
        }
        public void Compute(String difficulty)
        {
            if (difficulty.Equals("Hard"))
            {
                minimax(0, 1);
            }else if(difficulty.Equals("Medium"))
            {
               
                computersMove = win();
                if (computersMove == null)
                {
                    computersMove = block();
                    if (computersMove == null)
                    {
                        computersMove = Fork_block();
                        if (computersMove == null)
                        {
                            computersMove = mark_center();
                            if (computersMove == null)
                            {
                                computersMove = mark_coner();
                                if (computersMove == null)
                                {
                                    computersMove = random_play();
                                }
                            }
                            
                        }
                    }
                }
                
            }else{
                computersMove=win();
                if (computersMove == null)
                {
                    computersMove = block();
                    if (computersMove == null)
                    {
                        computersMove = random_play();
                    }
                }
            }
        }
        private Square mark_center()
        {
            if (board[1, 1] == 0)
            { return new Square(1, 1); }
            else
                return null;
        }
        private Square mark_coner()
        {
            if (board[2, 0] == 0)
            { return new Square(2, 0); }
            else if (board[0, 0] == 0)
            { return new Square(0, 0); }
            else if (board[2, 2] == 0)
            { return new Square(2, 2); }
            else if (board[0, 2] == 0)
            { return new Square(0, 2); }
            else
                return null;
        }
        private Square win()
        {
            int count = 0;
            int free_square_count;
            int x = 0, y = 0;
            for (int i = 0; i < 3; i++)
            {
                count = 0;
                free_square_count = 0;
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] == 0)
                    {
                        free_square_count++;
                        x = i;
                        y = j;
                    }
                    else if (board[i, j] == 1)
                    {
                        count++;
                    }


                }
                if (count == 2 && free_square_count == 1)
                {
                    return new Square(x, y);

                }

            }
            for (int i = 0; i < 3; i++)
            {
                free_square_count = 0;
                count = 0;
                for (int j = 0; j < 3; j++)
                {
                    if (board[j, i] == 0)
                    {
                        free_square_count++;
                        x = j;
                        y = i;
                    }
                    else if (board[j, i] == 1)
                    {
                        count++;
                    }


                }
                if (count == 2 && free_square_count == 1)
                {
                    return new Square(x, y);

                }

            }
            if ((board[0, 0] == board[1, 1] && board[2, 2] == 0 && board[0, 0] == 1))
            {
                return new Square(2, 2);
            }
            else if ((board[0, 0] == board[2, 2] && board[1, 1] == 0 && board[0, 0] == 1))
            {
                return new Square(1, 1);
            }
            else if ((board[1, 1] == board[2, 2] && board[0, 0] == 0 && board[1, 1] == 1))
            {
                return new Square(0, 0);
            }
            else if ((board[0, 2] == board[1, 1] && board[2, 0] == 0 && board[0, 2] == 1))
            {
                return new Square(2, 0);
            }
            else if ((board[0, 2] == board[2, 0] && board[1, 1] == 0 && board[0, 2] == 1))
            {
                return new Square(1, 1);
            }
            else if ((board[2, 0] == board[1, 1] && board[0, 2] == 0 && board[2, 0] == 1))
            {
                return new Square(0, 2);
            }
            return null;
        }
        private Square block()
        {
            //Square point;
            int count = 0;
            int free_square_count;
            int x=0, y=0;
            for (int i = 0; i < 3; i++)
            {
                free_square_count = 0;
                count = 0;
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] == 0)
                    {
                        free_square_count++;
                        x = i;
                        y = j;
                    }
                    else if (board[i, j] == 2) {
                        count++;
                    }


                }
                if (count == 2 && free_square_count == 1)
                {
                    return new Square(x, y);
                    
                }

            }
            for (int i = 0; i < 3; i++)
            {
                free_square_count = 0;
                count = 0;
                for (int j = 0; j < 3; j++)
                {
                    if (board[j, i] == 0)
                    {
                        free_square_count++;
                        x = j;
                        y = i;
                    }
                    else if (board[j, i] == 2)
                    {
                        count++;
                    }


                }
                if (count == 2 && free_square_count == 1)
                {
                    return new Square(x, y);

                }

            }
            if ((board[0, 0] == board[1, 1] && board[2, 2] == 0 && board[0, 0] == 2))
            {
                return new Square(2,2);
            }else if((board[0, 0] == board[2, 2] && board[1, 1] == 0 && board[0, 0] == 2))
            {
                return new Square(1,1);
            }else if((board[1, 1] == board[2, 2] && board[0, 0] == 0 && board[1, 1] == 2))
            {
                return new Square(0,0);
            }else if((board[0, 2] == board[1, 1] && board[2, 0]==0 && board[0, 2] == 2))
            {
                return new Square(2, 0);
            }
            else if ((board[0, 2] == board[2, 0] && board[1, 1] == 0 && board[0, 2] == 2))
            {
                return new Square(1, 1);
            }
            else if ((board[2, 0] == board[1, 1] && board[0, 2] == 0 && board[2, 0] == 2))
            {
                return new Square(0, 2);
            }

            
            return null;
        }
        private Square Fork_block()
        {
            if ((board[0, 0] == board[1, 1] && board[2, 2] == 1 && board[0, 0] == 2))
            {
                if (board[0, 2] == 0)
                { return new Square(0, 2); }
                if (board[2, 0] == 0)
                { return new Square(2, 0); }
                
            }
            else if ((board[0, 0] == board[2, 2] && board[1, 1] == 1 && board[0, 0] == 2))
            {
                if (board[0, 1] == 0)
                { return new Square(0, 1); }
                if (board[1, 0] == 0)
                { return new Square(1, 0);}
                if (board[1, 2] == 0)
                { return new Square(1, 2); }
                if (board[2, 1] == 0)
                { return new Square(2, 1);}
            }
            else if ((board[1, 1] == board[2, 2] && board[0, 0] == 1 && board[1, 1] == 2))
            {
                if (board[0, 2] == 0)
                { return new Square(0, 2); }
                if (board[2, 0] == 0)
                { return new Square(2, 0); }
            }
            else if ((board[0, 2] == board[1, 1] && board[2, 0] == 1 && board[0, 2] == 2))
            {
                if (board[0, 0] == 0)
                { return new Square(0, 0); }
                if (board[2, 2] == 0)
                { return new Square(2, 2); }
            }
            else if ((board[0, 2] == board[2, 0] && board[1, 1] == 1 && board[0, 2] == 2))
            {
                if (board[0, 1] == 0)
                { return new Square(0, 1); }
                if (board[1, 0] == 0)
                { return new Square(1, 0); }
                if (board[1, 2] == 0)
                { return new Square(1, 2); }
                if (board[2, 1] == 0)
                { return new Square(2, 1); }
            }
            else if ((board[2, 0] == board[1, 1] && board[0, 2] == 1 && board[2, 0] == 2))
            {
                if (board[0, 0] == 0)
                { return new Square(0, 0); }
                if (board[2, 2] == 0)
                { return new Square(2, 2); }
            }

            return null;
        }
        private Square random_play()
        {
            List<Square> random_points=new List<Square>();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] == 0)
                    { random_points.Add( new Square(i, j)); }
                }
            }
            Random rand_num = new Random();
            return random_points.ElementAt(rand_num.Next(0, random_points.Count() - 1));
        }
        private int minimax(int depth, int turn)
        {
            if (hasXWon()) return +1;
            if (hasOWon()) return -1;

            List<Square> pointsAvailable = getAvailableStates();
            if (pointsAvailable.Count() == 0) return 0;

            int min = 1000, max = -1000;

            for (int i = 0; i < pointsAvailable.Count(); ++i)
            {
                Square point = pointsAvailable.ElementAt(i);
                if (turn == 1)
                {
                    play(point, 1);
                    int currentScore = minimax(depth + 1, 2);
                    max = Math.Max(currentScore, max);

                    //if(depth == 0)System.out.println("Score for position "+(i+1)+" = "+currentScore);
                    if (currentScore >= 0) { if (depth == 0) computersMove = point; }
                    if (currentScore == 1) { board[point.get_x(), point.get_y()] = 0; break; }
                    if (i == pointsAvailable.Count() - 1 && max < 0) { if (depth == 0)computersMove = point; }
                }
                else if (turn == 2)
                {
                    play(point, 2);
                    int currentScore = minimax(depth + 1, 1);
                    min = Math.Min(currentScore, min);
                    if (min == -1) { board[point.get_x(), point.get_y()] = 0; break; }
                }
                board[point.get_x(), point.get_y()] = 0; //Reset this point
            }
            return turn == 1 ? max : min;
        }
    }
}
