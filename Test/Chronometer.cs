using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    class Chronometer
    {
        private int hrs;
        private int min;
        private int seg;
        private Timer timer;

        public Chronometer(Timer timer)
        {
            reset();
            this.timer = timer;
        }

        private void reset()
        {
            hrs = 0;
            min = 0;
            seg = 0;
        }

        public void start()
        {
            timer.Enabled = true;
        }

        public void stop()
        {
            timer.Enabled = false;
        }

        public void addSecond()
        {
            seg++;
            if (seg == 60)
            {
                min++;
                seg = 0;
            }
            else if (min == 60)
            {
                hrs++;
                min = 0;
            }
        }

        public string getTimeString()
        {
            return hrs.ToString().PadLeft(2, '0') + ":" + min.ToString().PadLeft(2, '0') + ":" + seg.ToString().PadLeft(2, '0');
        }

    }
}
