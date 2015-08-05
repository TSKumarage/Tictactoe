using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tictactoe
{
    class Player
    {
        private String name;
        private int win;
        private int loss;
        private int draw;
        private int times;
        private int ratio;
        public void setWin(int a){
            win = a;
        }
        public void setLoss(int a)
        {
            loss = a;
        }
        public void setDraw(int a)
        {
            draw = a;
        }

        public void setTimes(int a)
        {
            times = a;

        }
        public void setName(String a)
        {
            name = a;

        }
        public void setRatio(int a)
        {
            ratio = a;

        }
        public int getWin()
        {
            return win;
        }
        public int getLoss()
        {
            return loss;
        }
        public int getDraw()
        {
            return draw;
        }
        public int getTimes()
        {
            return times;
        }
        public String getName()
        {
            return name;
        }
        public int getRatio()
        {
            return ratio;
        }
    }
}
