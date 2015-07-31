using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tictactoe
{
    public class Square
    {
        int x;
        int y;
        public int get_x()
        {
            return x;
        }
        public int get_y()
        {
            return y;
        }
        public Square(int x_in, int y_in)
        {
            x = x_in;
            y = y_in;
        }
    }
}
